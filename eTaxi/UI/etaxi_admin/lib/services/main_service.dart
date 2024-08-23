import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_admin/api/api_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/models/vehicle_type_model.dart';
import 'package:etaxi_admin/providers/main_provider.dart';
import 'package:http/http.dart' as http;

class MainServices {
  static Future<List<VehicleType>> getVehicleTypes() async {
    try {
      http.Response res = await ApiModels().getRequest(url: 'api/VehicleType');
      var decoded = jsonDecode(res.body);
      List<VehicleType> vehicleTypesList = [];
      for (var item in decoded) {
        vehicleTypesList.add(VehicleType.fromJson(item));
      }
      return vehicleTypesList;
    } catch (e) {
      throw e;
    }
  }

  static Future<List<dynamic>> getCompanies() async {
    try {
      http.Response res = await ApiModels().getRequest(url: 'api/Company');
      return jsonDecode(res.body);
    } catch (e) {
      throw e;
    }
  }

  static Future<List<VehicleModel>> getVehicles(
      {Map<String, dynamic>? queryParams = const {}}) async {
    List<VehicleModel> vehicles = [];
    try {
      http.Response res = await ApiModels()
          .getRequest(url: 'api/Vehicle', queryParams: queryParams);

      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        inspect(data);
        data.forEach((element) {
          vehicles.add(VehicleModel.fromJson(element));
        });
        inspect(vehicles);
        MainProvider.instance.setAvailableModels(vehicles);
      }
    } catch (e) {
      print('Error in getSelfDrivingVehicles: $e');
    }
    return vehicles;
  }

  Future addVehicle({required Map data}) async {
    try {
      http.Response res =
          await ApiModels().postRequest(url: 'api/Vehicle', data: data);
      inspect(res);
      if (res.statusCode == 200) {
      } else {
        print(res.body);
        throw res.body;
      }

      return res;
    } catch (e) {
      print('hereee');
      throw e;
    }
  }

  Future editVehicle({required Map data, required int id}) async {
    try {
      http.Response res =
          await ApiModels().putRequest(url: 'api/Vehicle/$id', data: data);
      inspect(res);
      if (res.statusCode == 200) {
      } else {
        throw res.body;
      }

      return res;
    } catch (e) {
      print(e);
      throw e;
    }
  }
//Add vehicle type

  Future addVehicleType({required Map<String, Object> data}) async {
    http.Response res =
        await ApiModels().postRequest(url: 'api/VehicleType', data: data);
    if (res.statusCode == 200) {
    } else {
      print(res.body);
    }

    return res;
  }

  static Future editVehicleType({data, required int id}) async {
    try {
      http.Response res =
          await ApiModels().putRequest(url: 'api/VehicleType/$id', data: data);
      inspect(res);
      return res;
    } catch (e) {
      throw e;
    }
  }

  static Future deleteVehicleType({required int id}) async {
    try {
      http.Response res =
          await ApiModels().deleteRequest(url: 'api/VehicleType/$id');
      inspect(res);
      return res;
    } catch (e) {
      throw e;
    }
  }

  Future deleteVehicle({required int id}) async {
    try {
      http.Response res =
          await ApiModels().deleteRequest(url: 'api/Vehicle/$id');
      inspect(res);
      return res;
    } catch (e) {
      throw e;
    }
  }

  static Future<Map<String, dynamic>> getReport(
      [DateTime? from, DateTime? to, int? companyId]) async {
    try {
      http.Response res =
          await ApiModels().getRequest(url: 'api/Report', queryParams: {
        'StartDate': from?.toIso8601String() ?? null,
        'EndDate': to?.toIso8601String() ?? null,
        'CompanyId': companyId?.toString() ?? null
      });

      return jsonDecode(res.body);
    } catch (e) {
      throw e;
    }
  }

  static Future<String> getLocationFromLatLng(double lat, double long) async {
    try {
      http.Response res = await http.get(Uri.parse(
          'https://maps.googleapis.com/maps/api/geocode/json?latlng=$lat,$long&key=$googleApiKey&language=en'));

      return jsonDecode(res.body)["results"][0]["formatted_address"];
    } catch (e) {
      throw e;
    }
  }
}
