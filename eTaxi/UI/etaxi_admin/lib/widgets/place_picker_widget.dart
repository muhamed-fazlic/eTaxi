import 'package:flutter/material.dart';
//import 'package:location_picker_flutter_map/location_picker_flutter_map.dart';
import 'package:open_street_map_search_and_pick/open_street_map_search_and_pick.dart';

class PlacePickerWidget extends StatelessWidget {
  final Function(PickedData) onPicked;
  final LatLong? center;
  const PlacePickerWidget(
      {super.key,
      required this.onPicked,
      this.center = const LatLong(43.8460522, 18.3916678)});

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('Odaberi lokaciju'),
      ),
      body: OpenStreetMapSearchAndPick(
          center: center!,
          buttonText: "Odaberi lokaciju",
          locationPinText: "Lokacija",
          //trackMyPosition: true,
          // searchBarTextColor: Colors.black,
          // mapLanguage: 'bs',
          // searchBarBackgroundColor: Colors.white,
          onPicked: onPicked),
    );
  }
}
