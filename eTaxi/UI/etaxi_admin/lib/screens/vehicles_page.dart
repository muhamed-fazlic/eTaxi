import 'dart:developer';

import 'package:cached_network_image/cached_network_image.dart';
import 'package:etaxi_admin/models/vehicle_type_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/vehicleType_dialog.dart';
import 'package:etaxi_admin/widgets/vehicle_dialog.dart';
import 'package:etaxi_admin/widgets/vehicle_viewBox.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class VehiclesPage extends StatelessWidget {
  const VehiclesPage({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          const Padding(
            padding: EdgeInsets.only(bottom: 35.0),
            child: Center(
              child: Text(
                'Vozila',
                style: TextStyle(
                  fontSize: 36,
                ),
              ),
            ),
          ),
          Row(
            children: [
              IconButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => VehicleTypeDialog(),
                  );
                },
                icon: Icon(Icons.add),
              ),
              Text('Dodaj novi tip vozila'),
            ],
          ),
          Row(
            children: [
              IconButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => VehicleDialog(),
                  );
                },
                icon: Icon(Icons.add),
              ),
              Text('Dodaj novo vozilo'),
            ],
          ),
          sh(20),
          Text(
            'Pregled svih vozila',
            style: TextStyle(fontSize: 20),
          ),
          sh(16),
          Consumer<AuthProvider>(
            builder: (context, value, child) {
              return FutureBuilder(
                future: MainServices.getVehicles(queryParams: {
                  "CompanyId": value.user!.companyId?.toString() ?? null
                }),
                builder: ((context, snapshot) {
                  if (snapshot.hasError) {
                    print(snapshot.error);
                  }
                  if (snapshot.hasData) {
                    return ListView.separated(
                      padding: EdgeInsets.only(top: 5),
                      shrinkWrap: true,
                      itemCount: snapshot.data!.length,
                      itemBuilder: (context, index) {
                        return VehicleBox(
                          vehicle: snapshot.data![index],
                        );
                      },
                      separatorBuilder: (context, index) {
                        return Divider(
                          color: Colors.grey,
                        );
                      },
                    );
                  }
                  return CircularProgressIndicator();
                }),
              );
            },
          ),
          sh(20),
          Text(
            'Pregled tipova vozila',
            style: TextStyle(fontSize: 20),
          ),
          sh(16),
          Consumer<AuthProvider>(builder: (context, value, child) {
            return FutureBuilder<List<VehicleType>>(
              future: MainServices.getVehicleTypes(),
              builder: (context, snapshot) {
                if (snapshot.hasError) {
                  print(snapshot.error);
                }
                if (snapshot.hasData) {
                  return ListView.separated(
                    shrinkWrap: true,
                    itemCount: snapshot.data!.length,
                    separatorBuilder: (context, index) {
                      return Divider(
                        color: Colors.grey,
                      );
                    },
                    itemBuilder: (context, index) {
                      var vehicleType = snapshot.data![index];
                      return Container(
                        margin: EdgeInsets.symmetric(vertical: 8.0),
                        padding: EdgeInsets.all(8.0),
                        child: Row(
                          children: [
                            Container(
                              width: 150,
                              child: Center(
                                child: CachedNetworkImage(
                                  imageUrl: vehicleType.imageUrl!,
                                  height: 50,
                                  width: 100,
                                  fit: BoxFit.fitWidth,
                                  imageBuilder: (context, imageProvider) =>
                                      Container(
                                    width: 50,
                                    height: 10,
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
                            Spacer(),
                            Column(
                              children: [
                                Text("Naziv tipa:"),
                                Text(vehicleType.name!),
                              ],
                            ),
                            Spacer(),
                            Column(
                              children: [
                                Text("Broj sjedista:"),
                                Text(vehicleType.seats!.toString()),
                              ],
                            ),
                            Spacer(),
                            IconButton(
                              onPressed: () {
                                showDialog(
                                  context: context,
                                  builder: (context) => VehicleTypeDialog(
                                    vehicleType: vehicleType,
                                  ),
                                );
                              },
                              icon: Icon(Icons.edit),
                            ),
                            IconButton(
                              onPressed: () {
                                showDialog(
                                  context: context,
                                  builder: (context) => AlertDialog(
                                    title: Text('Brisanje tipa vozila'),
                                    content: Text(
                                        'Da li ste sigurni da želite da obrišete tip vozila?'),
                                    actions: [
                                      TextButton(
                                        onPressed: () {
                                          Navigator.pop(context);
                                        },
                                        child: Text('Ne'),
                                      ),
                                      TextButton(
                                        onPressed: () async {
                                          try {
                                            await MainServices
                                                .deleteVehicleType(
                                                    id: vehicleType.id!);
                                            AuthProvider.instance
                                                .resetStateFunction();
                                          } catch (e) {
                                            log("ERORR DELETING VEHICLE TYPE: $e");
                                          }
                                          Navigator.pop(context);
                                        },
                                        child: Text('Da'),
                                      ),
                                    ],
                                  ),
                                );
                              },
                              icon: Icon(Icons.delete),
                            ),
                          ],
                        ),
                      );
                    },
                  );
                }
                return CircularProgressIndicator();
              },
            );
          })
        ],
      ),
    );
  }
}
