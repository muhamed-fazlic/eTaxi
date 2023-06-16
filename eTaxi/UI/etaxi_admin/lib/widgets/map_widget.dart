import 'package:etaxi_admin/api/api_model.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:flutter/material.dart';
import 'package:google_static_maps_controller/google_static_maps_controller.dart';

class MapWidget extends StatelessWidget {
  const MapWidget({super.key});

  @override
  Widget build(BuildContext context) {
    return StaticMap(
      googleApiKey: googleApiKey,
      width: SizeConfig.screenWidth / 2,
      height: SizeConfig.screenHeight / 2,
      scaleToDevicePixelRatio: true,
      zoom: 12,
      visible: const [
        GeocodedLocation.address('Sarajevo SCC'),
        //Location(43.8562, 18.4130),
      ],
      //styles: retroMapStyle,
      paths: <Path>[
        // const Path(
        //   encoded: true,
        //   color: Colors.blue,
        //   points: [
        //     // Can be both, addresses and coordinates.
        //     // GeocodedLocation.address('Sarajevo'),
        //     //GeocodedLocation.address('Mostar'),
        //     //GeocodedLocation.address('stari most mostar'),

        //     Location(43.8562, 18.4130),
        //     Location(43.8562, 18.4230),
        //     Location(43.8662, 18.4330),
        //     Location(43.8372, 18.4430),
        //   ],
        // ),
        // Path.circle(
        //   center: const Location(34.005641, -118.490229),
        //   color: Colors.green.withOpacity(0.8),
        //   fillColor: Colors.green.withOpacity(0.4),
        //   encoded: true, // encode using encoded polyline algorithm
        //   radius: 200, // meters
        // ),
        // const Path(
        //   encoded: true,
        //   points: [
        //     Location(34.016839, -118.488240),
        //     Location(34.019498, -118.491439),
        //     Location(34.024106, -118.485734),
        //     Location(34.021486, -118.482682),
        //     Location(34.016839, -118.488240),
        //   ],
        //   fillColor: Colors.black45,
        //   color: Colors.black,
        // )
      ],
      markers: const <Marker>[
        Marker(
          color: Colors.amber,
          label: "X",
          locations: [
            GeocodedLocation.address("Sarajevo SCC"),
            // GeocodedLocation.latLng(43.9562, 18.4130),
          ],
        ),
        // Marker.custom(
        //   anchor: MarkerAnchor.center,
        //   icon: "https://goo.gl/1oTJ9Y",
        //   locations: [
        //     Location(34.012343, -118.482998),
        //   ],
        // ),
        // Marker(
        //   locations: [
        //     Location(43.8562, 18.5130),
        //   ],
        //   color: Colors.cyan,
        //   label: "W",
        // )
      ],
    );
  }
}
