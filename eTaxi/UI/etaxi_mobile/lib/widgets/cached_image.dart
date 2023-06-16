import 'package:cached_network_image/cached_network_image.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/widgets/gallery_widget.dart';
import 'package:flutter/material.dart';

class CachedImage extends StatelessWidget {
  final String imgUrl;
  final double height;
  final double width;
  final String vehicleId;
  final bool isGallery;

  const CachedImage({
    Key? key,
    required this.imgUrl,
    required this.height,
    required this.width,
    required this.vehicleId,
    this.isGallery = true,
  }) : super(key: key);
  @override
  Widget build(BuildContext context) {
    return Material(
      child: InkWell(
        onTap: () {
          isGallery
              ? Navigator.of(context).push(
                  MaterialPageRoute(
                    builder: (_) => GalleryWidget(
                      imgUrl: this.imgUrl,
                      vehicle_id: this.vehicleId,
                    ),
                  ),
                )
              // ignore: unnecessary_statements
              : null;
        },
        child: CachedNetworkImage(
          imageUrl: imgUrl,
          width: width,
          height: height,
          fit: BoxFit.fitWidth,
          imageBuilder: (context, imageProvider) => Container(
            width: width,
            height: height,
            decoration: BoxDecoration(
              color: secondaryColor,
              borderRadius: BorderRadius.circular(4),
              image: DecorationImage(
                image: imageProvider,
                fit: BoxFit.cover,
              ),
            ),
          ),
        ),
      ),
    );
  }
}
