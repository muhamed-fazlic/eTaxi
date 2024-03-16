import 'dart:convert';
import 'dart:developer';
import 'dart:io';

import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/models/vehicle_type_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/main_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/services/user_service.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:etaxi_admin/widgets/custom_text_field.dart';
import 'package:etaxi_admin/widgets/error_dialog.dart';
import 'package:flutter/material.dart';

class VehicleDialog extends StatefulWidget {
  VehicleDialog({Key? key, this.isEdit = false, this.vehicle})
      : super(key: key);
  bool isEdit = false;
  VehicleModel? vehicle;

  @override
  _VehicleDialogState createState() => _VehicleDialogState();
}

class _VehicleDialogState extends State<VehicleDialog> {
  //fields in dialog
  TextEditingController name = TextEditingController();
  TextEditingController licenceNumber = TextEditingController();
  TextEditingController kmTraveled = TextEditingController();
  TextEditingController year = TextEditingController();
  TextEditingController color = TextEditingController();
  TextEditingController brand = TextEditingController();
  TextEditingController imageUrl = TextEditingController();
  TextEditingController pricePerKm = TextEditingController();
  bool airBag = false;
  bool airCondition = false;
  int? selectedVehicleType;
  int? selectedCompanyId;
  int? selectedDrivedId;
  String? selectedFuelType;
  String? selectedTransmission;

  GlobalKey<FormState> formKey = GlobalKey<FormState>();
//---
  MainServices mainServices = MainServices();

