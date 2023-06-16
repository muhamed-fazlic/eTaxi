import 'dart:developer';

import 'package:etaxi_admin/models/order_model.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/services/order_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:etaxi_admin/widgets/orderStatus_dialog.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';
import 'package:intl/intl.dart';

class MyTripCard extends StatelessWidget {
  Order order;
  MyTripCard({
    Key? key,
    required this.order,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 450,
      width: 350,
      margin: EdgeInsets.only(right: 15, bottom: 10, left: 15),
      decoration: BoxDecoration(
        color: Colors.white,
        borderRadius: BorderRadius.circular(4),
      ),
      child: Column(
        mainAxisAlignment: MainAxisAlignment.start,
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.end,
            children: [
              sb(10),
              Padding(
                padding: EdgeInsets.only(top: 13),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    Text(
                      "Korisnik: " +
                          (order.user?.firstName ?? 'Nepoznat') +
                          ' ' +
                          (order.user?.lastName ?? ''),
                      style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.w500,
                      ),
                    ),
                    sh(3),
                  ],
                ),
              ),
              Spacer(),
              Container(
                padding: EdgeInsets.symmetric(horizontal: 30, vertical: 7),
                decoration: BoxDecoration(
                  color: tagColor(generateOrderStatus(order)),
                  borderRadius: BorderRadius.only(
                    bottomRight: Radius.circular(5),
                  ),
                ),
                child: Text(
                  generateOrderStatus(order),
                  style: TextStyle(
                    color: Colors.white,
                    fontSize: 14,
                    fontWeight: FontWeight.w500,
                  ),
                ),
              ),
            ],
          ),
          sh(12),
          Container(
            margin: EdgeInsets.symmetric(horizontal: 15),
            color: primaryColor,
            height: 1.5,
            width: SizeConfig.screenWidth,
          ),
          sh(12),
          Container(
            width: SizeConfig.screenWidth,
            margin: EdgeInsets.symmetric(horizontal: 16),
            padding: EdgeInsets.fromLTRB(18, 10, 18, 10),
            decoration: BoxDecoration(
              border: Border.all(color: borderColor),
              borderRadius: BorderRadius.circular(4),
            ),
            child: Column(
              children: [
                Row(
                  children: [
                    Expanded(
                      flex: 3,
                      child: Row(
                        children: [
                          SvgPicture.asset(
                            "assets/icons/calendar.svg",
                            width: 10,
                            color: Colors.black,
                          ),
                          sb(8),
                          Text(
                            'DATUM',
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                        ],
                      ),
                    ),
                    Expanded(
                      flex: 2,
                      child: Row(
                        children: [
                          SvgPicture.asset(
                            "assets/icons/cash.svg",
                            width: 12,
                            color: Colors.black,
                          ),
                          sb(8),
                          Text(
                            "Nacin placanja",
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                sh(10),
                Row(
                  children: [
                    Expanded(
                      flex: 3,
                      child: Row(
                        children: [
                          Text(
                            DateFormat('dd.MM.yyyy').format(order.startTime!),
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                        ],
                      ),
                    ),
                    Expanded(
                      flex: 2,
                      child: Row(
                        children: [
                          Text(
                            order.paymentMethod ?? '',
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                ),
                sh(10),
                Row(
                  children: [
                    Expanded(
                      flex: 3,
                      child: Row(
                        children: [
                          Text(
                            "Vozilo: ",
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                          Text(
                            order.vehicle?.vehicleName ?? '',
                            style: TextStyle(
                              fontSize: 10,
                              letterSpacing: 0.6,
                            ),
                          ),
                        ],
                      ),
                    ),
                  ],
                )
              ],
            ),
          ),
          sh(16),
          Padding(
            padding: EdgeInsets.fromLTRB(16, 0, 16, 0),
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
                      child: Text(
                        order.startLocation?.address ?? '',
                        maxLines: 2,
                        style: TextStyle(
                          fontSize: 12,
                          overflow: TextOverflow.ellipsis,
                        ),
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
                Row(
                  children: [
                    SvgPicture.asset(
                      'assets/icons/choose_city.svg',
                      color: Colors.red,
                      height: 20,
                    ),
                    sb(19),
                    Expanded(
                      child: Text(
                        order.endLocation?.address ?? '',
                        maxLines: 2,
                        style: TextStyle(
                          fontSize: 12,
                          overflow: TextOverflow.ellipsis,
                        ),
                      ),
                    ),
                  ],
                ),
              ],
            ),
          ),
          sh(16),
          Container(
            margin: EdgeInsets.symmetric(horizontal: 15),
            color: primaryColor,
            height: 1.5,
            width: SizeConfig.screenWidth,
          ),
          sh(12),
          Padding(
            padding: EdgeInsets.symmetric(horizontal: 16),
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                Text(
                  "UKUPNO",
                  style: TextStyle(
                    fontSize: 10,
                    letterSpacing: 0.6,
                    color: Colors.black.withOpacity(0.7),
                    fontWeight: FontWeight.w700,
                  ),
                ),
                sh(2),
                Text(
                  "${order.price} BAM",
                  style: TextStyle(
                    fontSize: 18,
                    letterSpacing: 0.6,
                    color: secondaryColor,
                    fontWeight: FontWeight.w700,
                  ),
                ),
              ],
            ),
          ),
          sh(10),
          Padding(
            padding: EdgeInsets.symmetric(horizontal: 10),
            child: Row(
              children: [
                IconButton(
                    onPressed: () {
                      showDialog(
                          context: context,
                          builder: ((context) => OrderStatusDialog(
                                order: order,
                              )));
                    },
                    icon: Icon(Icons.edit_note_sharp)),
                Text("Promijeni status narudzbe"),
                Spacer(),
                IconButton(
                    onPressed: () {
                      showDialog(
                        context: context,
                        builder: (context) => AlertDialog(
                          title: Text('Brisanje narudzbe'),
                          content: Text(
                              'Da li ste sigurni da želite da obrišete ovu narudzbu?'),
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
                                  await OrderService.deleteOrder(order.id!);
                                  OrderProvider.instance.resetStateFunction();
                                  appSnackBar(
                                      context: context,
                                      msg: "Narudzba uspjesno izbrisana",
                                      isError: false);
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
                    icon: Icon(Icons.delete)),
              ],
            ),
          )
        ],
      ),
    );
  }
}

Color tagColor(String type) {
  if (type == 'Otkazana')
    return Color(0xffc22a23);
  else if (type == 'Aktivna')
    return Color(0xff14ce5e);
  // else if (type == "Assigned")
  //   return Color(0xff55a3ff);
  else if (type == "Neaktivna") return secondaryColor;
  return Color(0xff395185);
}

String generateOrderStatus(Order order) {
  if (order.isCanceled == true) {
    return 'Otkazana';
  }
  if (order.isActive != true) {
    return "Zavrsena";
  } else
    return 'Aktivna';
}
