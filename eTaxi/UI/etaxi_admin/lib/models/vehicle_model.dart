import 'package:etaxi_admin/models/vehicle_type_model.dart';

class VehicleModel {
  int? vehicleId;
  int? modelId;
  int? typeId;
  String? photo;
  String? vehicleName;
  int? price;
  int? seater;
  String? fuelType;
  String? transmission;
  int? year;
  bool? airBags;
  String? brand;
  int? kmTraveled;
  String? licenceNumber;
  bool? airCondition;
  String? color;
  int? driverId;
  int? companyId;
  String? companyName;
  VehicleType? type;

  VehicleModel(
      {this.vehicleId,
      this.modelId,
      this.typeId,
      this.photo,
      this.vehicleName,
      this.price,
      this.seater,
      this.fuelType,
      this.transmission,
      this.year,
      this.airBags,
      this.brand,
      this.kmTraveled,
      this.licenceNumber,
      this.airCondition,
      this.color,
      this.driverId,
      this.companyId,
      this.companyName,
      this.type});

  VehicleModel.fromJson(Map<String, dynamic> json) {
    vehicleId = json['id'] ?? 0;
    typeId = json['type']["typeId"] ?? 0;
    photo = json['imageUrl'] ?? '';
    vehicleName = json['name'] ?? 'Vozilo';
    price = json['pricePerKm'] ?? 100;
    seater = json['type']["numberOfSeats"] ?? 5;
    fuelType = json['fuelType'] ?? 'Dizel';
    transmission = json['transmission'] ?? 'Manual';
    year = json['year'] ?? 0;
    airBags = json['airBag'] ?? false;
    brand = json['brand'] ?? '';
    kmTraveled = json['kmTraveled'] ?? 0;
    licenceNumber = json['licenceNumber'] ?? '';
    airCondition = json['airCondition'] ?? false;
    color = json['color'] ?? '';
    driverId = json['userDriverId'] ?? 0;
    companyId = json['companyId'] ?? null;
    companyName = json['companyName'] ?? "";
    type = VehicleType.fromJson(json['type']);
  }
}
