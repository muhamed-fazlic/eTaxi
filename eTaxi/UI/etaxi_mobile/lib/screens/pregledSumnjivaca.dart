import 'dart:developer';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class SuspiciousUserPage extends StatefulWidget {
  const SuspiciousUserPage({Key? key}) : super(key: key);

  @override
  State<SuspiciousUserPage> createState() => _SuspiciousUserPageState();
}

class _SuspiciousUserPageState extends State<SuspiciousUserPage> {
  DateTime? fromDate;
  DateTime? toDate;

  bool isFilterOpened = false;
  int? selectedUserId;
  Map<String, dynamic> filters = {};
  bool? isSuspicious;

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
          "Pregled sumnjivih korisnika",
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
                // CustomButton(
                //   label: "Dodaj Pasos",
                //   // width: 150,
                //   onPressed: () {
                //     Navigator.of(context).push(
                //         MaterialPageRoute(builder: (_) => AddSuspiciousUserPage()));
                //   },
                // ),
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
                      FutureBuilder(
                        future: UserServices.getAllUser(),
                        builder: (context, snapshot) {
                          if (snapshot.hasError) {
                            print(snapshot.error);
                          }
                          if (snapshot.hasData) {
                            return DropdownButtonFormField<int>(
                              value: selectedUserId,
                              items: snapshot.data?.map((item) {
                                return DropdownMenuItem<int>(
                                  child: Text(
                                      item.firstName! + " " + item.lastName!),
                                  value: item.id,
                                );
                              }).toList(),
                              decoration: InputDecoration(
                                labelText: 'Korisnik',
                              ),
                              validator: (value) {
                                inspect(value);
                                if (value == null) {
                                  return 'Polje ne moze biti prazno!';
                                } else
                                  return null;
                              },
                              onChanged: (value) {
                                setState(() {
                                  selectedUserId = value!;
                                });
                              },
                            );
                          }
                          return CircularProgressIndicator();
                        },
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
                      CustomMaterialDateTimePicker(
                        initialDate: toDate ?? DateTime.now(),
                        firstDate: DateTime.parse("1990-01-01"),
                        lastDate: DateTime.parse("2090-01-01"),
                        onChanged: (newValue) {
                          setState(() {
                            toDate = newValue;
                          });
                        },
                      ),
                      CheckboxListTile(
                          value: isSuspicious ?? false,
                          title: Text('Jel sumnjiv'),
                          onChanged: ((value) {
                            setState(() {
                              isSuspicious = value;
                            });
                          }))
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
                        if (selectedUserId != null) {
                          filtersTemp["UserId"] = selectedUserId.toString();
                        }
                        if (fromDate != null) {
                          filtersTemp["From"] = fromDate?.toIso8601String();
                        }
                        if (toDate != null) {
                          filtersTemp["To"] = toDate?.toIso8601String();
                        }
                        if (isSuspicious != null) {
                          filtersTemp["isSuspicious"] = isSuspicious.toString();
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
                          selectedUserId = null;
                          fromDate = null;
                          toDate = null;
                          isSuspicious = null;
                        });
                      },
                    ),
                  ],
                ),
                sh(20),
                FutureBuilder(
                    future: UserServices.getMaliciousUser(queryParams: filters),
                    builder: ((context, snapshot) {
                      if (snapshot.hasError) {
                        return Text(snapshot.error.toString());
                      }
                      if (snapshot.hasData) {
                        if (snapshot.data.length > 0)
                          return ListView.separated(
                              padding: EdgeInsets.only(top: 5),
                              shrinkWrap: true,
                              itemCount: snapshot.data.length,
                              separatorBuilder: (context, index) {
                                return line();
                              },
                              itemBuilder: (context, index) {
                                var sumnjivac = snapshot.data[index];

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
                                            sumnjivac["userId"].toString(),
                                          ),
                                          sb(5),
                                          Text(sumnjivac["user"]["firstName"]),
                                          sb(5),
                                          Text(sumnjivac["user"]["lastName"]),
                                        ],
                                      ),
                                      Row(
                                        children: [
                                          Text("Sumnjivost: "),
                                          Text(
                                            sumnjivac["isSuspicious"]
                                                .toString(),
                                            style: TextStyle(
                                                fontWeight: FontWeight.bold,
                                                color:
                                                    sumnjivac['isSuspicious'] ==
                                                            true
                                                        ? Colors.green
                                                        : Colors.red),
                                          )
                                        ],
                                      ),
                                      Row(
                                        children: [
                                          Text("Datum prijave: "),
                                          Text(dateFormatString(
                                              sumnjivac["dateCreated"])),
                                          sb(5),
                                        ],
                                      ),
                                      if (sumnjivac["isSuspicious"] == true)
                                        CustomButton(
                                          label: "Ponisti sumnjivost ",
                                          // height: 25,
                                          onPressed: (() async {
                                            try {
                                              var dataToSend = {
                                                "id": sumnjivac['id'],
                                                "userId": sumnjivac['userId'],
                                                "isSuspicious": false,
                                              };
                                              UserServices.removeMaliciousUser(
                                                  dataToSend);
                                              setState(() {});
                                            } catch (e) {
                                              print(e);
                                            }
                                          }),
                                        )
                                    ],
                                  ),
                                ));
                              });
                        else {
                          return Text("Nema podataka");
                        }
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
