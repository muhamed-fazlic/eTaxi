import 'dart:developer';

import 'package:etaxi_mobile/models/order_model.dart';
import 'package:etaxi_mobile/models/user_model.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/taxi/home/widgets/cancelRideDialog.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';
import 'package:flutter_svg/flutter_svg.dart';

class TaxiRideBooked extends StatelessWidget {
  const TaxiRideBooked({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        AppBar(
          centerTitle: true,
          elevation: 0,
          leading: InkWell(
            onTap: () {
              if (OrderProvider.instance.selectedOrder != null) {
                OrderProvider.instance.resetToInit();
                Navigator.pop(context);
              } else {
                OrderProvider.instance
                    .setBookingStage(BookingStage.DESTINATION);
              }
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
            "Pregled narudzbe",
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
              height: SizeConfig.screenHeight * 0.45,
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
                      child: FutureBuilder(
                          future: UserServices.getUser(OrderProvider
                              .instance.selectedVehicle!.driverId!),
                          builder: (context, snapshot) {
                            if (snapshot.connectionState ==
                                ConnectionState.done) {
                              Userinfo driver =
                                  Userinfo.fromJson(snapshot.data);
                              return Column(
                                mainAxisAlignment: MainAxisAlignment.start,
                                children: [
                                  Center(
                                    child: Text("Podaci o vozacu"),
                                  ),
                                  sh(10),
                                  Row(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.center,
                                      children: [
                                        Expanded(
                                          child: Column(
                                            crossAxisAlignment:
                                                CrossAxisAlignment.end,
                                            children: [
                                              Row(
                                                children: [
                                                  Text("Vozac: "),
                                                  Text(
                                                    '${driver.firstName} ${driver.lastName}',
                                                    style: TextStyle(
                                                        fontWeight:
                                                            FontWeight.w600),
                                                  ),
                                                ],
                                              ),
                                              sh(5),
                                              Row(
                                                children: [
                                                  Text('Status: '),
                                                  Text(
                                                      getOrderStatus(
                                                          OrderProvider.instance
                                                              .selectedOrder),
                                                      style: TextStyle(
                                                          fontWeight:
                                                              FontWeight.w600))
                                                ],
                                              ),
                                            ],
                                          ),
                                        ),
                                        Column(
                                          children: [
                                            Text('Ocjena: ' +
                                                '(${driver.ratingGrade?["count"] ?? 0} ukupno)'),
                                            sh(5),
                                            RatingBar.builder(
                                              initialRating: driver
                                                      .ratingGrade?[
                                                          "ratingGrade"]
                                                      .toDouble() ??
                                                  5,
                                              minRating: 1,
                                              ignoreGestures: true,
                                              direction: Axis.horizontal,
                                              itemCount: 5,
                                              allowHalfRating: true,
                                              itemSize: 20,
                                              itemBuilder: (context, _) => Icon(
                                                Icons.star,
                                                color: Colors.amber,
                                              ),
                                              onRatingUpdate: (val) {},
                                            ),
                                          ],
                                        )
                                      ]),
                                ],
                              );
                            } else
                              return Center(
                                child: CircularProgressIndicator(),
                              );
                          }),
                    ),
                    Center(
                      child: MaterialButton(
                        onPressed: DateTime.now().isAfter(
                                    OrderProvider.instance.startTime ??
                                        DateTime.now()) ||
                                getOrderStatus(
                                        OrderProvider.instance.selectedOrder) ==
                                    "Otkazana"
                            ? null
                            : () {
                                showDialog(
                                    context: context,
                                    builder: ((context) =>
                                        CancelOrderDialog()));
                              },
                        child: Text("Otkazi voznju"),
                        color: warningColor,
                        textColor: Colors.white,
                        disabledColor: Colors.grey,
                      ),
                    ),
                    if (OrderProvider.instance.selectedOrder != null &&
                        OrderProvider.instance.selectedOrder?.cancelReason !=
                            null)
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
                          crossAxisAlignment: CrossAxisAlignment.center,
                          children: [
                            Text("Razlog otkazivanja:"),
                            sh(10),
                            Text(OrderProvider
                                .instance.selectedOrder!.cancelReason!),
                          ],
                        ),
                      ),
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
                              // )
                            ],
                          ),
                        ],
                      ),
                    ),
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
                          bookingDetailsListTab('Pregled narudzbe', ''),
                          line(),
                          sh(8),
                          bookingDetailsListTab('Id narudzbe',
                              OrderProvider.instance.orderId.toString()),
                          bookingDetailsListTab(
                              'Status narudzbe',
                              getOrderStatus(
                                  OrderProvider.instance.selectedOrder)),
                          bookingDetailsListTab(
                              'Naziv vozila',
                              OrderProvider
                                  .instance.selectedVehicle!.vehicleName!),
                          bookingDetailsListTab(
                              'Udaljenost',
                              OrderProvider
                                  .instance.directions!.totalDistance!),
                          bookingDetailsListTab(
                              'Vrijeme pocetka',
                              dateFormat(OrderProvider.instance.startTime ??
                                      DateTime.now()) +
                                  ' ' +
                                  timeFormatDate(
                                      OrderProvider.instance.startTime ??
                                          DateTime.now())),
                          bookingDetailsListTab(
                              'Vrijeme trajanja',
                              OrderProvider
                                  .instance.directions!.totalDuration!),
                          bookingDetailsListTab(
                              'Nacin placanja',
                              OrderProvider.instance.paymentMethod ==
                                      PaymentMethod.CASH
                                  ? 'Gotovina'
                                  : 'Online'),
                          bookingDetailsListTab(
                              'Cijena',
                              OrderProvider.instance.orderPrice.toString() +
                                  ' BAM'),
                          sh(8),
                        ],
                      ),
                    ),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 16, vertical: 16),
                      child: CustomButton(
                        onPressed: () {
                          if (OrderProvider.instance.startTime !=
                              null) if (DateTime
                                  .now()
                              .isAfter(OrderProvider.instance.startTime!)) {
                            return appSnackBar(
                                context: context,
                                msg:
                                    "Ne mozete izmjeniti narudzbu koja je prosla",
                                isError: true);
                          }
                          OrderProvider.instance.setIsEditOrder(true);
                        },
                        label: 'Izmjeni narudzbu',
                      ),
                    ),
                    line(),
                    Padding(
                      padding: const EdgeInsets.symmetric(
                          horizontal: 16, vertical: 16),
                      child: CustomButton(
                        onPressed: () {
                          OrderProvider.instance.resetToInit(true);
                        },
                        label: 'Naruci drugu voznju',
                      ),
                    )
                  ],
                ),
              )),
        ),
      ],
    );
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

String getOrderStatus(Order? order) {
  if (order != null) {
    if (order.isCanceled != null && order.isCanceled == true) return 'Otkazana';
    if (order.isActive!)
      return 'Aktivna';
    else
      return 'Zavrsena';
  } else
    return 'Aktivna';
}
