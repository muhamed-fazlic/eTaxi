import 'package:etaxi_admin/models/location_model.dart';
import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/models/vehicle_model.dart';

class Order {
  int? id;
  bool? isActive;
  bool? isCanceled;
  int? userDriverId;
  int? userId;
  Userinfo? user;
  Location? startLocation;
  Location? endLocation;
  VehicleModel? vehicle;
  double? price;
  bool? isSelfDrive;
  DateTime? startTime;
  DateTime? endTime;
  String? paymentMethod;
  String? cancelReason;

  Order(
      {this.id,
      this.isActive,
      this.userDriverId,
      this.userId,
      this.startLocation,
      this.endLocation,
      this.vehicle,
      this.price,
      this.isSelfDrive,
      this.startTime,
      this.endTime,
      this.paymentMethod,
      this.user,
      this.cancelReason,
      this.isCanceled});

  factory Order.fromJson(Map<String, dynamic> json) => Order(
      id: json["id"],
      isActive: json["isActive"],
      userDriverId: json["userDriverId"],
      userId: json["userId"] ?? null,
      startLocation: Location.fromJson(json["startLocation"]),
      endLocation: Location.fromJson(json["endLocation"]),
      vehicle: VehicleModel.fromJson(json["vehicle"]),
      price: double.tryParse(json["price"].toString()) ?? 0.0,
      isSelfDrive: json["isSelfDrive"],
      startTime: DateTime.parse(json["startTime"]),
      endTime: json["endTime"] != null ? DateTime.parse(json["endTime"]) : null,
      paymentMethod: json["paymentMethod"],
      isCanceled: json["isCanceled"],
      cancelReason: json["cancelReason"] ?? null,
      user: json["user"] != null ? Userinfo.fromJson(json["user"]) : null);
}
