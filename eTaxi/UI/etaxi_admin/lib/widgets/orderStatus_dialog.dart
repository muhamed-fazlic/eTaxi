import 'dart:developer';

import 'package:etaxi_admin/models/order_model.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/services/order_service.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:flutter/material.dart';

class OrderStatusDialog extends StatefulWidget {
  const OrderStatusDialog({super.key, required this.order});
  final Order order;

  @override
  State<OrderStatusDialog> createState() => _OrderStatusDialogState();
}

class _OrderStatusDialogState extends State<OrderStatusDialog> {
  bool? isActive;
  bool? isCanceled;
  String? statusValue;
  TextEditingController cancelReasonController = TextEditingController();

  @override
  void initState() {
    statusValue = getOrderStatusValue(widget.order);
    cancelReasonController.text = widget.order.cancelReason ?? '';
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title: Text("Promijeni status narudzbe"),
      content: Column(
        mainAxisSize: MainAxisSize.min,
        children: [
          DropdownButtonFormField<String>(
            value: statusValue,
            items: [
              DropdownMenuItem(
                child: Text('Aktivna'),
                value: 'active',
              ),
              DropdownMenuItem(
                child: Text('Zavrsena'),
                value: 'notActive',
              ),
              DropdownMenuItem(
                child: Text('Otkazana'),
                value: 'canceled',
              ),
            ],
            decoration: InputDecoration(
              labelText: 'Status narudzbe',
            ),
            onChanged: (value) {
              setState(() {
                switch (value) {
                  case 'active':
                    isActive = true;
                    isCanceled = null;
                    break;
                  case 'notActive':
                    isActive = false;
                    isCanceled = false;
                    break;
                  case 'canceled':
                    isCanceled = true;
                    isActive = null;
                    break;
                  default:
                }
                statusValue = value;
              });
            },
          ),
          if (statusValue == 'canceled')
            TextFormField(
              decoration: InputDecoration(
                labelText: 'Razlog otkazivanja',
              ),
              controller: cancelReasonController,
            ),
        ],
      ),
      actions: [
        TextButton(
            onPressed: () {
              Navigator.pop(context);
            },
            child: Text("Odustani")),
        TextButton(
            onPressed: () async {
              Map<String, dynamic> data = {
                "orderId": widget.order.id,
              };
              if (isActive != null) data['isActive'] = isActive;
              if (isCanceled != null) {
                data['isCanceled'] = isCanceled;
                data['cancelReason'] = cancelReasonController.text;
              }

              try {
                await OrderService.setOrderStatus(data);
                OrderProvider.instance.resetStateFunction();
                appSnackBar(
                    context: context,
                    msg: "Status uspjeno izmjenjen",
                    isError: false);
              } catch (e) {
                print(e.toString());
              }

              Navigator.pop(context);
            },
            child: Text("Promijeni"))
      ],
    );
  }
}

String getOrderStatusValue(Order order) {
  if (order.isCanceled != null && order.isCanceled == true) return 'canceled';
  if (order.isActive!)
    return 'active';
  else
    return 'notActive';
}
