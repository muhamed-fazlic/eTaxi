import 'dart:developer';

import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/user_service.dart';
import 'package:etaxi_admin/utils/colors.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/user_dialog.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class UsersPage extends StatelessWidget {
  const UsersPage({super.key});

  @override
  Widget build(BuildContext context) {
    return SingleChildScrollView(
      child: Column(
        crossAxisAlignment: CrossAxisAlignment.start,
        children: [
          Row(
            children: [
              IconButton(
                onPressed: () {
                  showDialog(
                    context: context,
                    builder: (context) => UserDialog(),
                  );
                },
                icon: Icon(Icons.add),
              ),
              Text('Dodaj novog korisnika'),
            ],
          ),
          sh(20),
          Text(
            'Lista korisnika',
            style: TextStyle(fontSize: 20),
          ),
          sh(20),
          Consumer<AuthProvider>(
            builder: (context, value, child) {
              return FutureBuilder<List<Userinfo>>(
                  future: UserServices.getAllUser(),
                  builder: (builder, snapshot) {
                    if (snapshot.connectionState == ConnectionState.done) {
                      if (!snapshot.hasData) {
                        return Center(
                          child: Text('Nema pronadjenih korisnika'),
                        );
                      }

                      return ListView.builder(
                        shrinkWrap: true,
                        itemCount: snapshot.data!.length,
                        itemBuilder: (context, index) {
                          var user = snapshot.data![index];
                          return Container(
                            margin: EdgeInsets.symmetric(vertical: 8.0),
                            padding: EdgeInsets.all(8.0),
                            child: Row(children: [
                              Expanded(
                                child: Column(
                                  crossAxisAlignment: CrossAxisAlignment.start,
                                  children: [
                                    Text(
                                        user.firstName! + " " + user.lastName!),
                                    Text(user.email!),
                                    Text(user.phoneNumber ?? ''),
                                  ],
                                ),
                              ),
                              IconButton(
                                onPressed: () {
                                  showDialog(
                                      context: context,
                                      builder: (context) => UserDialog(
                                            user: user,
                                          ));
                                },
                                icon: Icon(Icons.edit),
                              ),
                              IconButton(
                                onPressed: () async {
                                  showDialog(
                                      context: context,
                                      builder: (builder) => AlertDialog(
                                            title: Text('Brisanje korisnika'),
                                            content: Text(
                                                'Da li ste sigurni da zelite da obrisete korisnika?'),
                                            actions: [
                                              TextButton(
                                                  onPressed: () {
                                                    Navigator.pop(context);
                                                  },
                                                  child: Text('Ne')),
                                              TextButton(
                                                  onPressed: () async {
                                                    try {
                                                      await UserServices
                                                          .deleteUser(user.id!);
                                                      AuthProvider.instance
                                                          .resetStateFunction();
                                                    } catch (e) {
                                                      log("ERROR DELETING USER: $e");
                                                    }
                                                    Navigator.pop(context);
                                                  },
                                                  child: Text('Da')),
                                            ],
                                          ));
                                  //value.deleteUser(user.id);
                                },
                                icon: Icon(Icons.delete),
                              ),
                            ]),
                            decoration: BoxDecoration(
                                border: Border.all(
                                  color: primaryColor,
                                  width: 1,
                                ),
                                borderRadius: BorderRadius.circular(12)),
                          );
                        },
                      );
                    } else {
                      return Center(
                        child: CircularProgressIndicator(),
                      );
                    }
                  });
            },
          )
        ],
      ),
    );
  }
}
