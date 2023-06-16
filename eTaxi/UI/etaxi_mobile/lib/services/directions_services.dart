import 'dart:convert';

import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/directions_model.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';

import 'package:http/http.dart' as http;

class DirectionServices {
  Future<Directions?> getDirections({
    required LatLng origin,
    required LatLng dest,
  }) async {
    Uri link = Uri(
        scheme: "https",
        host: 'maps.googleapis.com',
        path: 'maps/api/directions/json',
        queryParameters: {
          'origin': '${origin.latitude},${origin.longitude}',
          'destination': '${dest.latitude},${dest.longitude}',
          'key': googleApiKey,
        });

    final res = await http.Client().get(link).timeout(Duration(seconds: 15));

    if (res.statusCode == 200) {
      return Directions.fromMap(jsonDecode(res.body));
    }
    return null;
  }
}
