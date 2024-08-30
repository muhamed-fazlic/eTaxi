import 'dart:developer';
import 'dart:io';
import 'dart:typed_data';

import 'package:etaxi_mobile/models/user_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/services/pasos_service.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class AddPasosPage extends StatefulWidget {
  const AddPasosPage({Key? key}) : super(key: key);

  @override
  State<AddPasosPage> createState() => _AddPasosPageState();
}

class _AddPasosPageState extends State<AddPasosPage> {
  TextEditingController _nameController = TextEditingController();

  int? selectedUserId;
  DateTime? startTime;
  DateTime? endTime;
  bool isValid = false;

  bool isPressed = false;

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
          "Add new FIT Pasos",
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
                            child: Text(item.firstName! + " " + item.lastName!),
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
                sh(20),
                Text(
                  "Datum izdavanja",
                ),
                CustomMaterialDateTimePicker(
                  initialDate: DateTime.now(),
                  firstDate: DateTime.parse("1990-01-01"),
                  lastDate: DateTime.parse("2090-01-01"),
                  onChanged: (newValue) {
                    setState(() {
                      startTime = newValue;
                    });
                  },
                ),
                sh(20),
                Text(
                  "Datum vazenja",
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
                sh(20),
                CheckboxListTile(
                  value: isValid,
                  onChanged: (value) {
                    setState(() {
                      isValid = value!;
                    });
                  },
                  title: Text('Da li je validan'),
                ),
                CustomTextField(label: "Ime", controller: _nameController),
                sh(20),
                isPressed
                    ? LoadingButton()
                    : CustomButton(
                        label: 'Sacuvaj',
                        onPressed: () async {
                          setState(() {
                            isPressed = true;
                          });
                          var dataToSend = {
                            //"id": AuthProvider.instance.user!.id,
                            "datumIzdavanja": startTime?.toIso8601String(),
                            "datumVazenja": endTime?.toIso8601String(),
                            "isValid": isValid,
                            "userId": selectedUserId
                          };

                          try {
                            await PasosService.createPasos(dataToSend);
                            appSnackBar(
                                context: context,
                                msg: 'Uspjesno dodan pasos',
                                isError: false);
                          } catch (e) {
                            return appSnackBar(
                                context: context,
                                msg: e.toString(),
                                isError: true);
                          } finally {
                            setState(() {
                              isPressed = false;
                            });
                          }
                        },
                      ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
