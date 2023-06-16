import 'package:etaxi_admin/models/brand_model.dart';
import 'package:etaxi_admin/models/hub_model.dart';
import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:etaxi_admin/models/vehicle_type_model.dart';
import 'package:flutter/widgets.dart';

class MainProvider extends ChangeNotifier {
  //singleton
  static MainProvider? _instance;
  static MainProvider get instance {
    if (_instance == null) {
      _instance = MainProvider._();
    }

    return _instance!;
  }

  MainProvider._();
  MainProvider._internal();

  List<VehicleType> _vehicleType = [];
  List<VehicleType> get vehicleType => [..._vehicleType];

  List<VehicleModel> _availableModel = [];
  List<VehicleModel> get availableModel => [..._availableModel];

  List<Userinfo> _allUsers = [];
  List<Userinfo> get allUsers => [..._allUsers];

  void setAvailableModels(List<VehicleModel> vehicles) {
    _availableModel = vehicles;
  }

  void setVehicleTypes(List<VehicleType> types) {
    _vehicleType = types;
  }

  void setAllUsers(List<Userinfo> users) {
    _allUsers = users;
  }

  void reset() {
    _vehicleType = [];
    _availableModel = [];
    _allUsers = [];
  }
}
