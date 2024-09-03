import 'dart:convert';

import 'package:etaxi_mobile/api/api_model.dart';

class MembershipService {
  static Future getAllMembership(queryParams) async {
    try {
      var res = await ApiModels()
          .getRequest(url: 'api/Membership/', queryParams: queryParams);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      }
    } catch (e) {
      throw e;
    }
  }

  static Future addMembership(data) async {
    try {
      var res =
          await ApiModels().postRequest(url: 'api/Membership', data: data);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      }
    } catch (e) {
      throw e;
    }
  }
}
