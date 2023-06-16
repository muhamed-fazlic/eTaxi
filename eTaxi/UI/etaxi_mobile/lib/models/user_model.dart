import 'dart:ffi';
import 'package:etaxi_mobile/models/favorite_model.dart';
import 'package:etaxi_mobile/models/file_model.dart';
import 'package:flutter/cupertino.dart';

class Userinfo {
  int? id;
  @required
  String? firstName;
  @required
  String? lastName;
  String? userType;
  int? locationId;
  String? userName;
  int? pin;
  String? phoneNumber;
  String? email;
  String? photoUrl;
  List<FileModel>? files;
  List<Favorite>? favorites;
  Map? ratingGrade;

  Userinfo({
    this.id,
    this.userName,
    this.phoneNumber,
    this.email,
    this.photoUrl,
    this.firstName,
    this.lastName,
    this.locationId,
    this.pin,
    this.userType,
    this.files,
    this.favorites,
    this.ratingGrade,
  });

  Userinfo.fromJson(Map<String, dynamic> json) {
    id = json['id'] ?? 0;
    firstName = json['firstName'] ?? '';
    lastName = json['lastName'] ?? '';
    pin = json['pin'] ?? 0;
    email = json['email'] ?? '';
    files = json['files'] != null
        ? (json['files'] as List).map((i) => FileModel.fromJson(i)).toList()
        : null;
    favorites = json['favorites'] != null
        ? (json['favorites'] as List)
            .map((favorite) => Favorite.fromJson(favorite))
            .toList()
        : null;
    phoneNumber = json['phoneNumber'] ?? null;
    ratingGrade = json['ratingGrade'] != null
        ? (json["ratingGrade"] as List).isNotEmpty
            ? json["ratingGrade"][0]
            : null
        : null;
    //userType = json['UserType'];
    //isActive = json['IsActive'];
    //userCreatedTime = DateTime.parse(json['UserCreatedTime']);
    // verifiedAccount = json['VerifiedAccount'] ?? 0;
  }
}
