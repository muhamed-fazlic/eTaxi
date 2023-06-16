class VehicleType {
  int? id;
  String? name;
  int? seats;
  String? imageUrl;

  VehicleType({this.id, this.name, this.seats, this.imageUrl});

  VehicleType.fromJson(Map<String, dynamic> json) {
    id = json['id'];
    name = json['type'];
    seats = json['numberOfSeats'];
    imageUrl = json['imageUrl'];
  }
}
