import 'dart:developer';

import 'package:flutter/cupertino.dart';
import 'package:etaxi_mobile/models/user_model.dart';

class AuthProvider extends ChangeNotifier {
  //singleton
  static AuthProvider? _instance;
  static AuthProvider get instance {
    if (_instance == null) {
      _instance = AuthProvider._();
    }

    return _instance!;
  }

  AuthProvider._();
  AuthProvider._internal();

  String? token;
  String? loginError;
  String? registerError;
  Userinfo? _user;
  Userinfo? get user => _user;

  void setUser(Userinfo? usr) {
    _user = usr;
    notifyListeners();
  }

  setError(err, String type) {
    if (type == 'login') {
      loginError = err;
    } else if (type == 'register') {
      registerError = err;
    }
    notifyListeners();
  }

  setToken(userToken) {
    token = userToken;
    notifyListeners();
  }

  reset() {
    _user = null;
    token = null;
    loginError = null;
    registerError = null;
  }
}
