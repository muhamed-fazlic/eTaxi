class Location {
  int? id;
  String? streetNumber;
  String? streetName;
  String? district;
  String? city;
  String? country;
  String? postalCode;
  double? latitude;
  double? longitude;
  String? address;

  Location({
    this.id,
    this.streetNumber,
    this.streetName,
    this.district,
    this.city,
    this.country,
    this.postalCode,
    this.latitude,
    this.longitude,
    this.address,
  });

  Location.fromJson(Map<String, dynamic> json) {
    id = json['id'] ?? 0;
    streetNumber = json['streetNumber'] ?? '';
    streetName = json['streetName'] ?? ' ';
    district = json['district'] ?? '';
    city = json['city'] ?? '';
    country = json['country'] ?? '';
    postalCode = json['postalCode'] ?? '';
    latitude = json['latitude'] ?? 0.0;
    longitude = json['longitude'] ?? 0.0;
    address = json['address'] ?? '';
  }
}
