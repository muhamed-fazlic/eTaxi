class VehicleModel {
  int? vehicleId;
  int? modelId;
  int? typeId;
  String? photo;
  String? vehicleName;
  double? price;
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
      this.companyName});

  VehicleModel.fromJson(Map<String, dynamic> json) {
    vehicleId = json['id'] ?? 0;
    typeId = json['type'] != null ? json["type"]["typeId"] : 0;
    photo = json['imageUrl'] ?? '';
    vehicleName = json['name'] ?? 'Vozilo';
    price = double.tryParse(json['pricePerKm'].toString()) ?? 100;
    seater = json['type'] != null ? json["type"]["numberOfSeats"] : 5;
    fuelType = json['fuelType'] ?? 'Dizel';
    transmission = json['transmission'] ?? 'Manual';
    year = json['year'] ?? 0;
    airBags = json['airBag'] ?? true;
    brand = json['brand'] ?? '';
    kmTraveled = json['kmTraveled'] ?? 0;
    licenceNumber = json['licenceNumber'] ?? '';
    airCondition = json['airCondition'] ?? true;
    color = json['color'] ?? '';
    driverId = json['userDriverId'] ?? 0;
    companyId = json['companyId'] ?? 0;
    companyName = json['companyName'] ?? "";
  }
}
