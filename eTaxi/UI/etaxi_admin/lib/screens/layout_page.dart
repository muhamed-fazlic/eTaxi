import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/main_provider.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:etaxi_admin/screens/login.dart';
import 'package:etaxi_admin/screens/main_page.dart';
import 'package:etaxi_admin/screens/orders_page.dart';
import 'package:etaxi_admin/screens/users_page.dart';
import 'package:etaxi_admin/screens/vehicles_page.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class LayoutPageAdmin extends StatefulWidget {
  const LayoutPageAdmin({super.key});

  @override
  State<LayoutPageAdmin> createState() => _LayoutPageAdminState();
}

class _LayoutPageAdminState extends State<LayoutPageAdmin> {
  int _currentIndex = 0;

  final sidebarItems = ['Pregled', 'Narudzbe', 'Vozila', "Korisnici"];

  final sidebarScreens = [
    MainPageAdmin(),
    OrdersPage(),
    VehiclesPage(),
    UsersPage()
  ];
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      // appBar: AppBar(
      //   title: Text('Main page'),
      // ),
      body: Row(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Drawer(
            width: SizeConfig.screenWidth / 6,
            child: ListView(
              children: [
                ...sidebarItems.map((
                  e,
                ) =>
                    ListTile(
                      title: Text(e),
                      onTap: () {
                        setState(() {
                          _currentIndex = sidebarItems.indexOf(e);
                        });
                      },
                    )),
                ListTile(
                  title: Text(
                    'Odjavi se',
                    style: TextStyle(color: warningColor),
                  ),
                  onTap: () {
                    AuthProvider.instance.reset();
                    OrderProvider.instance.resetToInit();
                    MainProvider.instance.reset();
                    Navigator.pushReplacement(context,
                        MaterialPageRoute(builder: (context) => LoginScreen()));
                  },
                ),
              ],
            ),
          ),
          Expanded(
            child: Padding(
              padding:
                  const EdgeInsets.symmetric(vertical: 16.0, horizontal: 20),
              child: Container(
                constraints: BoxConstraints(minWidth: 400, minHeight: 400),
                child: sidebarScreens[_currentIndex],
              ),
            ),
          ),
        ],
      ),
    );
  }
}
