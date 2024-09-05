import 'dart:developer';
import 'package:etaxi_mobile/screens/todoPregled.dart';
import 'package:etaxi_mobile/services/ToDoService.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/date_picker.dart';
import 'package:etaxi_mobile/widgets/date_time_picker.dart';
import 'package:etaxi_mobile/widgets/line.dart';
import 'package:flutter/material.dart';
import 'package:flutter/widgets.dart';
import 'package:flutter_credit_card/extension.dart';

//List<String> statusiAktivnosti = ["U toku", "Realizovana", "Istekla"];

class AddToDoPage extends StatefulWidget {
  const AddToDoPage({Key? key}) : super(key: key);

  @override
  State<AddToDoPage> createState() => _AddToDoPageState();
}

class _AddToDoPageState extends State<AddToDoPage> {
  DateTime? toDate;
  TextEditingController naziv = TextEditingController();
  TextEditingController opis = TextEditingController();
  int? userId;
  String status = statusiAktivnosti.first;
  bool isPressed = false;
  String? error;
  bool isFinished = false;
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
          "Dodaj novi To Do ",
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
                sh(20),
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
                CustomTextField(label: "Naziv aktivnosti", controller: naziv),
                sh(5),
                CustomTextField(label: "Opis aktivnosti", controller: opis),
                sh(5),
                DropdownButtonFormField<String>(
                  value: status,
                  items: statusiAktivnosti.map((item) {
                    return DropdownMenuItem<String>(
                      child: Text(item),
                      value: item,
                    );
                  }).toList(),
                  decoration: InputDecoration(
                    labelText: 'Status',
                  ),
                  onChanged: (value) {
                    setState(() {
                      status = value!;
                    });
                  },
                ),
                sh(5),
                CustomDatePicker(
                  initialDate: toDate,
                  firstDate: DateTime.now().subtract(Duration(days: 30)),
                  lastDate: DateTime.now().add(Duration(days: 365)),
                  onDateSelected: (newValue) {
                    setState(() {
                      toDate = newValue;
                    });
                  },
                ),
                sh(5),
                isPressed
                    ? LoadingButton()
                    : CustomButton(
                        label: "Dodaj novi task",
                        onPressed: () async {
                          if (userId == null ||
                              naziv.text.isNullOrEmpty ||
                              toDate == null) {
                            return appSnackBar(
                                context: context,
                                msg: "Niste unijeli sve potrebne podatke",
                                isError: true);
                          }
                          setState(() {
                            isPressed = true;
                          });
                          var dataToSend = {
                            "userId": userId,
                            "naziv": naziv.text,
                            "opis": opis.text,
                            "krajnjiRok": toDate?.toIso8601String(),
                            "status": status
                          };
                          try {
                            await ToDoService.addTodoList(dataToSend);
                            appSnackBar(
                                context: context,
                                msg: "Uspjesno dodan novi task",
                                isError: false);
                            setState(() {
                              isFinished = true;
                            });
                          } catch (e) {
                            setState(() {
                              error = e.toString();
                            });
                          } finally {
                            setState(() {
                              isPressed = false;
                            });
                          }
                        },
                      ),
                sh(20),
                if (error.isNotNullAndNotEmpty)
                  Text(
                    error!,
                    style: TextStyle(color: Colors.red),
                  ),
                if (isFinished)
                  CustomButton(
                    label: "Vrati se nazad",
                    onPressed: () {
                      Navigator.of(context).pushReplacement(
                          MaterialPageRoute(builder: (_) => ToDoPage()));
                    },
                  )
              ],
            ),
          ),
        ),
      ),
    );
  }
}
