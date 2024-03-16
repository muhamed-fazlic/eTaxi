import 'package:etaxi_admin/models/order_model.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/services/order_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/my_trip_card.dart';
import 'package:etaxi_admin/widgets/orderFilters.dart';
import 'package:etaxi_admin/widgets/order_dialog.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class OrdersPage extends StatefulWidget {
  const OrdersPage({super.key});

  @override
  State<OrdersPage> createState() => _OrdersPageState();
}

class _OrdersPageState extends State<OrdersPage> {
  bool orderFiltersOpened = false;
  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(crossAxisAlignment: CrossAxisAlignment.start, children: [
        const Padding(
          padding: EdgeInsets.only(bottom: 35.0),
          child: Center(
            child: Text(
              'Narudzbe',
              style: TextStyle(
                fontSize: 36,
              ),
            ),
          ),
        ),
        sh(16),
        Row(
          children: [
            IconButton(
                onPressed: () {
                  showDialog(
                      context: context, builder: (context) => OrderDialog());
                },
                icon: Icon(Icons.add)),
            Text('Kreiraj novu narudzbu')
          ],
        ),
        sh(16),
        Row(
          children: [
            Text(
              "Pregled Narudzbi",
              style: TextStyle(fontSize: 20),
            ),
            sb(20),
            MaterialButton(
              onPressed: () {
                setState(() {});
              },
              child: Text("Osvjezi prikaz"),
              textColor: Colors.white,
              color: primaryColor,
              height: 50,
              minWidth: 180,
            )
          ],
        ),
        sh(16),
        Row(
          children: [
            Text("Filteri"),
            IconButton(
                onPressed: () {
                  setState(() {
                    orderFiltersOpened = !orderFiltersOpened;
                  });
                },
                icon: Icon(Icons.filter_alt)),
          ],
        ),
        if (orderFiltersOpened) OrderFilters(),
        sh(16),
        Consumer<OrderProvider>(
          builder: (context, orderProvider, child) => SizedBox(
            width: SizeConfig.screenWidth * 0.7,
            child: FutureBuilder<List<Order>>(
                future: OrderService.getAllOrders(
                    queryParams: orderProvider.orderFilters),
                builder: (context, snapshot) {
                  if (snapshot.hasData)
                    return snapshot.data!.length == 0
                        ? Center(
                            child: Text(
                            "Nema pronadjenih narudžbi",
                            style: TextStyle(fontSize: 25),
                          ))
                        : Wrap(
                            children: List.generate(
                                snapshot.data!.length,
                                (index) =>
                                    MyTripCard(order: snapshot.data![index])),
                            clipBehavior: Clip.hardEdge,
                          );

                  return Center(
                    child: CircularProgressIndicator(),
                  );
                }),
          ),
        )
      ]),
    );
  }
}
