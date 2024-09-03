import 'dart:developer';
import 'package:etaxi_mobile/screens/addmembership.dart';
import 'package:etaxi_mobile/services/MembershipService.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_picker.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class MembershipPage extends StatefulWidget {
  const MembershipPage({Key? key}) : super(key: key);

  @override
  State<MembershipPage> createState() => _MembershipPageState();
}

class _MembershipPageState extends State<MembershipPage> {
  DateTime? fromDate;
  DateTime? toDate;
  int? userId;
  String? tier;
  bool? isActive;
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
          "Membership",
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
                  label: "Dodaj Clanstvo",
                  // width: 150,
                  onPressed: () {
                    Navigator.of(context).push(
                        MaterialPageRoute(builder: (_) => AddMembershipPage()));
                  },
                ),
                sh(20),
                Text("Filteri"),
                DropdownButtonFormField<String>(
                  value: tier,
                  items: ["Basic", "Premium", "VIP"]
                      .map(
                        (item) => DropdownMenuItem<String>(
                          child: Text(item),
                          value: item,
                        ),
                      )
                      .toList(),
                  decoration: InputDecoration(
                    labelText: 'Tier',
                  ),
                  onChanged: (value) {
                    setState(() {
                      tier = value;
                    });
                  },
                ),
                sh(5),
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
                sh(5),
                Text("Od: "),
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
                sh(5),
                CustomDatePicker(
                  label: 'Do',
                  initialDate: toDate,
                  firstDate: DateTime.parse("1990-01-01"),
                  lastDate: DateTime.parse("2090-01-01"),
                  onDateSelected: (newValue) {
                    setState(() {
                      toDate = newValue;
                    });
                  },
                ),
                sh(5),
                Row(
                  children: [
                    CustomButton(
                      label: "Primjeni",
                      width: 150,
                      onPressed: () {
                        Map<String, dynamic> filtersTemp = {};
                        if (userId != null) {
                          filtersTemp["UserId"] = userId.toString();
                        }
                        if (fromDate != null) {
                          filtersTemp["StartTime"] =
                              fromDate?.toIso8601String();
                        }
                        if (toDate != null) {
                          filtersTemp["EndTime"] = toDate?.toIso8601String();
                        }
                        if (tier != null) {
                          filtersTemp["Tier"] = tier;
                        }

                        setState(() {
                          filters = filtersTemp;
                        });
                      },
                    ),
                    sb(10),
                    CustomButton(
                      label: "Obrisi filtere",
                      width: 150,
                      onPressed: () {
                        setState(() {
                          filters = {};
                          userId = null;
                          fromDate = null;
                          tier = null;
                          toDate = null;
                        });
                      },
                    ),
                  ],
                ),
                sh(20),
                FutureBuilder(
                    future: MembershipService.getAllMembership(filters),
                    builder: ((context, snapshot) {
                      if (snapshot.hasError) {
                        return Text(
                            "Desio se error prilikom dohvacanaj clanstva");
                      }
                      if (snapshot.hasData) {
                        return ListView.separated(
                            physics: ClampingScrollPhysics(),
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
                                        Text("Jel aktivna: "),
                                        Text(
                                          pasos["isActive"].toString(),
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold,
                                              color: pasos['isActive'] == true
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
                                            pasos["startTime"])),
                                        sb(5),
                                        Text("Do: "),
                                        Text(dateFormatString(pasos["endTime"]))
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text("Tier: "),
                                        Text((pasos["tier"])),
                                        sb(5),
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
                sh(30)
              ],
            ),
          ),
        ),
      ),
    );
  }
}
