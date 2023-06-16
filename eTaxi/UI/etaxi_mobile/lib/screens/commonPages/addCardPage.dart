import 'dart:developer';

import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/utils/appBar.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:flutter/material.dart';
import 'package:flutter_credit_card/flutter_credit_card.dart';

class AddCardPage extends StatefulWidget {
  @override
  _AddCardPageState createState() => _AddCardPageState();
}

class _AddCardPageState extends State<AddCardPage> {
  GlobalKey<FormState> formKey = GlobalKey<FormState>();

  @override
  Widget build(BuildContext context) {
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;
    return Scaffold(
      appBar: appBarCommon(context, h, b, "Dodaj karticu"),
      body: Container(
        margin: EdgeInsets.symmetric(horizontal: b * 20, vertical: h * 20),
        child: SingleChildScrollView(
          child: Column(
            children: [
              CreditCardWidget(
                cardNumber:
                    OrderProvider.instance.creditCardModel?.cardNumber ?? '',
                expiryDate:
                    OrderProvider.instance.creditCardModel?.expiryDate ?? '',
                cardHolderName:
                    OrderProvider.instance.creditCardModel?.cardHolderName ??
                        '',
                cvvCode: OrderProvider.instance.creditCardModel?.cvvCode ?? '',
                showBackView: false, //true when you want to show cvv(back) view
                onCreditCardWidgetChange: (p0) {
                  print(p0);
                },
              ),
              CreditCardForm(
                formKey: formKey,
                cardNumber:
                    OrderProvider.instance.creditCardModel?.cardNumber ?? '',
                expiryDate:
                    OrderProvider.instance.creditCardModel?.expiryDate ?? '',
                cardHolderName:
                    OrderProvider.instance.creditCardModel?.cardHolderName ??
                        '',
                cvvCode: OrderProvider.instance.creditCardModel?.cvvCode ?? '',
                onCreditCardModelChange: (CreditCardModel data) {
                  OrderProvider.instance.setCreditCardModel(data);
                }, // Required
                themeColor: Colors.red,

                cardNumberDecoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Number',
                  hintText: 'XXXX XXXX XXXX XXXX',
                ),
                expiryDateDecoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Expired Date',
                  hintText: 'XX/XX',
                ),
                cvvCodeDecoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'CVV',
                  hintText: 'XXX',
                ),
                cardHolderDecoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Card Holder',
                ),
              ),
              sh(20),
              CustomButton(
                label: 'Spremi',
                onPressed: () {
                  Navigator.pop(context);
                },
              )
            ],
          ),
        ),
      ),
    );
  }
}
