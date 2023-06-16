import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_admin/api/api_model.dart';
import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/main_provider.dart';
import 'package:http/http.dart';
import 'package:jwt_decode/jwt_decode.dart';

enum UserType { Admin, User, CompanyAdmin }

class UserServices {
  static Future loginService(data) async {
    Response res =
        await ApiModels().postRequest(url: 'api/Auth/login', data: data);
    if (res.statusCode == 200) {
      var decoded = jsonDecode(res.body);
      var token = decoded['token'];
      var parsedToken = Jwt.parseJwt(token);
      if (!(parsedToken['role'] == UserType.Admin.name ||
          parsedToken['role'] == UserType.CompanyAdmin.name)) {
        throw "Zabranjen pristup";
      }
      AuthProvider.instance.setToken(token);
      var userDecoded = await getUser(decoded['id']);
      AuthProvider.instance.setUser(Userinfo.fromJson(userDecoded));
    } else {
      throw jsonDecode(res.body)["title"];
    }

    return res;
  }

  static Future registerService(data) async {
    Response res =
        await ApiModels().postRequest(url: 'api/Auth/register', data: data);
    if (res.statusCode == 200) {
      var token = jsonDecode(res.body)['Token'];
      AuthProvider.instance.setToken(token);
    } else {
      AuthProvider.instance.setError(jsonDecode(res.body)["title"], 'register');
    }

    return res;
  }

  static Future forgotPassword(data) async {
    Response res = await ApiModels()
        .postRequest(url: 'api/Auth/forgot-password', data: data);
    if (res.statusCode == 200) {
    } else {
      throw Exception('Greska prilikom slanja linka za ponistavanje sifre');
    }
  }

  static Future resetPassword(data) async {
    Response res = await ApiModels()
        .postRequest(url: 'api/Auth/reset-password', data: data);
    if (res.statusCode == 200) {
    } else {
      throw jsonDecode(res.body)['title'];
    }
  }

  static Future getUser(int id) async {
    try {
      Response res = await ApiModels().getRequest(url: 'api/User/$id');
      return jsonDecode(res.body);
    } catch (e) {
      throw e;
    }
  }

  static Future<List<Userinfo>> getAllUser() async {
    List<Userinfo> users = [];
    try {
      Response res = await ApiModels().getRequest(url: 'api/User/');
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        data.forEach((element) {
          users.add(Userinfo.fromJson(element));
        });
        MainProvider.instance.setAllUsers(users);
      }
    } catch (e) {
      throw e;
    }
    return users;
  }

  static Future uploadUserFiles(List<String> filePaths) async {
    try {
      for (var i = 0; i < filePaths.length; i++) {
        await ApiModels().addFile(filePaths[i], AuthProvider.instance.user!.id!,
            type: "Documents");
      }
    } catch (e) {
      throw e;
    }
  }

  static Future addUser(data) async {
    try {
      Response res = await ApiModels().postRequest(url: 'api/User', data: data);
      return jsonDecode(res.body);
    } catch (e) {
      throw e;
    }
  }

  static Future editUser(data) async {
    try {
      await ApiModels().putRequest(url: 'api/User', data: data);
    } catch (e) {
      throw e;
    }
  }

  static Future deleteUser(int id) async {
    try {
      await ApiModels().deleteRequest(url: 'api/User/$id');
    } catch (e) {
      throw e;
    }
  }
}