  @override
  void initState() {
    if (widget.vehicle != null) {
      name.text = widget.vehicle!.vehicleName!;
      licenceNumber.text = widget.vehicle!.licenceNumber!;
      kmTraveled.text = widget.vehicle!.kmTraveled.toString();
      year.text = widget.vehicle!.year.toString();
      color.text = widget.vehicle!.color!;
      brand.text = widget.vehicle!.brand!;
      imageUrl.text = widget.vehicle!.photo!;
      pricePerKm.text = widget.vehicle!.price.toString();
      airBag = widget.vehicle!.airBags!;
      airCondition = widget.vehicle!.airCondition!;
      selectedVehicleType = widget.vehicle!.type!.id;
      selectedCompanyId = widget.vehicle!.companyId ?? null;
      selectedFuelType = widget.vehicle!.fuelType;
      selectedTransmission = widget.vehicle!.transmission;
      selectedDrivedId = widget.vehicle!.driverId;
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Container(
      constraints: BoxConstraints(minWidth: 500),
      child: AlertDialog(
        contentPadding: EdgeInsets.all(50),
        title: Text(widget.isEdit ? "Izmjeni vozilo" : 'Dodaj novo vozilo'),
        content: SingleChildScrollView(
          child: Form(
            key: formKey,
            child: Column(
              mainAxisSize: MainAxisSize.min,
              children: [
                CustomTextField(
                  label: "Naziv vozila",
                  controller: name,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Slika vozila (URL)',
                  controller: imageUrl,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Marka/Brand',
                  controller: brand,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Godiste',
                  controller: year,
                  inputType: TextInputType.number,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else if (int.tryParse(value) == null) {
                      return "Polje mora bit cijeli broj!";
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: "Boja",
                  controller: color,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else
                      return null;
                  },
                ),
                CheckboxListTile(
                  value: airBag,
                  onChanged: (value) {
                    setState(() {
                      airBag = value!;
                    });
                  },
                  title: Text('AirBag'),
                ),
                CheckboxListTile(
                  value: airCondition,
                  onChanged: (value) {
                    setState(() {
                      airCondition = value!;
                    });
                  },
                  title: Text('Klima'),
                ),
                DropdownButtonFormField<String>(
                  value: selectedFuelType,
                  items: [
                    DropdownMenuItem(
                      child: Text('Dizel'),
                      value: 'Dizel',
                    ),
                    DropdownMenuItem(
                      child: Text('Benzin'),
                      value: 'Benzin',
                    ),
                    DropdownMenuItem(
                      child: Text('Hibrid'),
                      value: 'Hibrid',
                    ),
                    DropdownMenuItem(
                      child: Text('Elektricno'),
                      value: 'Elektricno',
                    ),
                  ],
                  decoration: InputDecoration(
                    labelText: 'Tip goriva',
                  ),
                  onChanged: (value) {
                    setState(() {
                      selectedFuelType = value!;
                    });
                    print(value);
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Cijena po kilometru',
                  inputType: TextInputType.number,
                  controller: pricePerKm,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else if (int.tryParse(value) == null) {
                      return "Polje mora bit cijeli broj!";
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Kilometraza',
                  inputType: TextInputType.number,
                  controller: kmTraveled,
                  validator: (value) {
                    if (value!.isEmpty) {
                      return 'Polje ne moze biti prazno!';
                    } else if (double.tryParse(value) == null) {
                      return "Polje mora biti broj!";
                    } else
                      return null;
                  },
                ),
                sh(10),
                CustomTextField(
                  label: 'Broj registracije',
                  inputType: TextInputType.number,
                  controller: licenceNumber,
                ),
                FutureBuilder<List<VehicleType>>(
                  future: MainServices.getVehicleTypes(),
                  builder: (context, snapshot) {
                    if (snapshot.hasError) {
                      print(snapshot.error);
                    }
                    if (snapshot.hasData) {
                      return DropdownButtonFormField<int>(
                        value: selectedVehicleType,
                        items: snapshot.data!
                            .map(
                              (VehicleType item) => DropdownMenuItem<int>(
                                child: Text(item.name!),
                                value: item.id,
                              ),
                            )
                            .toList(),
                        decoration: InputDecoration(
                          labelText: 'Tip vozila',
                        ),
                        validator: (value) {
                          if (value == null) {
                            return 'Polje ne moze biti prazno!';
                          } else
                            return null;
                        },
                        onChanged: (value) {
                          setState(() {
                            selectedVehicleType = value!;
                          });
                          print(value);
                        },
                      );
                    }
                    return CircularProgressIndicator();
                  },
                ),
                DropdownButtonFormField<String>(
                  value: selectedTransmission,
                  items: [
                    DropdownMenuItem(
                      child: Text('Manual'),
                      value: 'Manual',
                    ),
                    DropdownMenuItem(
                      child: Text('Automatic'),
                      value: 'Automatic',
                    ),
                  ],
                  decoration: InputDecoration(
                    labelText: 'Transmisija',
                  ),
                  validator: (value) {
                    if (value?.isEmpty ?? true) {
                      return 'Polje ne moze biti prazno!';
                    } else
                      return null;
                  },
                  onChanged: (value) {
                    setState(() {
                      selectedTransmission = value!;
                    });
                    print(value);
                  },
                ),
                FutureBuilder(
                  future: MainServices.getCompanies(),
                  builder: (context, snapshot) {
                    if (snapshot.hasError) {
                      print(snapshot.error);
                    }
                    if (snapshot.hasData) {
                      return DropdownButtonFormField<int>(
                        value: selectedCompanyId,
                        items: snapshot.data!
                            .map(
                              (item) => DropdownMenuItem<int>(
                                child: Text(item["name"]),
                                value: item["id"],
                              ),
                            )
                            .toList(),
                        decoration: InputDecoration(
                          labelText: 'Kompanija',
                        ),
                        onChanged: (value) {
                          setState(() {
                            selectedCompanyId = value;
                          });
                          print(value);
                        },
                      );
                    }
                    return CircularProgressIndicator();
                  },
                ),
                FutureBuilder(
                  future: UserServices.getAllUser(),
                  builder: (context, snapshot) {
                    if (snapshot.hasError) {
                      print(snapshot.error);
                    }
                    if (snapshot.hasData) {
                      var availableDrivers = MainProvider.instance.allUsers;
                      if (widget.vehicle == null) {
                        availableDrivers = getAvailableDrivers(
                            MainProvider.instance.allUsers,
                            MainProvider.instance.availableModel);
                      }

                      return DropdownButtonFormField<int>(
                        value: selectedDrivedId,
                        items: availableDrivers.map((item) {
                          return DropdownMenuItem<int>(
                            child: Text(item.firstName! + " " + item.lastName!),
                            value: item.id,
                          );
                        }).toList(),
                        decoration: InputDecoration(
                          labelText: 'Vozac',
                        ),
                        validator: (value) {
                          inspect(value);
                          if (value == null) {
                            return 'Polje ne moze biti prazno!';
                          } else
                            return null;
                        },
                        onChanged: (value) {
                          setState(() {
                            selectedDrivedId = value!;
                          });
                        },
                      );
                    }
                    return CircularProgressIndicator();
                  },
                ),
              ],
            ),
          ),
        ),
        actions: [
          Center(
            child: CustomButton(
              vertPad: 5,
              height: 45,
              fontSize: 16,
              width: 200,
              onPressed: () async {
                if (!formKey.currentState!.validate()) {
                  return;
                }
                //Send data to server
                var data = {
                  "name": name.text,
                  "kmTraveled": kmTraveled.text,
                  "licenceNumber": licenceNumber.text,
                  "year": year.text,
                  "airCondition": airCondition,
                  "airBag": airBag,
                  "fuelType": selectedFuelType,
                  "transmission": selectedTransmission,
                  "currentLocationId": null,
                  "color": color.text,
                  "brand": brand.text,
                  "pricePerKm": pricePerKm.text,
                  "userDriverId": selectedDrivedId,
                  "typeId": selectedVehicleType!,
                  "imageUrl": imageUrl.text,
                  "companyId": selectedCompanyId,
                };
                if (widget.isEdit) {
                  data["id"] = widget.vehicle!.vehicleId;
                }
                try {
                  if (widget.isEdit) {
                    await mainServices.editVehicle(
                        data: data, id: widget.vehicle!.vehicleId!);
                  } else {
                    await mainServices.addVehicle(
                      data: data,
                    );
                  }
                  AuthProvider.instance.resetStateFunction();
                  appSnackBar(
                      context: context,
                      msg: "Uspjeno izvrsenja radnja",
                      isError: false);
                  Navigator.pop(context);
                } catch (e) {
                  showDialog(
                      context: context,
                      builder: (context) => ErrorDialog(
                            message: e.toString(),
                          ));
                }
              },
              label: widget.isEdit ? "Izmjeni" : 'Dodaj',
            ),
          ),
        ],
      ),
    );
  }
}

List<Userinfo> getAvailableDrivers(
    List<Userinfo> allUsers, List<VehicleModel> vehicles) {
  List<Userinfo> availableDrivers = [];

  for (var user in allUsers) {
    var isAvailable = true;

    for (var vehicle in vehicles) {
      if (vehicle.driverId == user.id) {
        isAvailable = false;
        break;
      }
    }

    if (isAvailable) {
      availableDrivers.add(user);
    }
  }

  return availableDrivers;
}
