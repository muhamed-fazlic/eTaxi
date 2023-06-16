import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class VehicleTags extends StatelessWidget {
  const VehicleTags({Key? key, @required this.txt, this.size})
      : super(key: key);

  final String? txt;
  final double? size;
  @override
  Widget build(BuildContext context) {
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return Container(
      padding: EdgeInsets.symmetric(
        horizontal: b * 9,
        vertical: h * 5,
      ),
      decoration: BoxDecoration(
        color: Color(0xfff2f2f2),
        borderRadius: BorderRadius.circular(11),
      ),
      child: Text(
        txt!,
        style: TextStyle(
          fontSize: size ?? b * 12,
          color: Colors.black.withOpacity(0.8),
        ),
      ),
    );
  }
}
