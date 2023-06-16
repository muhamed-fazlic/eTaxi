import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/screens/commonPages/congratulationsPage.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class CheckoutPage extends StatelessWidget {
  final VehicleModel vehicle;
  CheckoutPage({Key? key, required this.vehicle}) : super(key: key);

  final TextEditingController _promoCodeController = TextEditingController();

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
          child: Column(
        children: [
          Container(
            color: primaryColor,
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                InkWell(
                  onTap: () {
                    Navigator.pop(context);
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
                Spacer(),
                Text(
                  'Checkout',
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.w700,
                  ),
                ),
                Spacer(flex: 2),
              ],
            ),
          ),
          Expanded(
              child: SingleChildScrollView(
            child: Column(
              children: [
                Image.asset(
                  vehicle.photo!,
                  fit: BoxFit.cover,
                  height: 150,
                  width: double.infinity,
                ),
                Padding(
                  padding: const EdgeInsets.symmetric(horizontal: 20),
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      sh(12),
                      Text(
                        vehicle.vehicleName!,
                        style: TextStyle(
                            fontSize: 16, fontWeight: FontWeight.w600),
                      ),
                      sh(8),
                      Text('Self drive vozilo'),
                      sh(12),
                      Row(
                        children: [
                          Expanded(
                            child: TextField(
                              controller: _promoCodeController,
                              decoration:
                                  InputDecoration(hintText: 'Promo kod'),
                            ),
                          ),
                          sb(8),
                          Text('Primjeni',
                              style: TextStyle(
                                  fontSize: 14,
                                  fontWeight: FontWeight.w500,
                                  color: primaryColor))
                        ],
                      ),
                      sh(12),
                      Text('Nacin placanja'),
                      sh(8),
                      Container(
                        decoration: BoxDecoration(
                          borderRadius: BorderRadius.circular(4),
                          color: Colors.black,
                        ),
                        child: Padding(
                          padding: const EdgeInsets.symmetric(
                              vertical: 8.0, horizontal: 16),
                          child: Text(
                            'Online',
                            style: TextStyle(color: Colors.white),
                          ),
                        ),
                      ),
                      sh(22),
                      Container(
                        decoration: BoxDecoration(
                          border: Border.all(width: 1, color: Colors.grey),
                        ),
                        child: Column(
                          children: [
                            Padding(
                              padding: const EdgeInsets.all(12),
                              child: Column(
                                children: [
                                  bookingDetailsListTab('asdasd', '1234'),
                                  bookingDetailsListTab('asdasd', '1234'),
                                  bookingDetailsListTab('asdasd', '1234'),
                                  bookingDetailsListTab('asdasd', '1234'),
                                ],
                              ),
                            ),
                            line(),
                            Padding(
                              padding: const EdgeInsets.all(12),
                              child: Column(
                                children: [
                                  bookingDetailsListTab('TOTAL', '1234'),
                                ],
                              ),
                            ),
                          ],
                        ),
                      ),
                      Padding(
                        padding: const EdgeInsets.symmetric(vertical: 16),
                        child: MaterialButton(
                          height: 40,
                          minWidth: double.infinity,
                          color: Colors.black,
                          onPressed: () {
                            Navigator.pushReplacement(
                                context,
                                MaterialPageRoute(
                                    builder: (context) =>
                                        CongratulationsPage()));
                          },
                          child: Text(
                            'Plati'.toUpperCase(),
                            style: TextStyle(
                                color: Colors.white,
                                fontWeight: FontWeight.w700),
                          ),
                        ),
                      ),
                    ],
                  ),
                )
              ],
            ),
          ))
        ],
      )),
    );
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
}
