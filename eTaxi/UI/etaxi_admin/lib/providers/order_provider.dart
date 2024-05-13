import 'dart:math';

import 'package:etaxi_admin/models/order_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';
import 'package:flutter/widgets.dart';

import '../models/location_model.dart';

enum PaymentMethod { CASH, ONLINE }

class OrderProvider extends ChangeNotifier {
  //singleton
  static OrderProvider? _instance;
  static OrderProvider get instance {
    if (_instance == null) {
      _instance = OrderProvider._();
    }

    return _instance!;
  }

  OrderProvider._();

  //Taxi order part START
  Location? currentLocationData;
  Location? destinationLocationData;
  double? totalDistance;

  DateTime? startTime;
  VehicleModel? selectedVehicle;
  double? orderPrice;
  PaymentMethod paymentMethod = PaymentMethod.CASH;

  bool isEditOrder = false;
  int? orderId;
  List<Order> orders = [];
  Order? selectedOrder;

  Map<String, dynamic> vehicleFilters = {};
  Map<String, dynamic> orderFilters = {};

  bool resetState = false;

  void setVehicleFilters(Map<String, dynamic> filters) {
    vehicleFilters = filters;
    notifyListeners();
  }

  void setOrderFilters(Map<String, dynamic> filters) {
    orderFilters = filters;
    notifyListeners();
  }

  void setOrderId(int? id) {
    orderId = id;
    notifyListeners();
  }

  void setIsEditOrder(bool value) {
    isEditOrder = value;

    notifyListeners();
  }

  void setOrderPrice(double price, {bool notify = true}) {
    orderPrice = price;
    if (notify) notifyListeners();
  }

  String calculateDistance(Location start, Location end) {
    const double earthRadius = 6371.0; // Radius of the Earth in kilometers

    // Convert coordinates to radians
    final double lat1 = start.latitude! * (pi / 180.0);
    final double lon1 = start.longitude! * (pi / 180.0);
    final double lat2 = end.latitude! * (pi / 180.0);
    final double lon2 = end.longitude! * (pi / 180.0);

    // Calculate the differences between the coordinates
    final double dLat = lat2 - lat1;
    final double dLon = lon2 - lon1;

    // Apply the Haversine formula
    final double a = sin(dLat / 2) * sin(dLat / 2) +
        cos(lat1) * cos(lat2) * sin(dLon / 2) * sin(dLon / 2);
    final double c = 2 * atan2(sqrt(a), sqrt(1 - a));
    final double distance = earthRadius * c;

    totalDistance = double.parse(distance.toStringAsFixed(2));
    return distance.toStringAsFixed(
        2); // Distance in kilometers, add "*1000" to get meters
  }

  String calculateTotalPrice() {
    double total = 0;
    if (totalDistance != null) {
      total = totalDistance! * selectedVehicle!.price!;
    }

    var totalString = total.toStringAsFixed(2);
    setOrderPrice(double.parse(totalString), notify: false);
    return "$totalString BAM";
  }

  void setStartTime(DateTime? time) {
    startTime = time;
    notifyListeners();
  }

  void setPaymentMethod(PaymentMethod method) {
    paymentMethod = method;
    notifyListeners();
  }

  Future setCurrentLoc(Location loc) async {
    currentLocationData = loc;

    notifyListeners();
  }

  Future setSelectedVehicle(VehicleModel veh) async {
    selectedVehicle = veh;

    notifyListeners();
  }

  Future setDestinationLoc(Location loc) async {
    destinationLocationData = loc;

    notifyListeners();
  }

  void resetStateFunction() {
    resetState = !resetState;
    notifyListeners();
  }

  void resetToInit([bool shouldNotify = false]) {
    destinationLocationData = null;
    currentLocationData = null;

    paymentMethod = PaymentMethod.CASH;
    selectedVehicle = null;
    orderPrice = null;
    totalDistance = null;
    orderFilters = {};
    startTime = null;
    isEditOrder = false;

    orderId = null;

    if (shouldNotify) notifyListeners();
  }

  //Taxi order part END
}
