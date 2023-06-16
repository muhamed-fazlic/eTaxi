import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class CongratulationsPage extends StatelessWidget {
  const CongratulationsPage({
    Key? key,
  }) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      body: SafeArea(
        child: Container(
          child: Column(
            children: [
              Expanded(
                child: Container(
                  padding: EdgeInsets.symmetric(horizontal: 30),
                  child: Column(
                    children: [
                      sh(140),
                      Text(
                        'Cestitamo',
                        style: TextStyle(
                          fontSize: 24,
                          fontWeight: FontWeight.w700,
                          color: Color(0xff484848),
                        ),
                      ),
                      sh(54),
                      Image.asset(
                        'assets/images/congo_illus.png',
                        height: 160,
                        width: 295,
                      ),
                      sh(39),
                      Text(
                        'Vasa narudzba je uspjesno primljena',
                        textAlign: TextAlign.center,
                        style: TextStyle(
                          color: Color(0xff666666),
                          fontSize: 16,
                        ),
                      ),
                      sh(12),
                      Text(
                        'Hvala vam',
                        textAlign: TextAlign.center,
                        style: TextStyle(
                          fontWeight: FontWeight.w700,
                          fontSize: 24,
                          color: primaryColor,
                        ),
                      ),
                      sh(30),
                      MaterialButton(
                        height: 40,
                        minWidth: double.infinity,
                        color: Colors.black,
                        onPressed: () {
                          Navigator.popUntil(context, (route) => route.isFirst);
                        },
                        child: Text(
                          'Nastavi'.toUpperCase(),
                          style: TextStyle(
                              color: Colors.white, fontWeight: FontWeight.w700),
                        ),
                      ),
                    ],
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
