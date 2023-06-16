import 'package:cached_network_image/cached_network_image.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/screens/commonPages/contactUs.dart';
import 'package:etaxi_mobile/screens/commonPages/profile.dart';
import 'package:etaxi_mobile/screens/login.dart';
import 'package:etaxi_mobile/screens/mode_selector.dart';
import 'package:etaxi_mobile/screens/reset_password.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/flutter_svg.dart';

class Settings extends StatefulWidget {
  final bool isTaxi;

  const Settings({Key? key, required this.isTaxi}) : super(key: key);
  @override
  _SettingsState createState() => _SettingsState();
}

class _SettingsState extends State<Settings> {
  @override
  Widget build(BuildContext context) {
    return Scaffold(
      backgroundColor: primaryColor,
      body: SafeArea(
        child: Column(children: [
          Expanded(
            child: Container(
              color: Colors.white,
              child: Padding(
                padding: const EdgeInsets.symmetric(horizontal: 20),
                child: Column(
                  crossAxisAlignment: CrossAxisAlignment.start,
                  children: [
                    sh(50),
                    SettingsTile(
                        title: 'Profil',
                        icon: 'profile_icon',
                        page: ProfilePage()),
                    sh(21),
                    SettingsTile(
                      title: 'Promjena lozinke',
                      icon: 'tnc_icon',
                      page: ResetPasswordScreen(),
                    ),
                    sh(21),
                    SettingsTile(
                      title: 'Kontakt',
                      icon: 'privacy_icon',
                      page: ContactUs(),
                    ),
                    sh(21),
                    SettingsTile(
                      title: widget.isTaxi
                          ? 'Rezervisi self drive vozile'
                          : 'Rezervisi taxi',
                      icon: 'choose_your_car',
                      page: ModeSelectorScreen(),
                    ),
                    Spacer(),
                    Center(
                      child: MaterialButton(
                        elevation: 0,
                        splashColor: Colors.transparent,
                        padding: EdgeInsets.zero,
                        highlightColor: Colors.transparent,
                        color: Colors.white,
                        shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(5),
                        ),
                        onPressed: () {
                          AuthProvider.instance.reset();
                          Navigator.pushReplacement(
                              context,
                              MaterialPageRoute(
                                  builder: (context) => LoginScreen()));
                        },
                        child: Container(
                          padding: EdgeInsets.symmetric(vertical: 15),
                          decoration: BoxDecoration(
                            border: Border.all(color: primaryColor),
                            borderRadius: BorderRadius.circular(5),
                          ),
                          child: Row(
                            mainAxisAlignment: MainAxisAlignment.center,
                            children: [
                              Icon(Icons.logout_rounded, size: 16),
                              sb(5),
                              Text(
                                'Odjava',
                                style: TextStyle(
                                  fontSize: 12,
                                  fontWeight: FontWeight.w700,
                                ),
                              ),
                            ],
                          ),
                        ),
                      ),
                    ),
                    sh(30),
                  ],
                ),
              ),
            ),
          ),
        ]),
      ),
    );
  }
}

class SettingsTile extends StatelessWidget {
  final String title;
  final String icon;
  final dynamic page;
  final Widget? dialogBox;
  SettingsTile(
      {required this.title, required this.icon, this.page, this.dialogBox});

  @override
  Widget build(BuildContext context) {
    return MaterialButton(
      elevation: 0,
      splashColor: primaryColor,
      padding: EdgeInsets.zero,
      highlightColor: primaryColor,
      color: primaryColor,
      shape: RoundedRectangleBorder(
        borderRadius: BorderRadius.circular(4),
      ),
      onPressed: () {
        if (page != null)
          Navigator.push(
            context,
            MaterialPageRoute(builder: (context) => page),
          );
        else if (dialogBox != null) {
          showDialog(
              context: context,
              builder: (context) {
                return dialogBox!;
              });
        }
      },
      child: Container(
        padding: EdgeInsets.symmetric(vertical: 18),
        decoration: BoxDecoration(
          borderRadius: BorderRadius.circular(4),
        ),
        child: Row(
          children: [
            sb(40),
            SvgPicture.asset(
              'assets/icons/${this.icon}.svg',
              color: Colors.black,
              height: 16,
            ),
            sb(22),
            Text(
              this.title,
              style: TextStyle(
                fontSize: 14,
                fontWeight: FontWeight.w700,
              ),
            ),
          ],
        ),
      ),
    );
  }
}
