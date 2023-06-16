import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class OrderFilters extends StatefulWidget {
  OrderFilters({Key? key, Function()? onSubmit}) : super(key: key);

  @override
  State<OrderFilters> createState() => _OrderFiltersState();
}

class _OrderFiltersState extends State<OrderFilters> {
  void Function()? onSubmit;

  String? selectedPaymentMethod;
  bool? isActive;
  bool? isCanceled;
  String? statusValue;

  @override
  Widget build(BuildContext context) {
    return Container(
      height: 200,
      width: 500,
      child: Column(
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
          DropdownButtonFormField<String>(
            value: selectedPaymentMethod,
            items: [
              DropdownMenuItem(
                child: Text('Gotovina'),
                value: 'Gotovina',
              ),
              DropdownMenuItem(
                child: Text('Online'),
                value: 'Online',
              ),
            ],
            decoration: InputDecoration(
              labelText: 'Nacin placanja',
            ),
            onChanged: (value) {
              setState(() {
                selectedPaymentMethod = value!;
              });
            },
          ),
          sh(10),
          Row(
            children: [
              if (isActive != null ||
                  isCanceled != null ||
                  selectedPaymentMethod != null)
                MaterialButton(
                    child: Text("Ocisti"),
                    height: 50,
                    onPressed: () {
                      setState(() {
                        isActive = null;
                        isCanceled = null;
                        selectedPaymentMethod = null;
                        statusValue = null;
                      });
                      Map<String, dynamic> filters = {};
                      if (AuthProvider.instance.user!.companyId != null)
                        filters['CompanyId'] =
                            AuthProvider.instance.user!.companyId.toString();

                      OrderProvider.instance.setOrderFilters(filters);
                    }),
              sb(5),
              MaterialButton(
                  child:
                      Text("Primjeni", style: TextStyle(color: Colors.white)),
                  color: Colors.black,
                  minWidth: 100,
                  height: 50,
                  onPressed: () {
                    Map<String, dynamic> filters = {};

                    if (isActive != null)
                      filters['IsActive'] = isActive.toString();
                    if (isCanceled != null)
                      filters['IsCanceled'] = isCanceled.toString();
                    if (selectedPaymentMethod != null)
                      filters['PaymentMethod'] = selectedPaymentMethod;
                    if (AuthProvider.instance.user!.companyId != null)
                      filters['CompanyId'] =
                          AuthProvider.instance.user!.companyId.toString();

                    OrderProvider.instance.setOrderFilters(filters);
                  }),
            ],
          )
        ],
      ),
    );
  }
}
