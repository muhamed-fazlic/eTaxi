import 'dart:developer';
import 'package:etaxi_mobile/models/brand_model.dart';
import 'package:etaxi_mobile/models/city_model.dart';
import 'package:etaxi_mobile/models/hub_model.dart';
import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/models/vehicle_type_model.dart';
import 'package:flutter/widgets.dart';

class HomeProvider extends ChangeNotifier {
  //singleton
  static HomeProvider? _instance;
  static HomeProvider get instance {
    if (_instance == null) {
      _instance = HomeProvider._();
    }

    return _instance!;
  }

  HomeProvider._();
  HomeProvider._internal();

  String? _city;
  String? get city => _city;

  List<City> _cities = [];
  List<City> get cities => [..._cities];

  List<VehicleType> _vehicleType = [];
  List<VehicleType> get vehicleType => [..._vehicleType];

  List<VehicleModel> _availableModel = [];
  List<VehicleModel> get availableModel => [..._availableModel];

  final List<Map<String, List<BrandModel>>> _brandModel = [];
  List<Map<String, List<BrandModel>>> get brandModel => [..._brandModel];

  List<Hub> _allHub = [];
  List<Hub> get allHub => [..._allHub];

  void setAvailableModels(List<VehicleModel> vehicles) {
    _availableModel = vehicles;
  }

  void setVehicleTypes(List<VehicleType> types) {
    _vehicleType = types;
  }

  void setAllHubs(List<Hub> hubs) {
    _allHub = hubs;
  }
}
