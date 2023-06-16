import 'dart:developer';

import 'package:etaxi_mobile/models/directions_model.dart';
import 'package:etaxi_mobile/models/location_model.dart';
import 'package:etaxi_mobile/models/order_model.dart';
import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/screens/taxi/widgets/googleMapWidget.dart';
import 'package:etaxi_mobile/services/directions_services.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_credit_card/credit_card_model.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

enum BookingStage { PICKUP, DESTINATION, VEHICLES, RIDE_BOOKED }

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

  bool resetState = false;

  //Taxi order part START
  Location? currentLocationData;
  Location? destinationLocationData;
  Directions? directions;

  DateTime? startTime;
  VehicleModel? selectedVehicle;
  double? orderPrice;
  PaymentMethod paymentMethod = PaymentMethod.CASH;
  CreditCardModel? creditCardModel;

  BookingStage stage = BookingStage.PICKUP;

  bool isEditOrder = false;
  int? orderId;
  List<Order> orders = [];
  Order? selectedOrder;

  Map<String, dynamic> vehicleFilters = {};

  void setVehicleFilters(Map<String, dynamic> filters) {
    vehicleFilters = filters;
    notifyListeners();
  }

  void resetStateFunction() {
    resetState = !resetState;
    notifyListeners();
  }

  void setSelectedOrder(Order order) async {
    //this method is used when viewing order list and clicking on one of the orders
    //it sets all the data from that order to OrderProvider, so we can edit it if needed
    selectedOrder = order;
    orderId = order.id;
    startTime = order.startTime;
    selectedVehicle = order.vehicle;
    orderPrice = order.price;
    paymentMethod = order.paymentMethod == 'Gotovina'
        ? PaymentMethod.CASH
        : PaymentMethod.ONLINE;
    destinationLocationData = order.endLocation;
    currentLocationData = order.startLocation;
    Directions? dir = await DirectionServices().getDirections(
        origin: LatLng(
            order.startLocation!.latitude!, order.startLocation!.longitude!),
        dest: LatLng(
            order.endLocation!.latitude!, order.endLocation!.longitude!));

    if (dir != null) await setDirections(dir);
    stage = BookingStage.RIDE_BOOKED;
    notifyListeners();
  }

  void setCreditCardModel(CreditCardModel? model) {
    creditCardModel = model;
    notifyListeners();
  }

  void setOrderId(int? id) {
    orderId = id;
    notifyListeners();
  }

  void setIsEditOrder(bool value) {
    isEditOrder = value;
    if (value == true) setBookingStage(BookingStage.PICKUP);
    notifyListeners();
  }

  void setOrderPrice(double price, {bool notify = true}) {
    orderPrice = price;
    if (notify) notifyListeners();
  }

  void setStartTime(DateTime? time) {
    startTime = time;
    notifyListeners();
  }

  void setOrders(List<Order> ordersData) {
    orders = ordersData;
    notifyListeners();
  }

  void setSelectedVehicle(VehicleModel vehicle) {
    selectedVehicle = vehicle;
    notifyListeners();
  }

  void setPaymentMethod(PaymentMethod method) {
    paymentMethod = method;
    notifyListeners();
  }

  String calculateTotalPrice() {
    double total = 0;
    if (directions != null) {
      //parse total distance from directions into double number
      double distanceNumber = double.tryParse(directions!.totalDistance!
              .substring(0, directions!.totalDistance!.indexOf("km"))) ??
          1;
      total = distanceNumber * selectedVehicle!.price!;
    }
    double roundedTotal = double.parse(total.toStringAsFixed(2));
    setOrderPrice(roundedTotal, notify: false);
    return roundedTotal.toString() + " BAM";
  }

  void setBookingStage(BookingStage stage) {
    this.stage = stage;
    notifyListeners();
  }

  Future setCurrentLoc(Location loc) async {
    currentLocationData = loc;
    await mapController?.animateCamera(CameraUpdate.newCameraPosition(
        CameraPosition(
            target: LatLng(loc.latitude!, loc.longitude!), zoom: 15)));
    notifyListeners();
  }

  Future setDestinationLoc(Location loc) async {
    destinationLocationData = loc;
    await mapController?.animateCamera(CameraUpdate.newCameraPosition(
        CameraPosition(
            target: LatLng(loc.latitude!, loc.longitude!), zoom: 15)));

    notifyListeners();
  }

  Future setDirections(Directions dir) async {
    directions = dir;
    await mapController?.animateCamera(
      CameraUpdate.newLatLngBounds(directions!.bounds!, 100),
    );
    notifyListeners();
  }

  void resetToInit([bool shouldNotify = false]) {
    stage = BookingStage.PICKUP;

    destinationLocationData = null;
    currentLocationData = null;
    directions = null;
    paymentMethod = PaymentMethod.CASH;
    selectedVehicle = null;
    orderPrice = null;
    DateTime? startTime = null;
    isEditOrder = false;
    creditCardModel = null;
    orderId = null;
    selectedOrder = null;

    if (shouldNotify) notifyListeners();
  }

  //Taxi order part END

}
