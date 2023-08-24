import 'dart:developer';

import 'package:open_street_map_search_and_pick/open_street_map_search_and_pick.dart';

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

  factory Location.fromPickedData(PickedData data) {
    return Location(
      latitude: data.latLong.latitude,
      longitude: data.latLong.longitude,
      address: data.addressName,
      city: data.address['city'],
      country: data.address['country'],
      postalCode: data.address['postcode'],
      streetName: data.address['road'],
      streetNumber: data.address['house_number'],
    );
  }
}
