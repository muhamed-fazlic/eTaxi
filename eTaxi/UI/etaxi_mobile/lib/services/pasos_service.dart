import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_mobile/api/api_model.dart';
import 'package:http/http.dart';

class PasosService {
  static Future getPasosi(
      {Map<String, dynamic>? queryParams = const {}}) async {
    try {
      inspect(queryParams);
      Response res = await ApiModels()
          .getRequest(url: 'api/FITPasos', queryParams: queryParams);
      //inspect(res);
      return jsonDecode(res.body);
    } catch (e) {
      throw e;
    }
  }

  static Future createPasos(data) async {
    try {
      Response res =
          await ApiModels().postRequest(url: 'api/FITPasos', data: data);
      // inspect(res);
      if (res.statusCode != 200 && res.statusCode != 204)
        throw jsonDecode(res.body)['title'];
    } catch (e) {
      throw e;
    }
  }

  static Future updatePasos(data) async {
    try {
      Response res =
          await ApiModels().putRequest(url: 'api/FITPasos', data: data);
      // inspect(res);
      if (res.statusCode != 200 && res.statusCode != 204)
        throw jsonDecode(res.body)['title'];
    } catch (e) {
      throw e;
    }
  }

  static Future deletePasos(int pasosId) async {
    if (pasosId == 0) throw "Nije moguce izbrisati Pasos";

    var dataToSend = {
      "Id": pasosId,
    };
    try {
      Response res = await ApiModels()
          .deleteRequest(url: 'api/FITPasos/$pasosId', data: dataToSend);
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
