import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/screens/self%20drive/home_page.dart';
import 'package:flutter/material.dart';

import 'package:flutter_svg/svg.dart';

class BottomNavSelfDrive extends StatefulWidget {
  final int index;

  const BottomNavSelfDrive({Key? key, this.index = 0}) : super(key: key);
  @override
  _BottomNavSelfDriveState createState() => _BottomNavSelfDriveState();
}

class _BottomNavSelfDriveState extends State<BottomNavSelfDrive> {
  int _index = 0;

  @override
  void initState() {
    _index = widget.index;
    super.initState();
  }

  final List<NavModel> _menu = [
    NavModel(icon: 'assets/icons/home.svg'),
    NavModel(icon: 'assets/icons/location.svg'),
    // NavModel(icon: 'assets/icons/history.svg'),
    // NavModel(icon: 'assets/icons/settings.svg'),
  ];
  @override
  Widget build(BuildContext context) {
    List<Widget> _screens = [
      HomePage(),
      Container(),
      //  TrackCarPage(),
      // BookingHistory(),
      // Settings(
      //   isTaxi: false,
      // ),
    ];

    return Scaffold(
      bottomNavigationBar: Container(
        height: 85,
        child: BottomNavigationBar(
          backgroundColor: Colors.white,
          type: BottomNavigationBarType.fixed,
          showSelectedLabels: false,
          showUnselectedLabels: false,
          selectedFontSize: 0,
          unselectedFontSize: 0,
          selectedIconTheme: IconThemeData(size: 20),
          currentIndex: _index,
          items: _menu.map((e) {
            return BottomNavigationBarItem(
              icon: SvgPicture.asset(
                e.icon,
                color: Color(0xffcccccc),
              ),
              activeIcon: SvgPicture.asset(
                e.icon,
                color: Colors.black,
              ),
              label: '',
            );
          }).toList(),
          onTap: (menuIndex) {
            setState(() {
              _index = menuIndex;
            });
          },
        ),
      ),
      body: _screens.elementAt(_index),
    );
  }
}

class NavModel {
  String icon;
  NavModel({required this.icon});
}
