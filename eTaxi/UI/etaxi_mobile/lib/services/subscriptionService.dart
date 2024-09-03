import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_mobile/api/api_model.dart';

class SubscriptionService {
  static Future getSubscriptions(queryParams) async {
    try {
      var res = await ApiModels()
          .getRequest(url: 'api/Subscription', queryParams: queryParams);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      }
    } catch (e) {
      throw e;
    }
  }

  static Future addSubscriptions(data) async {
    try {
      var res =
          await ApiModels().postRequest(url: 'api/Subscription', data: data);
      inspect(res);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        inspect(data);
        return data;
      } else {
        throw jsonDecode(res.body);
      }
    } catch (e) {
      throw e;
    }
  }
}
