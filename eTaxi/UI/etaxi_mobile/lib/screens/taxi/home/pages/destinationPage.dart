import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class DestinationPage extends StatefulWidget {
  const DestinationPage({Key? key}) : super(key: key);

  @override
  _DestinationPageState createState() => _DestinationPageState();
}

class _DestinationPageState extends State<DestinationPage> {
  @override
  Widget build(BuildContext context) {
    return Column(
      children: [
        AppBar(
          centerTitle: true,
          elevation: 0,
          leading: InkWell(
            onTap: () {
              OrderProvider.instance.setBookingStage(BookingStage.PICKUP);
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
            "Destinacija",
            style: TextStyle(
              fontSize: 18,
              fontWeight: FontWeight.w700,
            ),
          ),
        ),
        Expanded(
          child: Stack(
            children: [
              Column(
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
                                    OrderProvider.instance
                                            .destinationLocationData?.address ??
                                        "",
                                    style: TextStyle(
                                      fontSize: 12,
                                    ),
                                  ),
                                ],
                              ),
                            ),
                            // ),
                          ],
                        ),
                      ],
                    ),
                  ),
                  sh(25),
                ],
              ),
              Align(
                alignment: Alignment.bottomCenter,
                child: Padding(
                  padding:
                      const EdgeInsets.symmetric(horizontal: 16, vertical: 16),
                  child: MaterialButton(
                    height: 40,
                    minWidth: double.infinity,
                    color: Colors.black,
                    onPressed: () {
                      OrderProvider.instance
                          .setBookingStage(BookingStage.VEHICLES);
                    },
                    child: Text(
                      'Potvrdi lokaciju'.toUpperCase(),
                      style: TextStyle(
                          color: Colors.white, fontWeight: FontWeight.w700),
                    ),
                  ),
                ),
              ),
            ],
          ),
        )
      ],
    );
  }
}
