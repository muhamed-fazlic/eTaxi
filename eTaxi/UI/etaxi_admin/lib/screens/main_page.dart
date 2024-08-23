import 'dart:developer';
import 'dart:io';
import 'package:date_time_picker/date_time_picker.dart';
import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/main_service.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:file_picker/file_picker.dart';
import 'package:flutter/material.dart';
import 'package:intl/intl.dart';
import 'package:pdf/pdf.dart';
import 'package:pdf/widgets.dart' as pw;

// ignore: must_be_immutable
class MainPageAdmin extends StatefulWidget {
  MainPageAdmin({super.key});

  @override
  State<MainPageAdmin> createState() => _MainPageAdminState();
}

class _MainPageAdminState extends State<MainPageAdmin> {
  DateTime? fromDate;
  DateTime? toDate;
  Map<String, dynamic>? reportData;
  String? errorMsg;
  bool loadingPDf = false;

  @override
  void initState() {
    super.initState();
    fetchData();
  }

  void fetchData() async {
    try {
      var data = await MainServices.getReport(
          fromDate, toDate, AuthProvider.instance.user!.companyId);
      inspect(data);

      if (data['mostFrequentRoute'] != null) {
        var startLocation = await MainServices.getLocationFromLatLng(
            data['mostFrequentRoute'][0]['route']['startLocation']['latitude'],
            data['mostFrequentRoute'][0]['route']['startLocation']
                ['longitude']);
        var endLocation = await MainServices.getLocationFromLatLng(
            data['mostFrequentRoute'][0]['route']['endLocation']['latitude'],
            data['mostFrequentRoute'][0]['route']['endLocation']['longitude']);
        data['mostFrequentRouteStart'] = startLocation;
        data['mostFrequentRouteEnd'] = endLocation;
      }

      setState(() {
        reportData = data;
        errorMsg = null;
      });
    } catch (e) {
      inspect(e);
      setState(() {
        errorMsg = 'Desila se greska prilikom dohvatanja podataka';
      });
    }
  }

  Future<void> captureAndExportToPdf() async {
    final pdf = pw.Document();
    setState(() {
      loadingPDf = true;
    });
    pdf.addPage(
      pw.MultiPage(
        pageFormat: PdfPageFormat.a4,
        margin: pw.EdgeInsets.all(32),
        build: (pw.Context context) {
          return [
            pw.Text('Opci pregled',
                style:
                    pw.TextStyle(fontSize: 36, fontWeight: pw.FontWeight.bold)),
            pw.SizedBox(height: 20),
            if (fromDate != null && toDate != null)
              pw.Padding(
                  padding: pw.EdgeInsets.only(bottom: 10),
                  child: pw.Text(
                      'Od: ${DateFormat('dd.MM.yyyy').format(fromDate!)} - Do: ${DateFormat('dd.MM.yyyy').format(toDate!)}',
                      style: pw.TextStyle(fontSize: 16))),
            // Further content will be added here
            pw.Column(
              children: [
                createStatisticItemForPdf(
                    'Ukupan broj narudzbi',
                    pw.Text(reportData!['totalOrders'].toString(),
                        style: const pw.TextStyle(fontSize: 16))),
                createStatisticItemForPdf(
                    'Ukupno zaradeno',
                    pw.Text('${reportData!['totalEarnedMoney']} KM',
                        style: const pw.TextStyle(fontSize: 16))),
                createStatisticItemForPdf(
                    'Otkazane narudzbe',
                    pw.Text(reportData!['totalCanceledOrders'].toString(),
                        style: const pw.TextStyle(fontSize: 16))),
                createStatisticItemForPdf(
                  'Zaposlenik sa najvise narudzbi',
                  pw.Text(
                      Userinfo.fromJson(reportData?['driverWithMostOrders'])
                          .fullName(),
                      style: const pw.TextStyle(fontSize: 16)),
                ),
                createStatisticItemForPdf(
                    'Korisnik sa najvise narudzbi',
                    pw.Text(
                        Userinfo.fromJson(reportData?['userWithMostOrders'])
                            .fullName(),
                        style: const pw.TextStyle(fontSize: 16))),
                createStatisticItemForPdf(
                  "Najkoristenija ruta taksi vozila",
                  pw.Column(
                    children: [
                      pw.Text(
                        'Polazak - ${reportData?['mostFrequentRouteStart'] ?? ''}',
                        style: pw.TextStyle(fontSize: 16),
                      ),
                      pw.SizedBox(
                        height: 12,
                      ),
                      pw.Text(
                        'Destinacija - ${reportData?['mostFrequentRouteEnd'] ?? ''}',
                        style: pw.TextStyle(fontSize: 16),
                      ),
                    ],
                  ),
                  withDivider: true,
                  isColumn: true,
                ),
                createStatisticItemForPdf(
                    "Narudzbe po korisniku",
                    pw.Column(
                      children: List<Map<String, dynamic>>.from(
                              reportData?['userOrderCount'])
                          .map((e) {
                        return pw.Text(
                          e['userId'] == null
                              ? 'Narudzbe: ${e['orderCount']} - Nepoznat'
                              : 'Narudzbe: ${e['orderCount']} - ${e['userName']}',
                          style: const pw.TextStyle(fontSize: 16),
                        );
                      }).toList(),
                    ),
                    withDivider: true,
                    isColumn: true),
                createStatisticItemForPdf(
                    "Narudzbe po vozilu",
                    pw.Column(
                      children: List<Map<String, dynamic>>.from(
                              reportData?['vehicleOrderCount'])
                          .map((e) {
                        return pw.Text(
                          'Narudzbe: ${e['orderCount']} - ${e['vehicleName']}',
                          style: const pw.TextStyle(fontSize: 16),
                        );
                      }).toList(),
                    ),
                    withDivider: true,
                    isColumn: true),
                createStatisticItemForPdf(
                    "Najprometnije vrijeme za voznju",
                    pw.Column(
                      children: List<Map<String, dynamic>>.from(
                              reportData?['mostFrequentTime'])
                          .map((e) {
                        return pw.Text(
                          'Narudzbe: ${e["count"]} - ${e["hourRange"]}',
                          style: const pw.TextStyle(fontSize: 16),
                        );
                      }).toList(),
                    ),
                    withDivider: true,
                    isColumn: true),
                // Add more items based on your data
              ],
            ),
          ];
        },
      ),
    );

    //let the user pick where to save the file
    final savePath = await FilePicker.platform.saveFile(
      dialogTitle: 'Odaberite mjesto i naziv fajla:',
      fileName: 'eTaxi-Pregled.pdf',
    );
    if (savePath != null) {
      final saveFile = File(savePath);
      await saveFile.writeAsBytes(await pdf.save());
      print("PDF saved to user-selected path");
    }

    setState(() {
      loadingPDf = false;
    });
  }

