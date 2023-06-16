import 'package:date_time_picker/date_time_picker.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/services/order_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/utils/utilFunctions.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:etaxi_admin/widgets/error_dialog.dart';
import 'package:etaxi_admin/widgets/line.dart';
import 'package:etaxi_admin/widgets/place_picker_widget.dart';
import 'package:etaxi_admin/widgets/searchBar.dart' as sb;
import 'package:etaxi_admin/widgets/vehicle_viewBox.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

import '../models/location_model.dart';

class OrderDialog extends StatefulWidget {
  const OrderDialog({super.key});

  @override
  State<OrderDialog> createState() => _OrderDialogState();
}

class _OrderDialogState extends State<OrderDialog> {
  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text('Nova narudzba'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Consumer<OrderProvider>(
              builder: (context, notifier, child) => sb.SearchBar(
                  hintText: notifier.currentLocationData?.address ??
                      'Pocetna lokacija',
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: ((context) => PlacePickerWidget(
                                  onPicked: (pickedData) {
                                    OrderProvider.instance.setCurrentLoc(
                                        Location.fromPickedData(pickedData));
                                    Navigator.pop(context);
                                  },
                                ))));
                  }),
            ),
            SizedBox(
              height: 16,
            ),
            Consumer<OrderProvider>(
              builder: (context, notifier, child) => sb.SearchBar(
                  hintText: notifier.destinationLocationData?.address ??
                      'Finalna lokacija',
                  onTap: () {
                    Navigator.push(
                        context,
                        MaterialPageRoute(
                            builder: ((context) => PlacePickerWidget(
                                  onPicked: (pickedData) {
                                    OrderProvider.instance.setDestinationLoc(
                                        Location.fromPickedData(pickedData));
                                    Navigator.pop(context);
                                  },
                                ))));
                  }),
            ),
            SizedBox(
              height: 20,
            ),
            Text('Izaberite vozilo'),
            Consumer<OrderProvider>(
              builder: (context, notifier, child) => Container(
                width: SizeConfig.screenWidth * 0.7,
                height: 300,
                constraints: BoxConstraints(minHeight: 200, maxHeight: 400),
                child: FutureBuilder<List<VehicleModel>>(
                  future: MainServices.getVehicles(queryParams: {
                    "CompanyId":
                        AuthProvider.instance.user!.companyId?.toString() ??
                            null
                  }),
                  builder: (context, snapshot) {
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return CircularProgressIndicator();
                    } else if (snapshot.hasError) {
                      return Text('Error: ${snapshot.error}');
                    } else if (!snapshot.hasData) {
                      return Text('No data available');
                    } else {
                      return ListView.builder(
                          shrinkWrap: true,
                          itemCount: snapshot.data!.length,
                          itemBuilder: (context, index) {
                            var vehicle = snapshot.data![index];
                            return InkWell(
                                onTap: () {
                                  OrderProvider.instance
                                      .setSelectedVehicle(vehicle);
                                },
                                child: Container(
                                  decoration: BoxDecoration(
                                      borderRadius: BorderRadius.circular(4),
                                      border: vehicle.vehicleId ==
                                              notifier
                                                  .selectedVehicle?.vehicleId
                                          ? Border.all(color: primaryColor)
                                          : null),
                                  child: VehicleBox(
                                    vehicle: vehicle,
                                    noActions: true,
                                  ),
                                ));
                          });
                    }
                  },
                ),
              ),
            ),
            sh(10),
            Text(
              "Vrijeme narudzbe",
            ),
            Padding(
                padding: const EdgeInsets.symmetric(horizontal: 16),
                child: DateTimePicker(
                  initialValue: dateFormat(
                      OrderProvider.instance.startTime ?? DateTime.now()),
                  dateMask: "dd.MM.yyyy HH:mm",
                  type: DateTimePickerType.dateTime,
                  initialDate:
                      OrderProvider.instance.startTime ?? DateTime.now(),
                  firstDate: DateTime.now(),
                  lastDate: DateTime.now().add(Duration(days: 5)),
                  onChanged: (newValue) {
                    OrderProvider.instance
                        .setStartTime(DateTime.parse(newValue));
                  },
                )),
            sh(20),
            Consumer<OrderProvider>(builder: (context, notifier, child) {
              if (notifier.selectedVehicle != null &&
                  notifier.currentLocationData != null &&
                  notifier.destinationLocationData != null)
                return Container(
                  margin: EdgeInsets.symmetric(
                    horizontal: 15,
                    vertical: 15,
                  ),
                  padding: EdgeInsets.fromLTRB(17, 20, 17, 20),
                  decoration: BoxDecoration(
                    color: Colors.white,
                    borderRadius: BorderRadius.circular(4),
                    boxShadow: [
                      BoxShadow(
                        color: Color(0xff0000000).withOpacity(0.1),
                        spreadRadius: 0,
                        blurRadius: 4,
                        offset: Offset(0, 4),
                      ),
                    ],
                  ),
                  child: Column(
                    children: [
                      bookingDetailsListTab('Naziv vozila',
                          notifier.selectedVehicle!.vehicleName!),
                      bookingDetailsListTab('Cijena po km',
                          notifier.selectedVehicle!.price.toString() + " BAM"),
                      bookingDetailsListTab(
                          'Udaljenost',
                          notifier
                                  .calculateDistance(
                                      notifier.currentLocationData!,
                                      notifier.destinationLocationData!)
                                  .toString() +
                              " km"),
                      sh(8),
                      line(),
                      sh(8),
                      bookingDetailsListTab(
                          'Ukupno', notifier.calculateTotalPrice())
                    ],
                  ),
                );
              else
                return Container();
            }),
            CustomButton(
              label: 'Naruci voznju',
              onPressed: () async {
                if (OrderProvider.instance.currentLocationData == null ||
                    OrderProvider.instance.destinationLocationData == null) {
                  return showDialog(
                      context: context,
                      builder: (context) => AlertDialog(
                            content: Text(
                                "Molimo izaberite pocetnu i krajnju lokaciju"),
                          ));
                }
                if (OrderProvider.instance.selectedVehicle == null) {
                  return showDialog(
                      context: context,
                      builder: (context) => AlertDialog(
                            content: Text("Molimo izaberite taxi"),
                          ));
                }

                await OrderService.createOrder();
                Navigator.pop(context);
              },
            )
          ],
        ),
      ),
    );
  }

  @override
  void dispose() {
    OrderProvider.instance.resetToInit();
    super.dispose();
  }
}

Widget bookingDetailsListTab(String title, String desc) {
  return Padding(
    padding: const EdgeInsets.symmetric(vertical: 4.0),
    child: Row(
      mainAxisAlignment: MainAxisAlignment.spaceBetween,
      children: [
        Text(title),
        Text(
          desc,
          style: TextStyle(color: primaryColor),
        )
      ],
    ),
  );
}
