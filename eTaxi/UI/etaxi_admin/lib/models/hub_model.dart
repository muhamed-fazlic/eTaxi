class Hub {
  int id;
  String name;
  String address;
  String city;
  double latitude;
  double longitude;

  Hub(
      {required this.id,
      required this.name,
      required this.address,
      required this.city,
      required this.latitude,
      required this.longitude});

  factory Hub.fromJson(Map<dynamic, dynamic> json) {
    return Hub(
        id: json['HubId'],
        name: json['Name'],
        address: json['Address'],
        city: json['City'],
        latitude: double.tryParse(json['Latitude']) ?? 0,
        longitude: double.tryParse(json['Longitude']) ?? 0);
  }
}
