import 'dart:developer';

import 'package:cached_network_image/cached_network_image.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/line.dart';
import 'package:etaxi_admin/widgets/vehicle_dialog.dart';
import 'package:flutter/material.dart';

class VehicleBox extends StatefulWidget {
  VehicleBox(
      {Key? key, required this.vehicle, this.fun, this.noActions = false})
      : super(key: key);

  final VehicleModel vehicle;
  bool noActions;
  final Function()? fun;

  @override
  State<VehicleBox> createState() => _VehicleBoxState();
}

class _VehicleBoxState extends State<VehicleBox> {
  final MainServices services = MainServices();
  bool moreDetails = false;

  @override
  Widget build(BuildContext context) {
    return Container(
      decoration:
          BoxDecoration(borderRadius: BorderRadius.circular(4), border: null),
      //width: 200,
      //height: 100,
      child: Padding(
        padding: const EdgeInsets.all(8.0),
        child: Column(
          children: [
            Row(
              crossAxisAlignment: CrossAxisAlignment.start,
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                Container(
                  width: 150,
                  child: Center(
                    child: CachedNetworkImage(
                      imageUrl: widget.vehicle.photo!,
                      height: 100,
                      width: 150,
                      fit: BoxFit.fitWidth,
                      imageBuilder: (context, imageProvider) => Container(
                        width: 100,
                        height: 150,
                        decoration: BoxDecoration(
                          color: secondaryColor,
                          borderRadius: BorderRadius.circular(4),
                          image: DecorationImage(
                            image: imageProvider,
                            fit: BoxFit.cover,
                          ),
                        ),
                      ),
                    ),
                  ),
                ),
                sb(8),
                Expanded(
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Text(
                        widget.vehicle.vehicleName!,
                        style: TextStyle(
                            fontSize: 16, fontWeight: FontWeight.w500),
                      ),
                      sh(5),
                      if (widget.vehicle.companyName != '' &&
                          widget.vehicle.companyName != null)
                        Container(
                          padding:
                              EdgeInsets.symmetric(horizontal: 6, vertical: 2),
                          decoration: BoxDecoration(
                              color: Colors.grey[200],
                              borderRadius: BorderRadius.circular(10)),
                          child: Text(
                            widget.vehicle.companyName ?? '',
                          ),
                        ),
                      sh(5),
                      GestureDetector(
                        onTap: () {
                          setState(() {
                            moreDetails = !moreDetails;
                          });
                        },
                        child: Text(
                          'Detaljnije',
                          style: TextStyle(
                              color: primaryColor, fontWeight: FontWeight.w500),
                        ),
                      )
                    ],
                  ),
                ),
                sb(12),
                Column(
                  crossAxisAlignment: CrossAxisAlignment.end,
                  children: [
                    Text(
                      '${widget.vehicle.price} BAM/km',
                      style: TextStyle(
                          fontWeight: FontWeight.w700, color: primaryColor),
                    ),
                    sh(5),
                    if (!widget.noActions)
                      Row(
                        children: [
                          IconButton(
                            icon: Icon(Icons.edit),
                            // color: Colors.red,
                            onPressed: () {
                              showDialog(
                                  context: context,
                                  builder: (context) => VehicleDialog(
                                        isEdit: true,
                                        vehicle: widget.vehicle,
                                      ));
                            },
                          ),
                          IconButton(
                            icon: Icon(Icons.delete),
                            onPressed: () {
                              showDialog(
                                  context: context,
                                  builder: ((context) {
                                    return AlertDialog(
                                      title: Text('Obrisi vozilo'),
                                      content: Text(
                                          'Da li ste sigurni da zelite obrisati ovo vozilo?'),
                                      actions: [
                                        TextButton(
                                          onPressed: () {
                                            Navigator.pop(context);
                                          },
                                          child: Text('Cancel'),
                                        ),
                                        TextButton(
                                          onPressed: () async {
                                            try {
                                              await services.deleteVehicle(
                                                  id: widget
                                                      .vehicle.vehicleId!);
                                              AuthProvider.instance
                                                  .resetStateFunction();
                                            } catch (e) {
                                              log("ERROR DELETING VEHICLE $e");
                                            }
                                            Navigator.pop(context);
                                          },
                                          child: Text('Delete'),
                                        ),
                                      ],
                                    );
                                  }));
                            },
                          ),
                        ],
                      ),
                  ],
                ),
              ],
            ),
            if (moreDetails)
              Column(
                children: [
                  sh(10),
                  Row(
                    crossAxisAlignment: CrossAxisAlignment.center,
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Column(
                        children: [
                          Row(
                            children: [
                              Text("Kilometraza: "),
                              Text(
                                widget.vehicle.kmTraveled.toString(),
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          ),
                          Row(
                            children: [
                              Text("Godiste: "),
                              Text(
                                widget.vehicle.year.toString(),
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          ),
                          Row(
                            children: [
                              Text("Broj tablica: "),
                              Text(
                                widget.vehicle.licenceNumber.toString(),
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          )
                        ],
                      ),
                      sb(20),
                      Column(
                        children: [
                          Row(
                            children: [
                              Text("Gorivo: "),
                              Text(
                                widget.vehicle.fuelType.toString(),
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          ),
                          Row(
                            children: [
                              Text("Transmisija: "),
                              Text(
                                widget.vehicle.transmission.toString(),
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          ),
                          Row(
                            children: [
                              Text("Tip vozila: "),
                              Text(
                                widget.vehicle.type?.name.toString() ?? '',
                                style: TextStyle(fontWeight: FontWeight.w600),
                              ),
                            ],
                          )
                        ],
                      ),
                      sb(20),
                      Column(
                        children: [
                          Row(
                            children: [
                              Text("AirBag: "),
                              Checkbox(
                                  value: widget.vehicle.airBags,
                                  onChanged: null),
                            ],
                          ),
                          Row(
                            children: [
                              Text("Klima: "),
                              Checkbox(
                                value: widget.vehicle.airCondition,
                                onChanged: null,
                                visualDensity: VisualDensity.compact,
                                materialTapTargetSize:
                                    MaterialTapTargetSize.shrinkWrap,
                              ),
                            ],
                          )
                        ],
                      ),
                    ],
                  ),
                  sh(10),
                  line()
                ],
              )
          ],
        ),
      ),
    );
  }
}
