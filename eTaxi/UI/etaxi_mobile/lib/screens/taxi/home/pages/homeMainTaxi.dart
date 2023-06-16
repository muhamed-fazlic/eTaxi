import 'package:etaxi_mobile/screens/commonPages/trackCarPage.dart';
import 'package:etaxi_mobile/screens/settings.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/homeTaxi.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/myTripPage.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';

class HomeMainTaxi extends StatefulWidget {
  final int index;

  const HomeMainTaxi({Key? key, this.index = 0}) : super(key: key);
  @override
  _HomeMainTaxiState createState() => _HomeMainTaxiState();
}

class _HomeMainTaxiState extends State<HomeMainTaxi> {
  int _index = 0;

  @override
  void initState() {
    _index = widget.index;
    super.initState();
  }

  List<String> _menuIcons = [
    'assets/icons/home.svg',
    //  'assets/icons/location.svg',
    'assets/icons/history.svg',
    'assets/icons/settings.svg',
  ];
  @override
  Widget build(BuildContext context) {
    List<Widget> _screens = [
      HomeTaxi(),
      //  TrackCarPage(),
      MyTripPage(),
      Settings(
        isTaxi: true,
      )
    ];

    return Scaffold(
      bottomNavigationBar: Container(
        height: 80,
        child: BottomNavigationBar(
          backgroundColor: Colors.white,
          type: BottomNavigationBarType.fixed,
          showSelectedLabels: false,
          showUnselectedLabels: false,
          selectedFontSize: 0,
          unselectedFontSize: 0,
          selectedIconTheme: IconThemeData(size: 20),
          currentIndex: _index,
          items: _menuIcons.map((e) {
            return BottomNavigationBarItem(
              icon: SvgPicture.asset(
                e,
                color: Color(0xffcccccc),
              ),
              activeIcon: SvgPicture.asset(
                e,
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
      body: _screens[_index],
    );
  }
}
