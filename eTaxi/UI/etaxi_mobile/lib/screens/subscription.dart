import 'dart:developer';

import 'package:etaxi_mobile/screens/addSubscription.dart';
import 'package:etaxi_mobile/services/subscriptionService.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/appBar.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class Subscription extends StatefulWidget {
  const Subscription({Key? key}) : super(key: key);

  @override
  _SubscriptionState createState() => _SubscriptionState();
}

class _SubscriptionState extends State<Subscription> {
  DateTime? startTime;
  DateTime? endTime;
  int? userId;
  bool? isActive;
  String? type;

  Map<String, dynamic> filters = {};

  @override
  Widget build(BuildContext context) {
    return Scaffold(
        appBar: appBarCommon(context, 40, 100, "Subskripcije"),
        body: SingleChildScrollView(
          child: Container(
            child: Column(
              children: [
                CustomButton(
                  label: "Dodaj novu",
                  width: 250,
                  onPressed: () {
                    Navigator.of(context).push(MaterialPageRoute(
                        builder: (_) => AddSubscriptionPage()));
                  },
                ),
                Text("Filteri:"),
                FutureBuilder(
                  future: UserServices.getAllUser(),
                  builder: (context, snapshot) {
                    if (snapshot.hasError) {
                      print(snapshot.error);
                    }
                    if (snapshot.hasData) {
                      return DropdownButtonFormField<int>(
                        value: userId,
                        items: snapshot.data?.map((item) {
                          return DropdownMenuItem<int>(
                            child: Text(item.firstName! + " " + item.lastName!),
                            value: item.id,
                          );
                        }).toList(),
                        decoration: InputDecoration(
                          labelText: 'Korisnik',
                        ),
                        validator: (value) {
                          if (value == null) {
                            return 'Polje ne moze biti prazno!';
                          } else
                            return null;
                        },
                        onChanged: (value) {
                          setState(() {
                            userId = value!;
                          });
                        },
                      );
                    }
                    return CircularProgressIndicator();
                  },
                ),
                DropdownButtonFormField<String>(
                  value: type,
                  items: ["mjesecna", "godisnja"].map((item) {
                    return DropdownMenuItem<String>(
                      child: Text(item),
                      value: item,
                    );
                  }).toList(),
                  decoration: InputDecoration(
                    labelText: 'Subscripcija',
                  ),
                  onChanged: (value) {
                    setState(() {
                      type = value;
                    });
                  },
                ),
                CustomMaterialDateTimePicker(
                  initialDate: startTime ?? DateTime.now(),
                  firstDate: DateTime.parse("1990-01-01"),
                  lastDate: DateTime.parse("2090-01-01"),
                  onChanged: (newValue) {
                    setState(() {
                      startTime = newValue;
                    });
                  },
                ),
                CustomMaterialDateTimePicker(
                  initialDate: endTime ?? DateTime.now(),
                  firstDate: DateTime.parse("1990-01-01"),
                  lastDate: DateTime.parse("2090-01-01"),
                  onChanged: (newValue) {
                    setState(() {
                      endTime = newValue;
                    });
                  },
                ),
                CheckboxListTile(
                    value: isActive ?? false,
                    title: Text("Jel aktivna"),
                    onChanged: (value) {
                      setState(() {
                        isActive = value;
                      });
                    }),
                sh(5),
                Row(
                  children: [
                    CustomButton(
                      label: "Primjeni",
                      width: 150,
                      onPressed: () {
                        Map<String, dynamic> filtersTemp = {};
                        if (type != null) {
                          filtersTemp["SubscriptionType"] = type;
                        }
                        if (startTime != null) {
                          filtersTemp["From"] = startTime?.toIso8601String();
                        }
                        if (endTime != null) {
                          filtersTemp["To"] = endTime?.toIso8601String();
                        }
                        if (userId != null) {
                          filtersTemp["UserId"] = userId.toString();
                        }

                        if (isActive != null) {
                          filtersTemp["isActive"] = isActive.toString();
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
                          type = null;
                          startTime = null;
                          endTime = null;
                          userId = null;
                          isActive = null;
                        });
                      },
                    ),
                  ],
                ),
                sh(30),
                Text("Pregled:"),
                FutureBuilder(
                  future: SubscriptionService.getSubscriptions(filters),
                  builder: (context, snapshot) {
                    if (snapshot.connectionState == ConnectionState.waiting) {
                      return CircularProgressIndicator();
                    } else if (snapshot.hasError) {
                      return Text('Error: ${snapshot.error}');
                    } else if (!snapshot.hasData) {
                      return Text('No data available');
                    } else {
                      return ListView.separated(
                          separatorBuilder: (context, index) {
                            return line();
                          },
                          physics: ClampingScrollPhysics(),
                          shrinkWrap: true,
                          itemCount: snapshot.data!.length,
                          itemBuilder: (context, index) {
                            var item = snapshot.data[index];
                            return InkWell(
                                child: Container(
                              child: Column(
                                children: [
                                  Row(
                                    children: [
                                      Text("Korisnik: "),
                                      Text(item["user"]['firstName']),
                                      Text(item["user"]['lastName']),
                                    ],
                                  ),
                                  sb(5),
                                  Row(
                                    children: [
                                      Text("Datum vazenja: "),
                                      Text(dateFormatString(item["startTime"])),
                                      Text(" Do: "),
                                      Text(dateFormatString(item["endTime"])),
                                    ],
                                  ),
                                  sb(5),
                                  Row(
                                    children: [
                                      Text("Tip subskripcije: "),
                                      Text((item["subscriptionType"])),
                                    ],
                                  ),
                                  sb(5),
                                  Row(
                                    children: [
                                      Text("Jel aktivna: "),
                                      Text(item["isActive"].toString()),
                                    ],
                                  ),
                                ],
                              ),
                            ));
                          });
                    }
                  },
                ),
              ],
            ),
          ),
        ));
  }
}
