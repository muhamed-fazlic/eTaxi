import 'dart:developer';

import 'package:etaxi_mobile/models/order_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/services/order_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';
import 'package:flutter_rating_bar/flutter_rating_bar.dart';

class RatingOrderDialog extends StatefulWidget {
  const RatingOrderDialog({super.key, required this.order});
  final Order order;

  @override
  State<RatingOrderDialog> createState() => _RatingOrderDialogState();
}

class _RatingOrderDialogState extends State<RatingOrderDialog> {
  TextEditingController commentController = TextEditingController();
  int grade = 3;
  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Ocijeni narudzbu"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          RatingBar.builder(
            initialRating: grade.toDouble(),
            minRating: 1,
            direction: Axis.horizontal,
            allowHalfRating: false,
            itemCount: 5,
            itemPadding: EdgeInsets.symmetric(horizontal: 4.0),
            itemBuilder: (context, _) => Icon(
              Icons.star,
              color: Colors.amber,
            ),
            onRatingUpdate: (rating) {
              setState(() {
                grade = rating.toInt();
              });
            },
          ),
          sh(10),
          CustomTextField(
            label: "Dodaj komentar",
            controller: commentController,
            minLines: 2,
            maxLines: 4,
          )
        ],
      ),
      actions: [
        TextButton(
          onPressed: () {
            Navigator.of(context).pop();
          },
          child: Text("Odustani"),
        ),
        TextButton(
          onPressed: () async {
            var data = {
              "userId": AuthProvider.instance.user!.id,
              "userDriverId": widget.order.userDriverId,
              "orderId": widget.order.id,
              "grade": grade,
              "comment": commentController.text
            };

            try {
              await OrderServices.addOrderRating(data);
              appSnackBar(
                  context: context,
                  msg: "Uspjesno dodan rating",
                  isError: false);
            } catch (e) {
              log("ERROR ADDING RATING: $e");
              appSnackBar(
                  context: context,
                  msg: "Greska u dodavanju ratinga",
                  isError: true);
            }

            Navigator.of(context).pop();
          },
          child: Text("Ocijeni"),
        ),
      ],
    );
  }
}
