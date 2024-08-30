import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class CustomButton extends StatelessWidget {
  const CustomButton(
      {@required this.label,
      this.width,
      @override this.onPressed,
      this.vertPad,
      this.height});
  final String? label;
  final double? width;
  final double? vertPad;
  final double? height;
  final void Function()? onPressed;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return InkWell(
      onTap: onPressed,
      child: Container(
        width: width ?? SizeConfig.screenWidth,
        height: height ?? h * 45,
        alignment: Alignment.center,
        padding: EdgeInsets.symmetric(
          vertical: vertPad != null ? vertPad! : h * 16,
        ),
        decoration: BoxDecoration(
          color: Colors.black,
          borderRadius: BorderRadius.circular(b * 4),
        ),
        child: Text(
          label!.toUpperCase(),
          style: TextStyle(
            color: Colors.white,
            fontWeight: FontWeight.w700,
            height: 1,
            fontSize: b * 12,
          ),
        ),
      ),
    );
  }
}

class LoadingButton extends StatelessWidget {
  const LoadingButton({Key? key, this.width}) : super(key: key);

  final double? width;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return Container(
      width: SizeConfig.screenWidth,
      alignment: Alignment.center,
      padding: EdgeInsets.symmetric(vertical: h * 12),
      decoration: BoxDecoration(
        color: Colors.grey.shade300,
        borderRadius: BorderRadius.circular(b * 5),
      ),
      child: Text('...'
          //color: secondaryColor,
          //size: b * 20,
          ),
    );
  }
}
