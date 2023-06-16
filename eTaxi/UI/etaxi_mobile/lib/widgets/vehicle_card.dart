import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/cached_image.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:flutter/material.dart';

class VehicleCard extends StatelessWidget {
  const VehicleCard({Key? key, @required this.vehicle, this.fun})
      : super(key: key);

  final VehicleModel? vehicle;
  final Function()? fun;

  @override
  Widget build(BuildContext context) {
    return Container(
      margin: EdgeInsets.only(
        right: 15,
        bottom: 10,
        left: 15,
      ),
      padding: EdgeInsets.fromLTRB(
        5,
        20,
        15,
        20,
      ),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.only(
          topRight: Radius.circular(10),
          bottomRight: Radius.circular(10),
        ),
      ),
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            mainAxisSize: MainAxisSize.min,
            children: [
              Hero(
                tag: vehicle!.vehicleId!.toString(),
                child: CachedImage(
                  imgUrl: vehicle!.photo!,
                  height: 95,
                  isGallery: false,
                  width: 148,
                  vehicleId: vehicle!.vehicleId.toString(),
                ),
              ),
              sb(24),
              Expanded(
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Row(
                      children: [
                        Expanded(
                          child: Text(
                            vehicle!.vehicleName!,
                            maxLines: 1,
                            overflow: TextOverflow.ellipsis,
                            style: TextStyle(
                              fontWeight: FontWeight.w500,
                              fontSize: 14,
                            ),
                          ),
                        ),
                        InkWell(
                          // onTap: () {
                          //   dialogBoxDetail(context, vehicle!);
                          // },
                          child: Icon(
                            Icons.info_outline,
                            color: secondaryColor,
                            size: 16,
                          ),
                        ),
                      ],
                    ),
                    sh(10),
                    Row(
                      mainAxisAlignment: MainAxisAlignment.end,
                      children: [
                        Text(
                          'Cijena po km:',
                          textAlign: TextAlign.center,
                          style: TextStyle(
                            fontSize: 12,
                            color: Color(0xff3f3d56),
                          ),
                        ),
                        Padding(
                          padding: const EdgeInsets.only(left: 8.0),
                          child: Text(
                            vehicle!.price!.toString() + ' KM',
                            textAlign: TextAlign.center,
                            style: TextStyle(
                              fontSize: 12,
                              fontWeight: FontWeight.w700,
                              color: Color(0xffa7a7a7),
                            ),
                          ),
                        ),
                      ],
                    ),
                    sh(3),
                    sh(11),
                    CustomButton(
                      label: 'Book now',
                      vertPad: 10,
                      onPressed: this.fun,
                    ),
                  ],
                ),
              )
            ],
          ),
        ],
      ),
    );
  }
}
