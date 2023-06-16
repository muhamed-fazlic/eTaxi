import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class TrackCarPage extends StatelessWidget {
  TrackCarPage({Key? key}) : super(key: key);

  final TextEditingController _numberController = TextEditingController();

  Widget build(BuildContext context) {
    return Scaffold(
      resizeToAvoidBottomInset: true,
      appBar: AppBar(
        centerTitle: true,
        elevation: 0,
        automaticallyImplyLeading: false,
        title: Text(
          "Pratite svoje vozilo",
          style: TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.w700,
          ),
        ),
      ),
      body: SafeArea(
        child: Column(
          children: [
            Container(
              padding: EdgeInsets.symmetric(horizontal: 30),
              child: Column(
                children: [
                  sh(45),
                  Image.asset(
                    'assets/images/track_illus.png',
                    height: 200,
                    width: 152,
                  ),
                  sh(78),
                  Text('Unesite broj narudzbe'),
                  TextField(
                    controller: _numberController,
                  ),
                  sh(20),
                  Padding(
                    padding: const EdgeInsets.symmetric(
                        horizontal: 16, vertical: 16),
                    child: MaterialButton(
                      height: 40,
                      minWidth: double.infinity,
                      color: Colors.black,
                      onPressed: () {},
                      child: Text(
                        'Pretrazi'.toUpperCase(),
                        style: TextStyle(
                            color: Colors.white, fontWeight: FontWeight.w700),
                      ),
                    ),
                  ),
                  sh(30)
                ],
              ),
            ),
          ],
        ),
      ),
    );
  }
}
