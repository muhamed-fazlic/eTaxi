import 'dart:convert';

import 'package:etaxi_mobile/api/api_model.dart';

class ToDoService {
  static Future getTodoList(filters) async {
    try {
      var res =
          await ApiModels().getRequest(url: 'api/ToDo', queryParams: filters);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      }
    } catch (e) {
      throw e;
    }
  }

  static Future addTodoList(data) async {
    try {
      var res = await ApiModels().postRequest(url: 'api/ToDo', data: data);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      }
    } catch (e) {
      throw e;
    }
  }

  static Future updateTodoList(data) async {
    try {
      var res = await ApiModels().putRequest(url: 'api/ToDo', data: data);
      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        return data;
      } else {
        throw jsonDecode(res.body);
      }
    } catch (e) {
      throw e;
    }
  }
}
