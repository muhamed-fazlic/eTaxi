import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/services/order_services.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:flutter/material.dart';

class CancelOrderDialog extends StatelessWidget {
  CancelOrderDialog({super.key});

  TextEditingController _reasonController = TextEditingController();
  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Da li ste sigurni da zelite otkazati voznju?"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          TextField(
            controller: _reasonController,
            decoration: InputDecoration(
              hintText: "Unesite razlog otkazivanja",
              border: OutlineInputBorder(),
            ),
            keyboardType: TextInputType.multiline,
          ),
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
            if (_reasonController.text.isEmpty) {
              return;
            }
            var data = {
              "orderId": OrderProvider.instance.orderId,
              "isActive": false,
              "isCanceled": true,
              "cancelReason": _reasonController.text
            };
            try {
              await OrderServices.cancelOrder(data);
              Navigator.of(context).pop();
              OrderProvider.instance.resetStateFunction();
              return appSnackBar(
                  context: context, msg: "Narudzba otkazana", isError: false);
            } catch (e) {
              Navigator.of(context).pop();

              return appSnackBar(
                  context: context, msg: e.toString(), isError: true);
            }
          },
          child: Text("Otkazi"),
        ),
      ],
    );
  }
}
