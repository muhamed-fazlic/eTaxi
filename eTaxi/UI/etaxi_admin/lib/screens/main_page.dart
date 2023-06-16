import 'dart:developer';

import 'package:date_time_picker/date_time_picker.dart';
import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';

// ignore: must_be_immutable
class MainPageAdmin extends StatefulWidget {
  MainPageAdmin({super.key});

  @override
  State<MainPageAdmin> createState() => _MainPageAdminState();
}

class _MainPageAdminState extends State<MainPageAdmin> {
  DateTime? fromDate;

  DateTime? toDate;

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: EdgeInsets.all(20),
      child: SingleChildScrollView(
        child: Column(
          children: [
            Row(
              children: [
                Expanded(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        'Od datuma:',
                        style: TextStyle(fontSize: 16),
                      ),
                      SizedBox(width: 10),
                      Expanded(
                        child: DateTimePicker(
                          initialValue: '',
                          firstDate: DateTime(2000),
                          lastDate: DateTime(2100),
                          dateLabelText: 'Datum',
                          onChanged: (val) => fromDate = DateTime.tryParse(val),
                          validator: (val) {
                            return null;
                          },
                        ),
                      ),
                    ],
                  ),
                ),
                SizedBox(width: 20),
                Expanded(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      Text(
                        'Do datuma:',
                        style: TextStyle(fontSize: 16),
                      ),
                      SizedBox(width: 10),
                      Expanded(
                        child: DateTimePicker(
                          initialValue: '',
                          firstDate: DateTime(2000),
                          lastDate: DateTime(2100),
                          dateLabelText: 'Datum',
                          onChanged: (val) => toDate = DateTime.tryParse(val),
                          validator: (val) {
                            return null;
                          },
                        ),
                      ),
                    ],
                  ),
                ),
                SizedBox(
                  width: 20,
                ),
                SizedBox(
                  height: 54,
                  width: 120,
                  child: MaterialButton(
                    onPressed: () {
                      setState(() {});
                    },
                    color: Colors.black,
                    child: Text(
                      'Primjeni',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ),
              ],
            ),
            SizedBox(height: 20),
            FutureBuilder<Map<String, dynamic>>(
                future: MainServices.getReport(
                    fromDate, toDate, AuthProvider.instance.user!.companyId),
                builder: (context, snapshot) {
                  if (snapshot.hasData) {
                    var data = snapshot.data!;
                    return Wrap(
                      spacing: 20,
                      runSpacing: 20,
                      children: [
                        _buildStatisticTile(
                          'Ukupan broj narudžbi',
                          Text(
                            data['totalOrders'].toString(),
                            style: TextStyle(fontSize: 24),
                          ),
                        ),
                        _buildStatisticTile(
                          'Ukupno zarađeno',
                          Text(
                            data['totalEarnedMoney'].toString() + ' KM',
                            style: TextStyle(fontSize: 24),
                          ),
                        ),
                        _buildStatisticTile(
                          'Otkazane narudžbe',
                          Text(
                            data['totalCanceledOrders'].toString(),
                            style: TextStyle(fontSize: 24),
                          ),
                        ),
                        _buildStatisticTile(
                          'Zaposlenik sa najviše narudžbi',
                          Text(
                            Userinfo.fromJson(data['driverWithMostOrders'])
                                .fullName(),
                            style: TextStyle(fontSize: 24),
                          ),
                        ),
                        _buildStatisticTile(
                          'Korisnik sa najviše narudžbi',
                          Text(
                            Userinfo.fromJson(data['userWithMostOrders'])
                                .fullName(),
                            style: TextStyle(fontSize: 24),
                          ),
                        ),
                        _buildStatisticTile(
                          'Najkorištenija ruta taksi vozila',
                          Column(
                            children: [
                              FutureBuilder(
                                  future: MainServices.getLocationFromLatLng(
                                      data['mostFrequentRoute'][0]['route']
                                          ['startLocation']['latitude'],
                                      data['mostFrequentRoute'][0]['route']
                                          ['startLocation']['longitude']),
                                  builder: (context, snapshot) {
                                    if (snapshot.hasData)
                                      return Text(
                                        'Polazak - ${snapshot.data}',
                                        style: TextStyle(fontSize: 24),
                                      );
                                    return CircularProgressIndicator();
                                  }),
                              SizedBox(
                                height: 12,
                              ),
                              FutureBuilder(
                                  future: MainServices.getLocationFromLatLng(
                                      data['mostFrequentRoute'][0]['route']
                                          ['endLocation']['latitude'],
                                      data['mostFrequentRoute'][0]['route']
                                          ['endLocation']['longitude']),
                                  builder: (context, snapshot) {
                                    if (snapshot.hasData)
                                      return Text(
                                        'Destinacija - ${snapshot.data}',
                                        style: TextStyle(fontSize: 24),
                                      );
                                    return CircularProgressIndicator();
                                  }),
                            ],
                          ),
                        ),
                        _buildStatisticTile(
                          'Narudžbe po korisniku',
                          Column(
                            children: List<Map<String, dynamic>>.from(
                                    data['userOrderCount'])
                                .map((e) {
                              return Text(
                                e['userId'] == null
                                    ? 'Narudzbe: ${e['orderCount']} - Nepoznat'
                                    : 'Narudzbe: ${e['orderCount']} - ${e['userName']}',
                                style: TextStyle(fontSize: 24),
                              );
                            }).toList(),
                          ),
                        ),
                        _buildStatisticTile(
                            'Narudžbe po vozilu',
                            Column(
                              children: List<Map<String, dynamic>>.from(
                                      data['vehicleOrderCount'])
                                  .map((e) {
                                return Text(
                                  'Narudzbe: ${e['orderCount']} - ${e['vehicleName']}',
                                  style: TextStyle(fontSize: 24),
                                );
                              }).toList(),
                            )),
                        _buildStatisticTile(
                            'Najprometnije vrijeme za vožnju',
                            Column(
                              children: List<Map<String, dynamic>>.from(
                                      data['mostFrequentTime'])
                                  .map((e) {
                                return Text(
                                  'Narudzbe: ${e["count"]} - ${e["hourRange"]}',
                                  style: TextStyle(fontSize: 24),
                                );
                              }).toList(),
                            )),
                      ],
                    );
                  }

                  if (snapshot.connectionState == ConnectionState.waiting)
                    return Center(
                      child: CircularProgressIndicator(),
                    );
                  return Padding(
                    padding: const EdgeInsets.only(top: 28.0),
                    child: Center(
                      child: Text('Nema podataka za izabrani vremenski period'),
                    ),
                  );
                }),
          ],
        ),
      ),
    );
  }

  Widget _buildStatisticTile(String title, Widget value) {
    return Card(
      child: Padding(
        padding: EdgeInsets.all(20),
        child: Column(
          children: [
            Text(
              title,
              style: TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            SizedBox(height: 10),
            value
          ],
        ),
      ),
    );
  }

  String getDateString(dynamic data) {
    DateTime dateTime =
        DateTime.parse("0001-00-00 ${data['hourRange'].split('.')[1]}");

    int days = int.parse(data['hourRange'].split('.')[0]);
    dateTime = dateTime.add(Duration(days: days));

    return DateFormat('HH:mm ').format(dateTime) +
        ' - Broj vožnji: ${data['count']}';
  }
}
