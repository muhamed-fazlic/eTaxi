class VehicleType {
  int? vehicleTypeId;
  String? name;
  int? seats;
  String? icon;

  VehicleType({this.vehicleTypeId, this.name, this.seats, this.icon});

  VehicleType.fromJson(Map<String, dynamic> json) {
    vehicleTypeId = json['VehicleTypeId'];
    name = json['Type'];
    seats = json['NumberOfSeats'];
    icon = json['File'];
  }
}
