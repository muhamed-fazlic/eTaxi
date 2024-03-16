import 'dart:developer';

import 'package:etaxi_admin/models/user_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/services/user_service.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:etaxi_admin/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';

class UserDialog extends StatefulWidget {
  UserDialog({super.key, this.user});
  Userinfo? user;

  @override
  State<UserDialog> createState() => _UserDialogState();
}

class _UserDialogState extends State<UserDialog> {
  TextEditingController _nameController = TextEditingController();
  TextEditingController _surnameController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();

  GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    // TODO: implement initState
    if (widget.user != null) {
      _nameController.text = widget.user!.firstName!;
      _surnameController.text = widget.user!.lastName!;
      _emailController.text = widget.user!.email!;
    }
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      title:
          Text('${widget.user != null ? "Izmjeni" : "Dodaj novog"} korisnika'),
      content: Container(
        constraints: const BoxConstraints(minWidth: 500),
        child: SingleChildScrollView(
            child: Form(
          key: _formKey,
          child: Column(
            children: [
              CustomTextField(
                label: "Ime",
                controller: _nameController,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Polje ne moze biti prazno!';
                  } else
                    return null;
                },
              ),
              sh(5),
              CustomTextField(
                label: "Prezime",
                controller: _surnameController,
                validator: (value) {
                  if (value!.isEmpty) {
                    return 'Polje ne moze biti prazno!';
                  } else
                    return null;
                },
              ),
              sh(5),
              CustomTextField(
                label: "Email",
                controller: _emailController,
                validator: (value) {
                  Pattern emailPattern =
                      r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
                  RegExp regex = RegExp(emailPattern.toString());
                  if (value!.isEmpty) {
                    return 'Polje ne moze biti prazno!';
                  } else if ((!regex.hasMatch(value.trim()))) {
                    return 'Email nije validan!';
                  } else
                    return null;
                },
              ),
              CustomTextField(
                label: 'Broj telefona',
                controller: _phoneController,
                maxLength: 10,
                suffix: const Text(
                  "+387 ",
                  style: TextStyle(
                    fontSize: 14,
                    fontWeight: FontWeight.w500,
                  ),
                ),
                isVisibilty: null,
                inputType: TextInputType.number,
                validator: (val) {
                  RegExp phoneRegex = RegExp(r'^\d{8,9}$');
                  if (val?.trim() == "")
                    return 'Polje ne smije biti prazno';
                  else if (!phoneRegex.hasMatch(val!))
                    return "Broj nije validan. Treba da sadrzi 8 ili 9 cifara! ";
                  else
                    return null;
                },
              ),
              sh(5),
            ],
          ),
        )),
      ),
      actions: [
        CustomButton(
          vertPad: 5,
          height: 45,
          fontSize: 16,
          width: 200,
          onPressed: () async {
            if (!_formKey.currentState!.validate()) {
              return null;
            }
            var data = {
              "firstName": _nameController.text,
              "lastName": _surnameController.text,
              "email": _emailController.text,
            };
            try {
              if (widget.user != null) {
                data["id"] = widget.user!.id.toString();
                await UserServices.editUser(data);
              } else {
                await UserServices.addUser(data);
              }
              AuthProvider.instance.resetStateFunction();
              appSnackBar(
                  context: context,
                  msg:
                      "Uspjeno ${widget.user != null ? 'izmjenjen' : "dodan"} korisnik",
                  isError: false);
            } catch (e) {
              log("ERROR ADDING/EDITING USER: $e");
            }
            Navigator.pop(context);
          },
          label: widget.user != null ? "Izmjeni" : 'Dodaj',
        ),
      ],
    );
  }
}
