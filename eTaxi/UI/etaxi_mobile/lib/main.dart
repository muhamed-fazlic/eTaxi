import 'dart:io';

import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/providers/home_provider.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/login.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class MyHttpOverrides extends HttpOverrides {
  @override
  HttpClient createHttpClient(SecurityContext? context) {
    return super.createHttpClient(context)
      ..badCertificateCallback =
          (X509Certificate cert, String host, int port) => true;
  }
}

void main() {
  HttpOverrides.global = MyHttpOverrides();
  WidgetsFlutterBinding.ensureInitialized();

  runApp(const MyApp());
}

class MyApp extends StatelessWidget {
  const MyApp({super.key});

  // This widget is the root of your application.
  @override
  Widget build(BuildContext context) {
    return MultiProvider(
      providers: [
        ChangeNotifierProvider(create: (_) => AuthProvider.instance),
        ChangeNotifierProvider(create: (_) => HomeProvider.instance),
        ChangeNotifierProvider(create: (_) => OrderProvider.instance),
      ],
      child: MaterialApp(
        title: 'eTaxi',
        theme:
            ThemeData(primarySwatch: colorSwatch, primaryColor: primaryColor),
        home: LoginScreen(),
      ),
    );
  }
}
