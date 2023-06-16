import 'dart:async';

import 'package:etaxi_admin/screens/login.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class SplashScreen extends StatefulWidget {
  const SplashScreen({super.key});

  @override
  State<SplashScreen> createState() => _SplashScreenState();
}

class _SplashScreenState extends State<SplashScreen> {
  @override
  void initState() {
    Timer(Duration(microseconds: 100), () {
      SizeConfig().init(context);
      Navigator.push(
          context, MaterialPageRoute(builder: (cotnext) => LoginScreen()));
    });

    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold();
  }
}
