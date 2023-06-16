import 'dart:developer';

import 'package:date_time_picker/date_time_picker.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/commonPages/addCardPage.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/taxiRideBookedPage.dart';
import 'package:etaxi_mobile/screens/taxi/widgets/taxiInfoListTile.dart';
import 'package:etaxi_mobile/screens/taxi/widgets/vehicleFilters.dart';
import 'package:etaxi_mobile/services/order_services.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

import 'package:flutter_svg/flutter_svg.dart';
import 'package:provider/provider.dart';

class BookingPage extends StatefulWidget {
  BookingPage({Key? key}) : super(key: key);

  @override
  State<BookingPage> createState() => _BookingPageState();
}

class _BookingPageState extends State<BookingPage> {
  TextEditingController _promoCodeController = TextEditingController();
  TextEditingController _startTimeController = TextEditingController();

  bool isVehicleFilterOpen = false;

  @override
  void initState() {
    if (OrderProvider.instance.selectedOrder != null) {
      _startTimeController.text =
          OrderProvider.instance.selectedOrder!.startTime.toString();
    } else {
      _startTimeController.text = DateTime.now().toString();
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        AppBar(
          centerTitle: true,
          elevation: 0,
          leading: InkWell(
            onTap: () {
              OrderProvider.instance.setBookingStage(BookingStage.DESTINATION);
            },
            child: Padding(
              padding: EdgeInsets.symmetric(
                vertical: 22,
                horizontal: 20,
              ),
              child: Icon(
                Icons.arrow_back_ios_new_rounded,
                size: 18,
              ),
            ),
          ),
          title: Text(
            "Izaberite vozilo",
            style: TextStyle(
              fontSize: 18,
              fontWeight: FontWeight.w700,
            ),
          ),
        ),
        Spacer(),
        Align(
          alignment: Alignment.bottomCenter,
          child: Container(
              color: Colors.white,
              height: SizeConfig.screenHeight * 0.5,
              child: SingleChildScrollView(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Container(
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
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          Row(
                            children: [
                              SvgPicture.asset(
                                'assets/icons/blue_cirle.svg',
                                width: 17,
                              ),
                              sb(19),
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      OrderProvider.instance.currentLocationData
                                              ?.address ??
                                          "Trenutna lokacija",
                                      style: TextStyle(
                                        fontSize: 12,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                            ],
                          ),
                          Transform.translate(
                            offset: Offset(-3, 0),
                            child: Icon(
                              Icons.more_vert,
                              color: Color(0xff999999),
                            ),
                          ),
                          sh(5),
                          Row(
                            children: [
                              SvgPicture.asset(
                                'assets/icons/choose_city.svg',
                                color: Color(0xffD40511),
                                height: 20,
                              ),
                              sb(19),
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                      OrderProvider
                                              .instance
                                              .destinationLocationData
                                              ?.address ??
                                          "",
                                      style: TextStyle(
                                        fontSize: 12,
                                      ),
                                    ),
                                  ],
                                ),
                              ),
                              // ),
                            ],
                          ),
                        ],
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(horizontal: 30),
                      child: Row(
                        children: [
                          Text(
                            "Izaberite svoj taxi",
                            style: TextStyle(fontWeight: FontWeight.w500),
                          ),
                          Spacer(),
                          Text("Filteri"),
                          IconButton(
                            onPressed: () {
                              setState(() {
                                isVehicleFilterOpen = !isVehicleFilterOpen;
                              });
                            },
                            icon: Icon(Icons.filter_alt_outlined),
                          )
                        ],
                      ),
                    ),
                    if (isVehicleFilterOpen)
                      VehicleFilters(
                        onSubmit: () {
                          setState(() {
                            isVehicleFilterOpen = false;
                          });
                        },
                      ),
                    TaxiInfoListTile(),
                    // Padding(
                    //   padding: const EdgeInsets.symmetric(
                    //       horizontal: 16, vertical: 5),
                    //   child: CustomTextField(
                    //     label: 'Promo kod',
                    //     controller: _promoCodeController,
                    //   ),
                    // ),
                    // Padding(
                    //   padding: const EdgeInsets.symmetric(horizontal: 16),
                    //   child: CustomButton(
                    //       label: 'Primijeni promo kod', onPressed: () {}),
                    // ),
                    Padding(
                      padding: const EdgeInsets.fromLTRB(16, 15, 16, 0),
                      child: Text(
                        "Vrijeme narudzbe",
                      ),
                    ),
                    Padding(
                        padding: const EdgeInsets.symmetric(horizontal: 16),
                        child: DateTimePicker(
                          controller: _startTimeController,
                          dateMask: "dd.MM.yyyy HH:mm",
                          type: DateTimePickerType.dateTime,
                          initialDate: OrderProvider.instance.startTime ??
                              DateTime.now(),
                          firstDate: DateTime.now(),
                          lastDate: DateTime.now().add(Duration(days: 5)),
                          onChanged: (newValue) {
                            setState(() {
                              _startTimeController.text = newValue;
                            });
                            OrderProvider.instance
                                .setStartTime(DateTime.parse(newValue));
                          },
                        )),
                    if (OrderProvider.instance.selectedVehicle != null)
                      Container(
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
                            bookingDetailsListTab(
                                'Naziv vozila',
                                OrderProvider
                                    .instance.selectedVehicle!.vehicleName!),
                            bookingDetailsListTab(
                                'Cijena po km',
                                OrderProvider.instance.selectedVehicle!.price
                                        .toString() +
                                    " BAM"),
                            bookingDetailsListTab(
                                'Udaljenost',
                                OrderProvider
                                    .instance.directions!.totalDistance!),
                            bookingDetailsListTab(
                                'Vrijeme trajanja',
                                OrderProvider
                                    .instance.directions!.totalDuration!),
                            sh(8),
                            line(),
                            sh(8),
                            bookingDetailsListTab('Ukupno',
                                OrderProvider.instance.calculateTotalPrice())
                          ],
                        ),
                      ),
                    Padding(
                      padding: const EdgeInsets.only(left: 16, top: 12),
                      child: Text(
                        "Nacin placanja",
                        style: TextStyle(fontWeight: FontWeight.w400),
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.only(left: 16, top: 12),
                      child: Consumer<OrderProvider>(
                        builder: (context, notifier, child) => Row(
                          children: [
                            paymentMethodWidget(PaymentMethod.CASH,
                                notifier.paymentMethod == PaymentMethod.CASH),
                            sb(8),
                            paymentMethodWidget(PaymentMethod.ONLINE,
                                notifier.paymentMethod == PaymentMethod.ONLINE),
                          ],
                        ),
                      ),
                    ),
                    if (OrderProvider.instance.paymentMethod ==
                        PaymentMethod.ONLINE)
                      Padding(
                        padding:
                            const EdgeInsets.only(left: 16, top: 12, right: 16),
                        child: CustomButton(
                          label: "Dodaj detalje kartice",
                          onPressed: () {
                            Navigator.push(
                                context,
                                MaterialPageRoute(
                                    builder: (context) => AddCardPage()));
                          },
                        ),
                      ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 16, vertical: 16),
                      child: CustomButton(
                          onPressed: () async {
                            if (OrderProvider.instance.selectedVehicle ==
                                null) {
                              return appSnackBar(
                                  context: context,
                                  msg: "Molimo izaberite svoj taxi",
                                  isError: true);
                            }
                            if (OrderProvider.instance.paymentMethod ==
                                    PaymentMethod.ONLINE &&
                                OrderProvider.instance.creditCardModel ==
                                    null) {
                              return appSnackBar(
                                  context: context,
                                  msg:
                                      "Molimo dodajte detalje kartice ili odaberite drugi nacin placanja",
                                  isError: true);
                            }
                            if (AuthProvider.instance.user?.id ==
                                OrderProvider
                                    .instance.selectedVehicle!.driverId) {
                              return appSnackBar(
                                  context: context,
                                  msg: "Ne mozete naruciti svoj taxi",
                                  isError: true);
                            }

                            try {
                              if (OrderProvider.instance.isEditOrder) {
                                await OrderServices.updateOrder();
                                appSnackBar(
                                    context: context,
                                    msg: "Vasa narudzba je uspjesno izmjenjena",
                                    isError: false);
                                OrderProvider.instance
                                    .setBookingStage(BookingStage.RIDE_BOOKED);
                                return;
                              }

                              await OrderServices.createOrder();
                              appSnackBar(
                                  context: context,
                                  msg: "Vasa narudzba je uspjesno kreirana",
                                  isError: false);

                              //animate accepted order
                              await Future.delayed(Duration(seconds: 1));
                              showDialog(
                                  context: context,
                                  barrierDismissible: false,
                                  builder: (builder) => AlertDialog(
                                        title:
                                            Text("Vasa narudzba je prihvacena"),
                                        actions: [
                                          TextButton(
                                              onPressed: () {
                                                OrderProvider.instance
                                                    .setBookingStage(
                                                        BookingStage.PICKUP);
                                                Navigator.pop(context);
                                              },
                                              child: Text("Nazad")),
                                          TextButton(
                                              onPressed: () {
                                                OrderProvider.instance
                                                    .setBookingStage(
                                                        BookingStage
                                                            .RIDE_BOOKED);
                                                Navigator.pop(context);
                                              },
                                              child: Text("Pregledaj narudzbu"))
                                        ],
                                      ));
                            } catch (e) {
                              print(
                                  'ERROR IN ORDER CREATE/UPDTAE ${e.toString()}');
                              appSnackBar(
                                  context: context,
                                  msg:
                                      'Doslo je do greske prilikom ${OrderProvider.instance.isEditOrder ? "izmjene" : "kreiranja"} narudzbe',
                                  isError: true);
                            }
                          },
                          label: OrderProvider.instance.isEditOrder
                              ? "Izmjeni narudzbu"
                              : 'Naruci voznju'),
                    ),
                  ],
                ),
              )),
        ),
      ],
    );
  }

  Widget paymentMethodWidget(PaymentMethod method, bool isSelected) {
    return GestureDetector(
      onTap: () {
        OrderProvider.instance.setPaymentMethod(method);
      },
      child: Container(
        decoration: BoxDecoration(
            borderRadius: BorderRadius.circular(8),
            color: isSelected ? primaryColor : Colors.white),
        child: Padding(
            padding: const EdgeInsets.all(8.0),
            child: Text(PaymentMethod.CASH == method ? "Gotovina" : "Kartica")),
      ),
    );
  }
}
