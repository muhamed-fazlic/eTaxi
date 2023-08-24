import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/services/user_service.dart';
import 'package:flutter/cupertino.dart';

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

  bool resetState = false;

  String? token;
  UserType? userType;
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
      loginError = err.toString();
    } else if (type == 'register') {
      registerError = err;
    }
    notifyListeners();
  }

  setToken(userToken) {
    token = userToken;
    notifyListeners();
  }

  setUserType(userTyp) {
    userType = userTyp;
    notifyListeners();
  }

  void resetStateFunction() {
    resetState = !resetState;
    notifyListeners();
  }

  reset() {
    _user = null;
    token = null;
    loginError = null;
    registerError = null;
    userType = null;
  }
}
