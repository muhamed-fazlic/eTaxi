import 'dart:developer';

import 'package:etaxi_admin/models/vehicle_type_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:etaxi_admin/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';

class VehicleTypeDialog extends StatefulWidget {
  VehicleTypeDialog({super.key, this.vehicleType});
  VehicleType? vehicleType;

  @override
  State<VehicleTypeDialog> createState() => _VehicleTypeDialogState();
}

class _VehicleTypeDialogState extends State<VehicleTypeDialog> {
  TextEditingController type = TextEditingController();
  TextEditingController numberOfSeats = TextEditingController();
  TextEditingController imageUrl = TextEditingController();
  MainServices mainServices = MainServices();
  GlobalKey<FormState> formKey = GlobalKey<FormState>();

  @override
  void initState() {
    if (widget.vehicleType != null) {
      type.text = widget.vehicleType!.name!;
      numberOfSeats.text = widget.vehicleType!.seats!.toString();
      imageUrl.text = widget.vehicleType!.imageUrl!;
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
        title: Text('Tip vozila'),
        content: Container(
          constraints: const BoxConstraints(minWidth: 500),
          child: Form(
            key: formKey,
            child: Column(mainAxisSize: MainAxisSize.min, children: [
              CustomTextField(
                label: 'Naziv tipa vozila',
                controller: type,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Polje ne moze biti prazno!';
                  } else
                    return null;
                },
              ),
              sh(10),
              CustomTextField(
                label: 'Slika tipa vozila (URL)',
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
                label: 'Broj sjedista',
                inputType: TextInputType.number,
                controller: numberOfSeats,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Polje ne moze biti prazno!';
                  } else if (double.tryParse(value) == null) {
                    return "Polje mora biti broj!";
                  } else
                    return null;
                },
              ),
            ]),
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
                  if (!formKey.currentState!.validate()) return;
                  var data = {
                    'type': type.text,
                    'numberOfSeats': numberOfSeats.text,
                    'imageUrl': imageUrl.text,
                  };
                  try {
                    if (widget.vehicleType != null) {
                      data['id'] = widget.vehicleType!.id.toString();

                      await MainServices.editVehicleType(
                        data: data,
                        id: widget.vehicleType!.id!,
                      );
                    } else {
                      await mainServices.addVehicleType(
                        data: data,
                      );
                    }
                    AuthProvider.instance.resetStateFunction();
                  } catch (e) {
                    log("ERROR ADDING VEHICLE TYPE: $e");
                  }
                  Navigator.pop(context);
                },
                label: widget.vehicleType != null ? "Izmjeni" : 'Dodaj'),
          )
        ]);
  }
}
