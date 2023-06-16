import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:flutter/cupertino.dart';
import 'package:flutter/material.dart';

class VehicleFilters extends StatelessWidget {
  void Function()? onSubmit;
  VehicleFilters({Key? key, Function()? onSubmit}) : super(key: key);

  TextEditingController typeController = TextEditingController();
  TextEditingController seatsController = TextEditingController();
  TextEditingController fuelTypeController = TextEditingController();
  TextEditingController brandController = TextEditingController();
  TextEditingController companyController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    var h = SizeConfig.screenHeight / 812;
    return Padding(
        padding: EdgeInsets.symmetric(horizontal: 16, vertical: 4),
        child: Column(
          children: [
            CustomTextField(label: "Tip vozila", controller: typeController),
            sh(10),
            CustomTextField(
              label: 'Broj sjedista',
              controller: seatsController,
              inputType: TextInputType.number,
            ),
            sh(10),
            CustomTextField(label: 'Gorivo', controller: fuelTypeController),
            sh(10),
            CustomTextField(label: 'Brand vozila', controller: brandController),
            sh(10),
            CustomTextField(label: 'Kompanija', controller: companyController),
            sh(10),
            CustomButton(
                label: "Primjeni",
                onPressed: () {
                  Map<String, dynamic> filters = {};

                  if (typeController.text.isNotEmpty)
                    filters['type'] = typeController.text;
                  if (seatsController.text.isNotEmpty)
                    filters['numberOfSeats'] = seatsController.text;
                  if (fuelTypeController.text.isNotEmpty)
                    filters['fuelType'] = fuelTypeController.text;
                  if (brandController.text.isNotEmpty)
                    filters['brand'] = brandController.text;
                  if (companyController.text.isNotEmpty)
                    filters['companyName'] = companyController.text;

                  OrderProvider.instance.setVehicleFilters(filters);
                  //if (onSubmit != null) onSubmit;
                })
          ],
        ));
  }
}