  @override
  Widget build(BuildContext context) {
    return Padding(
      padding: const EdgeInsets.all(20),
      child: SingleChildScrollView(
        child: Column(
          children: [
            const Padding(
              padding: EdgeInsets.only(bottom: 35.0),
              child: Text(
                'Opći pregled',
                style: TextStyle(
                  fontSize: 36,
                ),
              ),
            ),
            Padding(
              padding: EdgeInsets.only(bottom: 30.0),
              child: Row(
                children: [
                  const Text(
                    'Preuzmi izvjestaj u PDF formatu: ',
                    style: TextStyle(fontSize: 20),
                  ),
                  CustomButton(
                    label: loadingPDf ? "Preuzimanje.." : "preuzmi pdf",
                    width: 150,
                    height: 40,
                    fontSize: 11,
                    vertPad: 5,
                    onPressed: loadingPDf
                        ? null
                        : reportData?["totalOrders"] == 0
                            ? null
                            : () async {
                                captureAndExportToPdf();
                              },
                  ),
                ],
              ),
            ),
            Row(
              children: [
                Expanded(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      const Text(
                        'Od datuma:',
                        style: TextStyle(fontSize: 16),
                      ),
                      const SizedBox(width: 10),
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
                const SizedBox(width: 20),
                Expanded(
                  child: Row(
                    mainAxisAlignment: MainAxisAlignment.spaceBetween,
                    children: [
                      const Text(
                        'Do datuma:',
                        style: TextStyle(fontSize: 16),
                      ),
                      const SizedBox(width: 10),
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
                const SizedBox(
                  width: 20,
                ),
                SizedBox(
                  height: 54,
                  width: 120,
                  child: MaterialButton(
                    onPressed: () {
                      //setState(() {});
                      fetchData();
                    },
                    color: Colors.black,
                    child: const Text(
                      'Primjeni',
                      style: TextStyle(color: Colors.white),
                    ),
                  ),
                ),
              ],
            ),
            const SizedBox(height: 20),
            if (errorMsg != null)
              Text(errorMsg!)
            else if (reportData == null)
              const CircularProgressIndicator()
            else if (reportData?["totalOrders"] == 0)
              const Padding(
                  padding: EdgeInsets.all(20.0),
                  child: Text("Nema podataka za izabrani period",
                      style: TextStyle(fontSize: 24)))
            else
              Wrap(
                spacing: 20,
                runSpacing: 20,
                children: [
                  _buildStatisticTile(
                    'Ukupan broj narudžbi',
                    Text(
                      reportData?['totalOrders'].toString() ?? '',
                      style: const TextStyle(fontSize: 24),
                    ),
                  ),
                  _buildStatisticTile(
                    'Ukupno zarađeno',
                    Text(
                      reportData?['totalEarnedMoney'].toString() ?? '' + ' KM',
                      style: const TextStyle(fontSize: 24),
                    ),
                  ),
                  _buildStatisticTile(
                    'Otkazane narudžbe',
                    Text(
                      reportData?['totalCanceledOrders'].toString() ?? '',
                      style: const TextStyle(fontSize: 24),
                    ),
                  ),
                  _buildStatisticTile(
                    'Zaposlenik sa najviše narudžbi',
                    Text(
                      Userinfo.fromJson(reportData?['driverWithMostOrders'])
                          .fullName(),
                      style: const TextStyle(fontSize: 24),
                    ),
                  ),
                  _buildStatisticTile(
                    'Korisnik sa najviše narudžbi',
                    Text(
                      reportData?["userWithMostOrders"] != null
                          ? Userinfo.fromJson(reportData?['userWithMostOrders'])
                              .fullName()
                          : "Nepoznat",
                      style: const TextStyle(fontSize: 24),
                    ),
                  ),
                  _buildStatisticTile(
                    'Najkorištenija ruta taksi vozila',
                    Column(
                      children: [
                        Text(
                          'Polazak - ${reportData?['mostFrequentRouteStart'] ?? ''}',
                          style: const TextStyle(fontSize: 24),
                        ),
                        const SizedBox(
                          height: 12,
                        ),
                        Text(
                          'Destinacija - ${reportData?['mostFrequentRouteEnd'] ?? ''}',
                          style: const TextStyle(fontSize: 24),
                        ),
                      ],
                    ),
                  ),
                  _buildStatisticTile(
                    'Narudžbe po korisniku',
                    Column(
                      children: List<Map<String, dynamic>>.from(
                              reportData?['userOrderCount'])
                          .map((e) {
                        return Text(
                          e['userId'] == null
                              ? 'Narudzbe: ${e['orderCount']} - Nepoznat'
                              : 'Narudzbe: ${e['orderCount']} - ${e['userName']}',
                          style: const TextStyle(fontSize: 24),
                        );
                      }).toList(),
                    ),
                  ),
                  _buildStatisticTile(
                      'Narudžbe po vozilu',
                      Column(
                        children: List<Map<String, dynamic>>.from(
                                reportData?['vehicleOrderCount'])
                            .map((e) {
                          return Text(
                            'Narudzbe: ${e['orderCount']} - ${e['vehicleName']}',
                            style: const TextStyle(fontSize: 24),
                          );
                        }).toList(),
                      )),
                  _buildStatisticTile(
                      'Najprometnije vrijeme za vožnju',
                      Column(
                        children: List<Map<String, dynamic>>.from(
                                reportData?['mostFrequentTime'])
                            .map((e) {
                          return Text(
                            'Narudzbe: ${e["count"]} - ${e["hourRange"]}',
                            style: const TextStyle(fontSize: 24),
                          );
                        }).toList(),
                      )),
                ],
              )
          ],
        ),
      ),
    );
  }

  // Helper method to create a statistic item
  pw.Widget createStatisticItemForPdf(String title, pw.Widget value,
      {bool isColumn = false, bool withDivider = false}) {
    return pw.Padding(
        padding: const pw.EdgeInsets.only(bottom: 10),
        child: isColumn
            ? pw.Column(children: [
                if (withDivider) pw.Divider(),
                pw.Text(title, style: pw.TextStyle(fontSize: 16)),
                pw.SizedBox(height: 10),
                value
              ])
            : pw.Row(
                mainAxisAlignment: pw.MainAxisAlignment.spaceBetween,
                children: [
                  if (withDivider) pw.Divider(),
                  pw.Text(title, style: pw.TextStyle(fontSize: 16)),
                  value
                ],
              ));
  }

  Widget _buildStatisticTile(String title, Widget value) {
    return Card(
      child: Padding(
        padding: const EdgeInsets.all(20),
        child: Column(
          children: [
            Text(
              title,
              style: const TextStyle(fontSize: 20, fontWeight: FontWeight.bold),
            ),
            const SizedBox(height: 10),
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
