import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/user_model.dart';
import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:flutter/animation.dart';
import 'package:http/http.dart';
import 'package:jwt_decode/jwt_decode.dart';

class UserServices {
  static Future loginService(data) async {
    Response res =
        await ApiModels().postRequest(url: 'api/Auth/login', data: data);
    if (res.statusCode == 200) {
      var decoded = jsonDecode(res.body);
      var token = decoded['token'];
      AuthProvider.instance.setToken(token);
      var userDecoded = await getUser(decoded['id']);
      inspect(userDecoded);
      AuthProvider.instance.setUser(Userinfo.fromJson(userDecoded));
    } else {
      throw jsonDecode(res.body)["title"];
    }

    return res;
  }

  static Future postMaliciousUser(data) async {
    Response res =
        await ApiModels().postRequest(url: 'api/MaliciousUser', data: data);
    if (res.statusCode == 200) {
      return res;
    } else {
      throw jsonDecode(res.body)["title"];
    }
  }

  static Future removeMaliciousUser(data) async {
    Response res =
        await ApiModels().putRequest(url: 'api/MaliciousUser', data: data);
    if (res.statusCode == 200) {
      return res;
    } else {
      throw jsonDecode(res.body)["title"];
    }
  }

  static Future getMaliciousUser(
      {Map<String, dynamic>? queryParams = const {}}) async {
    Response res = await ApiModels()
        .getRequest(url: 'api/MaliciousUser', queryParams: queryParams);
    if (res.statusCode == 200) {
      var decoded = jsonDecode(res.body);
      inspect(res);

      return decoded;
    } else {
      throw jsonDecode(res.body)["title"];
    }
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
    inspect(res);
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
      }
    } catch (e) {
      throw e;
    }
    return users;
  }

  static Future updateUser(data) async {
    try {
      Response res = await ApiModels().putRequest(url: 'api/User', data: data);
      inspect(res);
      if (res.statusCode != 200 && res.statusCode != 204)
        throw jsonDecode(res.body)['title'];
    } catch (e) {
      throw e;
    }
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

  static Future addFavoriteCompany(VehicleModel vehicle) async {
    if (vehicle.companyId == null || vehicle.companyId == 0)
      throw "Nije moguce dodati vozilo bez kompanije";

    var dataToSend = {
      "userId": AuthProvider.instance.user!.id,
      "companyId": vehicle.companyId,
    };
    try {
      Response res =
          await ApiModels().postRequest(url: 'api/Favorite', data: dataToSend);
      inspect(res);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      } else {
        throw jsonDecode(res.body)['title'];
      }
    } catch (e) {
      throw e;
    }
  }

  static Future deleteFavoriteCompany(int favoriteId) async {
    if (favoriteId == 0) throw "Nije moguce izbrisati favorita";

    var dataToSend = {
      "Id": favoriteId,
    };
    try {
      Response res = await ApiModels()
          .deleteRequest(url: 'api/Favorite/$favoriteId', data: dataToSend);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      } else {
        throw jsonDecode(res.body)['title'];
      }
    } catch (e) {
      throw e;
    }
  }
}
