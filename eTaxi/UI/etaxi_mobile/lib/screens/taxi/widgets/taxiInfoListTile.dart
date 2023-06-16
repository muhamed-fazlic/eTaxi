import 'dart:developer';

import 'package:etaxi_mobile/models/user_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/services/home_service.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/cached_image.dart';
import 'package:etaxi_mobile/widgets/vehicle_card.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class TaxiInfoListTile extends StatelessWidget {
  final EdgeInsets padding;
  const TaxiInfoListTile(
      {Key? key,
      this.padding = const EdgeInsets.symmetric(horizontal: 16, vertical: 4)})
      : super(key: key);

  @override
  Widget build(BuildContext context) {
    var h = SizeConfig.screenHeight / 812;
    return Padding(
      padding: padding,
      child: Container(
        width: double.infinity,
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
        child: FutureBuilder(
            future: HomeService.getVehicles(
                queryParams:
                    Provider.of<OrderProvider>(context).vehicleFilters),
            builder: ((context, snapshot) {
              if (snapshot.connectionState == ConnectionState.done)
                return snapshot.data!.length > 0
                    ? ListView.builder(
                        padding: EdgeInsets.only(top: 5),
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
                                          OrderProvider.instance.selectedVehicle
                                              ?.vehicleId
                                      ? Border.all(color: primaryColor)
                                      : null),
                              child: Padding(
                                padding: const EdgeInsets.all(8.0),
                                child: Row(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  mainAxisAlignment: MainAxisAlignment.center,
                                  children: [
                                    Container(
                                      width: 67,
                                      child: Center(
                                        child: CachedImage(
                                          imgUrl: vehicle.photo!,
                                          height: h * 50,
                                          width: SizeConfig.screenWidth,
                                          vehicleId:
                                              vehicle.vehicleId.toString(),
                                        ),
                                      ),
                                    ),
                                    sb(8),
                                    Expanded(
                                      child: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.center,
                                        mainAxisAlignment:
                                            MainAxisAlignment.center,
                                        children: [
                                          Text(
                                            vehicle.vehicleName!,
                                            style: TextStyle(
                                                fontSize: 16,
                                                fontWeight: FontWeight.w500),
                                          ),
                                          sh(5),
                                          if (vehicle.companyName != '' &&
                                              vehicle.companyName != null)
                                            Container(
                                              padding: EdgeInsets.symmetric(
                                                  horizontal: 6, vertical: 2),
                                              decoration: BoxDecoration(
                                                  color: Colors.grey[200],
                                                  borderRadius:
                                                      BorderRadius.circular(
                                                          10)),
                                              child: Text(
                                                vehicle.companyName ?? '',
                                              ),
                                            )
                                        ],
                                      ),
                                    ),
                                    sb(12),
                                    Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.end,
                                      children: [
                                        Text(
                                          '${vehicle.price} BAM/km',
                                          style: TextStyle(
                                              fontWeight: FontWeight.w700,
                                              color: primaryColor),
                                        ),
                                        sh(5),
                                        InkWell(
                                            onTap: () async {
                                              try {
                                                if (AuthProvider.instance.user
                                                        ?.favorites
                                                        ?.map(
                                                            (e) => e.companyId)
                                                        .contains(
                                                            vehicle.companyId ??
                                                                0) ??
                                                    false) {
                                                  await UserServices
                                                      .deleteFavoriteCompany(AuthProvider
                                                              .instance
                                                              .user!
                                                              .favorites
                                                              ?.firstWhere((element) =>
                                                                  element
                                                                      .companyId ==
                                                                  vehicle
                                                                      .companyId)
                                                              .id ??
                                                          0);
                                                } else {
                                                  await UserServices
                                                      .addFavoriteCompany(
                                                          vehicle);
                                                }
                                                var user =
                                                    await UserServices.getUser(
                                                        AuthProvider.instance
                                                            .user!.id!);
                                                AuthProvider.instance.setUser(
                                                    Userinfo.fromJson(user));
                                              } catch (e) {
                                                appSnackBar(
                                                    context: context,
                                                    msg: e.toString(),
                                                    isError: true);
                                              }
                                            },
                                            child: Icon(Provider.of<
                                                                AuthProvider>(
                                                            context)
                                                        .user
                                                        ?.favorites
                                                        ?.map(
                                                            (e) => e.companyId)
                                                        .contains(
                                                            vehicle.companyId ??
                                                                0) ??
                                                    false
                                                ? Icons.favorite
                                                : Icons.favorite_outline))
                                      ],
                                    )
                                  ],
                                ),
                              ),
                            ),
                          );
                        })
                    : Center(
                        child: Padding(
                        padding: const EdgeInsets.all(8.0),
                        child: Text("Nema pronadjenih vozila"),
                      ));
              else
                return Center(child: CircularProgressIndicator());
            })),
      ),
    );
  }
}
