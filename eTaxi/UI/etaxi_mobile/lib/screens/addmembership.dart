import 'dart:developer';
import 'package:etaxi_mobile/services/MembershipService.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';

class AddMembershipPage extends StatefulWidget {
  const AddMembershipPage({Key? key}) : super(key: key);

  @override
  State<AddMembershipPage> createState() => _AddMembershipPageState();
}

class _AddMembershipPageState extends State<AddMembershipPage> {
  DateTime? fromDate;
  DateTime? toDate;
  int? userId;
  String? tier;
  bool? isActive;

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
          "Add Membership",
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
                //         MaterialPageRoute(builder: (_) => AddAddMembershipPage()));
                //   },
                // ),
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
                Text("Do: "),

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
                sh(5),
                Row(
                  children: [
                    CustomButton(
                      label: "Sacuvaj",
                      width: 150,
                      onPressed: () async {
                        if (fromDate == null ||
                            toDate == null ||
                            userId == null ||
                            tier == null) {
                          return appSnackBar(
                              context: context,
                              msg: "Niste unijeli sve podatke",
                              isError: true);
                        }

                        var dataToSend = {
                          "userId": userId,
                          "tier": tier,
                          "startTime": fromDate!.toIso8601String(),
                          "endTime": toDate!.toIso8601String()
                        };
                        try {
                          await MembershipService.addMembership(dataToSend);
                          Navigator.of(context).pop();
                        } catch (e) {
                          print(e);
                        }
                      },
                    ),
                    sb(10),
                  ],
                ),
                sh(20),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
