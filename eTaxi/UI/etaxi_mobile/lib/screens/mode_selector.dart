import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/self%20drive/bottomNavSelfDrive.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/homeMainTaxi.dart';
import 'package:etaxi_mobile/screens/todoPregled.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:flutter/material.dart';

import '../utils/colors.dart';

class ModeSelectorScreen extends StatefulWidget {
  const ModeSelectorScreen({Key? key}) : super(key: key);

  @override
  State<ModeSelectorScreen> createState() => _ModeSelectorScreenState();
}

class _ModeSelectorScreenState extends State<ModeSelectorScreen> {
  bool isSelf = false;
  bool isTaxi = false;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);

    return Scaffold(
      backgroundColor: Colors.white,
      body: SafeArea(
        child: Container(
          alignment: Alignment.center,
          child: Column(
            children: [
              sh(80),
              ClipRRect(
                  borderRadius: BorderRadius.circular(10),
                  child: Image.asset(
                    'assets/logo/logo.png',
                    width: 155,
                    fit: BoxFit.contain,
                  )),
              sh(60),
              Text(
                'Izaberi opciju',
                style: TextStyle(
                  fontWeight: FontWeight.w600,
                  fontSize: 24,
                ),
              ),
              sh(16),
              Text(
                'Koju opciju zelite izabrati?',
                style: TextStyle(
                  fontSize: 12,
                ),
              ),
              sh(31),
              CustomButton(
                label: "Pregled ToDo liste",
                width: 250,
                onPressed: () {
                  Navigator.of(context)
                      .push(MaterialPageRoute(builder: (_) => ToDoPage()));
                },
              ),
              sh(31),
              InkWell(
                highlightColor: Colors.transparent,
                splashColor: Colors.transparent,
                onTap: () {
                  return appSnackBar(
                      context: context,
                      msg:
                          "Ovaj dio nije uradjen. Seminarski je radjen u grupi",
                      isError: true);
                  setState(() {
                    isSelf = true;
                    isTaxi = false;
                  });

                  Future.delayed(Duration(milliseconds: 20), () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (_) => BottomNavSelfDrive(),
                      ),
                    );
                  });
                },
                child: Container(
                  decoration: BoxDecoration(
                    color: isSelf ? primaryColor : Color(0xfff9f9f9),
                    borderRadius: BorderRadius.circular(4),
                  ),
                  height: 122,
                  width: 140,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Image.asset(
                        'assets/icons/self_drive.png',
                        width: 61,
                        height: 61,
                      ),
                      sh(12),
                      Text(
                        'Self drive vozilo',
                        style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.w500,
                        ),
                      )
                    ],
                  ),
                ),
              ),
              sh(20),
              InkWell(
                highlightColor: Colors.transparent,
                splashColor: Colors.transparent,
                onTap: () {
                  setState(() {
                    isSelf = false;
                    isTaxi = true;
                  });
                  OrderProvider.instance.resetToInit();
                  Future.delayed(Duration(milliseconds: 20), () {
                    Navigator.of(context).push(
                      MaterialPageRoute(
                        builder: (_) => HomeMainTaxi(),
                      ),
                    );
                  });
                },
                child: Container(
                  decoration: BoxDecoration(
                    color: isTaxi ? primaryColor : Color(0xfff9f9f9),
                    borderRadius: BorderRadius.circular(4),
                  ),
                  height: 122,
                  width: 140,
                  child: Column(
                    mainAxisAlignment: MainAxisAlignment.center,
                    children: [
                      Image.asset(
                        'assets/icons/taxi.png',
                        width: 61,
                        height: 61,
                      ),
                      sh(12),
                      Text(
                        "Taxi",
                        style: TextStyle(
                          fontSize: 18,
                          fontWeight: FontWeight.w500,
                        ),
                      )
                    ],
                  ),
                ),
              ),
            ],
          ),
        ),
      ),
    );
  }
}
