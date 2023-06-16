import 'package:etaxi_admin/utils/colors.dart';
import 'package:flutter/material.dart';

appSnackBar(
    {@required BuildContext? context,
    @required String? msg,
    @required bool? isError}) {
  return ScaffoldMessenger.of(context!).showSnackBar(
    SnackBar(
      behavior: SnackBarBehavior.fixed,
      backgroundColor: isError! ? Colors.black : primaryColor,
      content: Text(
        msg!,
        style: TextStyle(
          color: isError ? Colors.white : Colors.black,
        ),
      ),
      duration: Duration(seconds: 2),
    ),
  );
}
