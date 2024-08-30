import 'dart:developer';
import 'package:etaxi_mobile/screens/FITPasos/addPasos.dart';
import 'package:etaxi_mobile/services/pasos_service.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class PasosPage extends StatefulWidget {
  const PasosPage({Key? key}) : super(key: key);

  @override
  State<PasosPage> createState() => _PasosPageState();
}

class _PasosPageState extends State<PasosPage> {
  TextEditingController userIdController = TextEditingController();
  DateTime? fromDate;
  bool isFilterOpened = false;
  bool? isValid;
  Map<String, dynamic> filters = {};

  @override
  void initState() {
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        centerTitle: true,
        elevation: 0,
        leading: InkWell(
          onTap: () {
            Navigator.pop(context);
          },
          child: Padding(
            padding: EdgeInsets.symmetric(
              vertical: 22,
              horizontal: 20,
            ),
            child: Icon(
              Icons.arrow_back_ios_new_rounded,
              size: 18,
            ),
          ),
        ),
        title: Text(
          "FIT Pasos",
          style: TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.w700,
          ),
        ),
      ),
      body: SafeArea(
        child: Padding(
          padding: const EdgeInsets.symmetric(horizontal: 20),
          child: SingleChildScrollView(
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                CustomButton(
                  label: "Dodaj Pasos",
                  // width: 150,
                  onPressed: () {
                    Navigator.of(context).push(
                        MaterialPageRoute(builder: (_) => AddPasosPage()));
                  },
                ),
                sh(20),
                Text("Filteri"),
                IconButton(
                  onPressed: () {
                    setState(() {
                      isFilterOpened = !isFilterOpened;
                    });
                  },
                  icon: Icon(Icons.filter_alt_outlined),
                ),
                if (isFilterOpened)
                  Column(
                    children: [
                      CustomTextField(
                        label: "UserId",
                        controller: userIdController,
                      ),
                      CustomMaterialDateTimePicker(
                        initialDate: fromDate ?? DateTime.now(),
                        firstDate: DateTime.parse("1990-01-01"),
                        lastDate: DateTime.parse("2090-01-01"),
                        onChanged: (newValue) {
                          setState(() {
                            fromDate = newValue;
                          });
                        },
                      ),
                    ],
                  ),
                sh(5),
                Row(
                  children: [
                    CustomButton(
                      label: "Primjeni",
                      width: 150,
                      onPressed: () {
                        Map<String, dynamic> filtersTemp = {};
                        if (userIdController.text.isNotEmpty) {
                          filtersTemp["UserId"] = userIdController.text;
                        }
                        if (fromDate != null) {
                          filtersTemp["From"] = fromDate?.toIso8601String();
                        }

                        setState(() {
                          filters = filtersTemp;
                        });
                      },
                    ),
                    sb(10),
                    CustomButton(
                      label: "Obrisi",
                      width: 150,
                      onPressed: () {
                        setState(() {
                          filters = {};
                          userIdController.text = '';
                          fromDate = null;
                        });
                      },
                    ),
                  ],
                ),
                sh(20),
                FutureBuilder(
                    future: PasosService.getPasosi(queryParams: filters),
                    builder: ((context, snapshot) {
                      if (snapshot.hasError) {
                        return Text(
                            "Desio se error prilikom dohvacanaj pasosa");
                      }
                      if (snapshot.hasData) {
                        return ListView.separated(
                            padding: EdgeInsets.only(top: 5),
                            shrinkWrap: true,
                            itemCount: snapshot.data.length,
                            separatorBuilder: (context, index) {
                              return line();
                            },
                            itemBuilder: (context, index) {
                              var pasos = snapshot.data[index];
                              return InkWell(
                                  child: Container(
                                padding: EdgeInsets.all(4),
                                child: Column(
                                  children: [
                                    Row(
                                      children: [
                                        Text(
                                          "Korisnik: ",
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold),
                                        ),
                                        Text("Id:"),
                                        Text(
                                          pasos["userId"].toString(),
                                        ),
                                        sb(5),
                                        Text(pasos["user"]["firstName"]),
                                        sb(5),
                                        Text(pasos["user"]["lastName"]),
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text("Validnost: "),
                                        Text(
                                          pasos["isValid"].toString(),
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold,
                                              color: pasos['isValid'] == true
                                                  ? Colors.green
                                                  : Colors.red),
                                        )
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text("Trajanje: "),
                                        Text("Od: "),
                                        Text(dateFormatString(
                                            pasos["datumIzdavanja"])),
                                        sb(5),
                                        Text("Do: "),
                                        Text(dateFormatString(
                                            pasos["datumVazenja"]))
                                      ],
                                    )
                                  ],
                                ),
                              ));
                            });
                      } else {
                        return Text("Nema podataka");
                      }
                    })),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
