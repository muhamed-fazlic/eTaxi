import 'dart:convert';
import 'dart:developer';
import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/hub_model.dart';
import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/models/vehicle_type_model.dart';
import 'package:etaxi_mobile/providers/home_provider.dart';
import 'package:http/http.dart';

class HomeService {
  static Future getVehicleTypes() async {
    try {
      Response res = await ApiModels().getRequest(url: 'vehicleType');
      inspect(res);

      if (res.statusCode == 200) {
        List<VehicleType> types = [];
        var data = json.decode(res.body);
        data.forEach((element) {
          types.add(VehicleType.fromJson(element));
        });
        HomeProvider.instance.setVehicleTypes(types);
      }
    } catch (e) {
      print(e);
    }
  }

  static Future<List<VehicleModel>> getVehicles(
      {Map<String, dynamic>? queryParams = const {}}) async {
    List<VehicleModel> vehicles = [];
    try {
      Response res = await ApiModels()
          .getRequest(url: 'api/Vehicle', queryParams: queryParams);

      if (res.statusCode == 200) {
        var data = json.decode(res.body);
        data.forEach((element) {
          vehicles.add(VehicleModel.fromJson(element));
        });
        HomeProvider.instance.setAvailableModels(vehicles);
      }
    } catch (e) {
      print('Error in getSelfDrivingVehicles: $e');
    }
    return vehicles;
  }

  static Future getHubs() async {
    try {
      Response res = await ApiModels().getRequest(url: 'hub');
      inspect(res);

      if (res.statusCode == 200) {
        List<Hub> hubs = [];
        var data = json.decode(res.body);
        data.forEach((element) {
          hubs.add(Hub.fromJson(element));
        });
        HomeProvider.instance.setAllHubs(hubs);
      }
    } catch (e) {
      print(e);
    }
  }
}
