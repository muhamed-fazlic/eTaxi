import 'package:flutter/material.dart';

class SizeConfig {
  MediaQueryData _mediaQueryData = MediaQueryData();
  static double screenWidth = 0;
  static double screenHeight = 0;
  static double _safeAreaHorizontal = 0;
  static double _safeAreaVertical = 0;
  static double b = 0;
  static double v = 0;

  void init(BuildContext context) {
    _mediaQueryData = MediaQuery.of(context);
    screenHeight = _mediaQueryData.size.height;
    screenWidth = _mediaQueryData.size.width;
    _safeAreaHorizontal =
        _mediaQueryData.padding.left + _mediaQueryData.padding.right;
    _safeAreaVertical =
        _mediaQueryData.padding.top + _mediaQueryData.padding.bottom;
    b = (screenWidth - _safeAreaHorizontal) / 100;
    v = (screenHeight - _safeAreaVertical) / 100;
  }
}

SizedBox sh(double h) {
  return SizedBox(height: h * SizeConfig.screenHeight / 812);
}

SizedBox sb(double b) {
  return SizedBox(width: b * SizeConfig.screenWidth / 375);
}
