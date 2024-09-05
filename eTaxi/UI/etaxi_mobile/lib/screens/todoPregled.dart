import 'dart:developer';
import 'package:etaxi_mobile/screens/addTodo.dart';
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

List<String> statusiAktivnosti = ["U toku", "Realizovana", "Istekla"];

class ToDoPage extends StatefulWidget {
  const ToDoPage({Key? key}) : super(key: key);

  @override
  State<ToDoPage> createState() => _ToDoPageState();
}

class _ToDoPageState extends State<ToDoPage> {
  DateTime? toDate;
  bool isFilterOpened = false;
  int? userId;
  String? status;
  String? editStatus;

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
          "To Do lista ",
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
                Row(
                  mainAxisAlignment: MainAxisAlignment.end,
                  children: [
                    CustomButton(
                      label: "Dodaj Novi task",
                      width: 200,
                      onPressed: () {
                        Navigator.of(context).push(
                            MaterialPageRoute(builder: (_) => AddToDoPage()));
                      },
                    ),
                  ],
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
                                  child: Text(
                                      item.firstName! + " " + item.lastName!),
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
                            status = value;
                          });
                        },
                      ),
                      sh(5),
                      CustomDatePicker(
                        initialDate: toDate,
                        firstDate: DateTime.parse("1990-01-01"),
                        lastDate: DateTime.parse("2090-01-01"),
                        onDateSelected: (newValue) {
                          setState(() {
                            toDate = newValue;
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
                        if (userId != null) {
                          filtersTemp["UserId"] = userId.toString();
                        }
                        if (toDate != null) {
                          filtersTemp["DatumVazenja"] =
                              toDate!.toIso8601String();
                        }
                        if (status != null) {
                          filtersTemp["Status"] = status;
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
                          toDate = null;
                          status = null;
                        });
                      },
                    ),
                  ],
                ),
                sh(20),
                FutureBuilder(
                    future: ToDoService.getTodoList(filters),
                    builder: ((context, snapshot) {
                      if (snapshot.hasError) {
                        return Text(
                            "Desio se error prilikom dohvacanaj To do liste");
                      }
                      if (snapshot.hasData) {
                        if (snapshot.data.length == 0) {
                          return Text("Nema podataka ");
                        }
                        return ListView.separated(
                            padding: EdgeInsets.only(top: 5),
                            physics: ClampingScrollPhysics(),
                            shrinkWrap: true,
                            itemCount: snapshot.data.length,
                            separatorBuilder: (context, index) {
                              return line();
                            },
                            itemBuilder: (context, index) {
                              var todoItem = snapshot.data[index];
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
                                          todoItem["userId"].toString(),
                                        ),
                                        sb(5),
                                        Text(todoItem["user"]["firstName"]),
                                        sb(5),
                                        Text(todoItem["user"]["lastName"]),
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text(
                                          "Naziv aktivnosti: ",
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold),
                                        ),
                                        Text(
                                          todoItem["naziv"],
                                        )
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text("Opis aktivnosti: "),
                                        Text(
                                          todoItem["opis"],
                                        )
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text(
                                          "Status: ",
                                          style: TextStyle(
                                              fontWeight: FontWeight.bold),
                                        ),
                                        Text(
                                          todoItem["status"],
                                        )
                                      ],
                                    ),
                                    Row(
                                      children: [
                                        Text("Kranji rok : "),
                                        Text(dateFormatString(
                                            todoItem["krajnjiRok"])),
                                        sb(5),
                                      ],
                                    ),
                                    if (todoItem["status"] ==
                                        statusiAktivnosti.first)
                                      IconButton(
                                        onPressed: () {
                                          showDialog(
                                            context: context,
                                            builder: (context) => AlertDialog(
                                              title: Text("Izmjeni status"),
                                              content: Container(
                                                child: Column(
                                                  mainAxisSize:
                                                      MainAxisSize.min,
                                                  children: [
                                                    DropdownButtonFormField<
                                                        String>(
                                                      value: todoItem["status"],
                                                      items: statusiAktivnosti
                                                          .map((item) {
                                                        return DropdownMenuItem<
                                                            String>(
                                                          child: Text(item),
                                                          value: item,
                                                        );
                                                      }).toList(),
                                                      decoration:
                                                          InputDecoration(
                                                        labelText:
                                                            'Izmjeni Status',
                                                      ),
                                                      onChanged: (value) {
                                                        setState(() {
                                                          editStatus = value;
                                                        });
                                                      },
                                                    ),
                                                  ],
                                                ),
                                              ),
                                              actions: [
                                                Center(
                                                  child: CustomButton(
                                                      vertPad: 5,
                                                      height: 45,
                                                      width: 200,
                                                      onPressed: () async {
                                                        var data = {
                                                          "Id": todoItem['id'],
                                                          "Status": editStatus,
                                                        };

                                                        try {
                                                          await ToDoService
                                                              .updateTodoList(
                                                                  data);

                                                          appSnackBar(
                                                              context: context,
                                                              msg:
                                                                  "Uspjeno izvrsenja radnja",
                                                              isError: false);
                                                          setState(() {
                                                            filters = {};
                                                          });
                                                          Navigator.pop(
                                                              context);
                                                        } catch (e) {
                                                          print(e);
                                                        }
                                                      },
                                                      label: "Izmjeni"),
                                                ),
                                              ],
                                            ),
                                          );
                                        },
                                        icon: Icon(Icons.edit),
                                      ),
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
