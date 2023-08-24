import 'dart:developer';

import 'package:etaxi_mobile/models/directions_model.dart';
import 'package:etaxi_mobile/models/location_model.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:etaxi_mobile/services/directions_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/searchBar.dart' as sb;
import 'package:flutter/material.dart';
import 'package:place_picker/entities/location_result.dart';
import 'package:place_picker/place_picker.dart';
import 'package:place_picker/widgets/place_picker.dart';
import 'package:provider/provider.dart';

import '../../../../api/api_model.dart';

class PickupWidget extends StatelessWidget {
  const PickupWidget({Key? key}) : super(key: key);

  @override
  Widget build(BuildContext context) {
    return Align(
      alignment: Alignment.bottomCenter,
      child: Container(
        color: Colors.white,
        height: SizeConfig.screenHeight * 0.2,
        child: Column(
          children: [
            sh(26),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16),
              child: Consumer<OrderProvider>(
                builder: (context, value, child) => sb.SearchBar(
                  hintText: value.destinationLocationData?.address != null
                      ? value.destinationLocationData!.address!
                      : "Izaberite krajnju lokaciju",
                  onTap: () async {
                    FocusScope.of(context).unfocus();
                    LocationResult result = await Navigator.push(
                        context,
                        MaterialPageRoute(
                          builder: (context) => PlacePicker(
                            googleApiKey,
                            defaultLocation: LatLng(43.8562, 18.4130),
                          ),
                        ));

                    if (result.latLng != null) {
                      await OrderProvider.instance.setDestinationLoc(Location(
                        latitude: result.latLng!.latitude,
                        longitude: result.latLng!.longitude,
                        address: result.formattedAddress,
                        city: result.city?.name,
                        country: result.country?.name,
                        postalCode: result.postalCode,
                      ));
                    }
                    Directions? dir = await DirectionServices().getDirections(
                        origin: LatLng(
                            OrderProvider
                                .instance.currentLocationData!.latitude!,
                            OrderProvider
                                .instance.currentLocationData!.longitude!),
                        dest: result.latLng!);

                    if (dir != null)
                      await OrderProvider.instance.setDirections(dir);
                  },
                ),
              ),
            ),
            Spacer(),
            Padding(
              padding: const EdgeInsets.symmetric(horizontal: 16, vertical: 12),
              child: MaterialButton(
                height: 40,
                minWidth: double.infinity,
                color: Colors.black,
                onPressed: () {
                  if (OrderProvider.instance.currentLocationData == null) {
                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(
                        duration: Duration(seconds: 1),
                        content: Text('Unesite pocetnu lokaciju')));
                  } else if (OrderProvider.instance.destinationLocationData ==
                      null) {
                    ScaffoldMessenger.of(context).showSnackBar(SnackBar(
                        duration: Duration(seconds: 1),
                        content: Text('Unesite odredisnu lokaciju')));
                  } else
                    OrderProvider.instance
                        .setBookingStage(BookingStage.DESTINATION);
                },
                child: Text(
                  'Nastavi'.toUpperCase(),
                  style: TextStyle(
                      color: Colors.white, fontWeight: FontWeight.w700),
                ),
              ),
            ),
          ],
        ),
      ),
    );
  }
}
