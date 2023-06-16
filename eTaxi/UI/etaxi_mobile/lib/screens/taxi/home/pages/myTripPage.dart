import 'dart:developer';

import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/homeTaxi.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/taxiRideBookedPage.dart';
import 'package:etaxi_mobile/screens/taxi/home/widgets/myTripCard.dart';
import 'package:etaxi_mobile/services/order_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

import 'package:flutter_svg/flutter_svg.dart';

class MyTripPage extends StatefulWidget {
  MyTripPage({Key? key}) : super(key: key);

  @override
  State<MyTripPage> createState() => _MyTripPageState();
}

class _MyTripPageState extends State<MyTripPage> {
  List<String> types = [
    'Sve',
    'Zavrsene',
    'Aktivne',
    'Otkazane',
  ];

  var defaultFilter = {'UserId': AuthProvider.instance.user?.id.toString()};

  late Map<String, dynamic> orderFilter = defaultFilter;

  String label(String title) {
    if (title == 'Neaktivne')
      return "assets/icons/pending.svg";
    else if (title == 'Aktivne')
      return "assets/icons/confirmed.svg";
    else if (title == 'Zavrsene')
      return "assets/icons/completed.svg";
    else if (title == 'Otkazane')
      return "assets/icons/cancelled.svg";
    else if (title == 'Sve') return "assets/icons/all bookings.svg";
    return '';
  }

  void setOrderFilter(String filter) {
    if (filter == 'Zavrsene')
      setState(() {
        orderFilter = {
          ...defaultFilter,
          "IsActive": "false",
          "IsCanceled": "false"
        };
      });
    else if (filter == 'Aktivne')
      setState(() {
        orderFilter = {...defaultFilter, "IsActive": "true"};
      });
    else if (filter == 'Otkazane')
      setState(() {
        orderFilter = {...defaultFilter, "IsCanceled": "true"};
      });
    else if (filter == 'Sve')
      setState(() {
        orderFilter = defaultFilter;
      });
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
          child: Column(
        children: [
          AppBar(
            centerTitle: true,
            elevation: 0,
            leadingWidth: 40,
            leading: Padding(
              padding: const EdgeInsets.only(left: 16.0),
              child: PopupMenuButton<String>(
                padding: EdgeInsets.only(left: 20),
                shape: RoundedRectangleBorder(
                  borderRadius: BorderRadius.circular(4),
                ),
                onSelected: (value) {
                  setOrderFilter(value);
                },
                itemBuilder: (BuildContext context) {
                  return types.map((String choice) {
                    return PopupMenuItem<String>(
                      value: choice,
                      child: Row(
                        children: [
                          SvgPicture.asset(
                            label(choice),
                            width: 16,
                            color: Colors.black,
                          ),
                          sb(26),
                          Text(
                            choice,
                            style: TextStyle(
                              fontSize: 14,
                              color: Colors.black.withOpacity(0.75),
                            ),
                          ),
                        ],
                      ),
                    );
                  }).toList();
                },
                child: SvgPicture.asset(
                  "assets/icons/filter.svg",
                  color: Colors.black,
                  width: 20,
                ),
              ),
            ),
            title: Text(
              "Moje narudžbe",
              style: TextStyle(
                fontSize: 18,
                fontWeight: FontWeight.w700,
              ),
            ),
          ),
          Expanded(
            child: Container(
              width: SizeConfig.screenWidth,
              child: Column(
                crossAxisAlignment: CrossAxisAlignment.start,
                children: [
                  sh(20),
                  Expanded(
                      child: FutureBuilder(
                          future:
                              OrderServices.getOrders(queryParams: orderFilter),
                          builder: (context, snapshot) {
                            if (snapshot.connectionState ==
                                ConnectionState.done) {
                              if (OrderProvider.instance.orders.length == 0)
                                return Center(
                                    child: Text("Nema pronadjenih narudžbi"));
                              return ListView.builder(
                                padding: EdgeInsets.only(top: 10),
                                shrinkWrap: true,
                                itemCount: OrderProvider.instance.orders.length,
                                physics: BouncingScrollPhysics(),
                                itemBuilder: (context, index) {
                                  var order =
                                      OrderProvider.instance.orders[index];
                                  return InkWell(
                                      onTap: () {
                                        OrderProvider.instance
                                            .setSelectedOrder(order);

                                        Navigator.of(context).push(
                                          MaterialPageRoute(
                                            builder: (_) => HomeTaxi(),
                                          ),
                                        );
                                      },
                                      child: MyTripCard(order: order));
                                },
                              );
                            } else
                              return Center(child: CircularProgressIndicator());
                          })),
                ],
              ),
            ),
          )
        ],
      )),
    );
  }
}
