import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/cached_image.dart';
import 'package:flutter/material.dart';

class SwipeCar extends StatefulWidget {
  final String vehicleId;
  final String imgUrl;
  final bool isBorder;
  const SwipeCar({
    Key? key,
    required this.imgUrl,
    required this.vehicleId,
    this.isBorder = true,
  }) : super(key: key);

  @override
  _SwipeCarState createState() => _SwipeCarState();
}

class _SwipeCarState extends State<SwipeCar> {
  @override
  void initState() {
    super.initState();
  }

  PageController pageController = PageController(initialPage: 0);
  int indexSelect = 0;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return Container(
      height: h * 140,
      alignment: Alignment.center,
      width: SizeConfig.screenWidth,
      padding: EdgeInsets.symmetric(vertical: h * 10),
      margin: EdgeInsets.symmetric(horizontal: widget.isBorder ? b * 15 : 0),
      decoration: widget.isBorder
          ? BoxDecoration(
              borderRadius: BorderRadius.circular(b * 4),
              border: Border.all(
                color: Color(0xfff2f2f2),
              ),
            )
          : BoxDecoration(),
      child: PageView.builder(
        controller: pageController,
        itemCount: 1,
        itemBuilder: (context, index) {
          return Hero(
            tag: widget.vehicleId.toString(),
            child: Padding(
              padding: EdgeInsets.symmetric(horizontal: b * 10),
              child: CachedImage(
                imgUrl: widget.imgUrl,
                height: h * 1200,
                width: SizeConfig.screenWidth,
                vehicleId: widget.vehicleId.toString(),
              ),
            ),
          );
        },
        onPageChanged: (index) {
          setState(() {
            indexSelect = index;
          });
        },
      ),
    );
  }
}
