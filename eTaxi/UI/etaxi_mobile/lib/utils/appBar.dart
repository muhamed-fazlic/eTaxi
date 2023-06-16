import 'package:etaxi_mobile/utils/colors.dart';
import 'package:flutter/material.dart';

AppBar appBarCommon(BuildContext context, double h, double b, String? txt) {
  return AppBar(
    centerTitle: true,
    elevation: 0,
    leading: InkWell(
      onTap: () {
        Navigator.pop(context);
      },
      child: Padding(
        padding: EdgeInsets.symmetric(
          vertical: h * 22,
          horizontal: b * 20,
        ),
        child: Icon(
          Icons.arrow_back_ios_new_rounded,
          size: b * 18,
        ),
      ),
    ),
    title: Text(
      txt!,
      style: TextStyle(
        fontSize: b * 18,
        fontWeight: FontWeight.w700,
      ),
    ),
    flexibleSpace: Container(
      decoration: BoxDecoration(
        gradient: buttonGradient,
      ),
    ),
  );
}
