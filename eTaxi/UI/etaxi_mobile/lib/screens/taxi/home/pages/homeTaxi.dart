import 'dart:developer';

import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/directions_model.dart';
import 'package:etaxi_mobile/models/location_model.dart' as LocModel;
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/bookingPage.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/destinationPage.dart';
import 'package:etaxi_mobile/screens/taxi/home/pages/taxiRideBookedPage.dart';
import 'package:etaxi_mobile/screens/taxi/widgets/googleMapWidget.dart';
import 'package:etaxi_mobile/services/directions_services.dart';
import 'package:etaxi_mobile/widgets/searchBar.dart' as sb;
import 'package:flutter/material.dart';
import 'package:geocoding/geocoding.dart';
import 'package:geolocator/geolocator.dart';
import 'package:google_maps_flutter/google_maps_flutter.dart';
import 'package:place_picker/entities/location_result.dart';
import 'package:place_picker/widgets/place_picker.dart';

import 'package:provider/provider.dart';

import '../widgets/pickupWidget.dart';

class HomeTaxi extends StatefulWidget {
  const HomeTaxi({Key? key}) : super(key: key);

  @override
  State<HomeTaxi> createState() => _HomeTaxiState();
}

class _HomeTaxiState extends State<HomeTaxi> {
  int stage = 0;

  CameraPosition _cameraPosition = CameraPosition(
    target: LatLng(43.8562, 18.4130),
    zoom: 15,
  );
  setCurrentLocMarker() async {
    final permission = await Geolocator.checkPermission();
    if (permission == LocationPermission.denied ||
        permission == LocationPermission.deniedForever)
      await Geolocator.requestPermission();

    final loc = await Geolocator.getCurrentPosition(
        desiredAccuracy: LocationAccuracy.bestForNavigation);

    List<Placemark> placemarks =
        await placemarkFromCoordinates(loc.latitude, loc.longitude);
    Placemark place = placemarks[0];
    OrderProvider.instance.setCurrentLoc(LocModel.Location(
      latitude: loc.latitude,
      longitude: loc.longitude,
      address:
          '${place.street}, ${place.subLocality}, ${place.subAdministrativeArea}, ${place.postalCode}',
      postalCode: place.postalCode,
      city: place.locality,
      country: place.country,
    ));
    _cameraPosition =
        CameraPosition(target: LatLng(loc.latitude, loc.longitude));
  }

  @override
  void initState() {
    if (OrderProvider.instance.selectedOrder == null) {
      setCurrentLocMarker();
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return WillPopScope(
      onWillPop: () async {
        if (OrderProvider.instance.stage == BookingStage.DESTINATION) {
          OrderProvider.instance.setBookingStage(BookingStage.PICKUP);
          return false;
        } else if (OrderProvider.instance.stage == BookingStage.VEHICLES) {
          OrderProvider.instance.setBookingStage(BookingStage.DESTINATION);
          return false;
        } else if (OrderProvider.instance.stage == BookingStage.RIDE_BOOKED) {
          OrderProvider.instance.setBookingStage(BookingStage.PICKUP);
          return false;
        } else if (OrderProvider.instance.stage == BookingStage.VEHICLES)
          return false;
        else
          return true;
      },
      child: Scaffold(
          body: Consumer<OrderProvider>(
        builder: (context, value, child) => SafeArea(
            child: Column(
          children: [
            Expanded(
              child: Stack(
                children: [
                  Column(
                    children: [
                      Expanded(
                        child: GoogleMapWidget(
                          cameraPosition: _cameraPosition,
                        ),
                      ),
                      if (OrderProvider.instance.stage == BookingStage.PICKUP)
                        PickupWidget()
                    ],
                  ),
                  if (OrderProvider.instance.stage == BookingStage.PICKUP)
                    Padding(
                      padding: const EdgeInsets.all(16),
                      child: Container(
                        color: Colors.white,
                        child: Padding(
                          padding: const EdgeInsets.all(8.0),
                          child: sb.SearchBar(
                            hintText: value.currentLocationData != null
                                ? value.currentLocationData!.address!
                                : "Izaberite pocetnu lokaciju",
                            onTap: () async {
                              FocusScope.of(context).unfocus();
                              LocationResult result = await Navigator.push(
                                context,
                                MaterialPageRoute(
                                  builder: (context) => PlacePicker(
                                    googleApiKey,
                                    defaultLocation:
                                        value.currentLocationData != null
                                            ? LatLng(
                                                OrderProvider
                                                    .instance
                                                    .currentLocationData!
                                                    .latitude!,
                                                OrderProvider
                                                    .instance
                                                    .currentLocationData!
                                                    .longitude!)
                                            : LatLng(43.8562, 18.4130),
                                  ),
                                ),
                              );
                              if (result.latLng != null) {
                                await OrderProvider.instance.setCurrentLoc(
                                  LocModel.Location(
                                    latitude: result.latLng!.latitude,
                                    longitude: result.latLng!.longitude,
                                    address: result.formattedAddress,
                                    city: result.city?.name,
                                    country: result.country?.name,
                                    postalCode: result.postalCode,
                                  ),
                                );
                              }
                              Directions? dir = await DirectionServices()
                                  .getDirections(
                                      origin: result.latLng!,
                                      dest: LatLng(
                                          OrderProvider
                                              .instance
                                              .destinationLocationData!
                                              .latitude!,
                                          OrderProvider
                                              .instance
                                              .destinationLocationData!
                                              .longitude!));

                              if (dir != null)
                                await OrderProvider.instance.setDirections(dir);
                            },
                          ),
                        ),
                      ),
                    ),
                  if (OrderProvider.instance.stage == BookingStage.DESTINATION)
                    DestinationPage(),
                  if (OrderProvider.instance.stage == BookingStage.VEHICLES)
                    BookingPage(),
                  if (OrderProvider.instance.stage == BookingStage.RIDE_BOOKED)
                    TaxiRideBooked(),
                ],
              ),
            ),
          ],
        )),
      )),
    );
  }

  @override
  void dispose() {
    super.dispose();
  }
}
