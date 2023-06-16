import 'dart:developer';
import 'dart:io';
import 'dart:typed_data';

import 'package:etaxi_mobile/models/user_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';
import 'package:image_picker/image_picker.dart';

class ProfilePage extends StatefulWidget {
  const ProfilePage({Key? key}) : super(key: key);

  @override
  State<ProfilePage> createState() => _ProfilePageState();
}

class _ProfilePageState extends State<ProfilePage> {
  List<String> _imagePaths = [];
  TextEditingController _nameController = TextEditingController();
  TextEditingController _emailController = TextEditingController();
  TextEditingController _surnameController = TextEditingController();
  TextEditingController _phoneController = TextEditingController();

  bool isPressed = false;

  @override
  void initState() {
    getUserProfile();

    super.initState();
  }

  void getUserProfile() async {
    var userDecoded =
        await UserServices.getUser(AuthProvider.instance.user!.id!);
    var user = Userinfo.fromJson(userDecoded);
    //add user data to text controllers
    _nameController.text = user.firstName!;
    _surnameController.text = user.lastName!;
    _emailController.text = user.email!;

    //check any files from user
    var userFiles = user.files;
    if (userFiles != null && userFiles.isNotEmpty) {
      var newImagePaths = <String>[];
      userFiles.forEach((file) {
        newImagePaths.add(formatFileUrl(file.url));
      });
      setState(() {
        _imagePaths = newImagePaths;
      });
    }
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
          "Profil",
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
                CustomTextField(label: "Ime", controller: _nameController),
                sh(20),
                CustomTextField(
                    label: "Prezime", controller: _surnameController),
                sh(20),
                CustomTextField(
                  label: "Email",
                  controller: _emailController,
                  readOnly: true,
                ),
                sh(20),
                CustomTextField(
                    label: "Broj telefona", controller: _phoneController),
                sh(20),
                Text('Dokumenti'),
                sh(10),
                Wrap(
                  runSpacing: 8,
                  spacing: 8,
                  children: [
                    GestureDetector(
                      behavior: HitTestBehavior.opaque,
                      onTap: () async {
                        final imageSource = await showDialog<ImageSource>(
                            context: context,
                            builder: (context) => AlertDialog(
                                  title: Text("Odaberi izvor slike"),
                                  actions: <Widget>[
                                    CustomButton(
                                      label: "Kamera",
                                      onPressed: () => Navigator.pop(
                                          context, ImageSource.camera),
                                    ),
                                    sh(10),
                                    CustomButton(
                                      label: "Galerija",
                                      onPressed: () => Navigator.pop(
                                          context, ImageSource.gallery),
                                    )
                                  ],
                                ));
                        if (imageSource != null) {
                          XFile? file = await ImagePicker()
                              .pickImage(source: imageSource);
                          if (file != null) {
                            setState(() => {
                                  _imagePaths.add(file.path),
                                });
                          }
                        }
                      },
                      child: Container(
                        height: 100,
                        width: 100,
                        decoration: BoxDecoration(
                            borderRadius: BorderRadius.circular(6),
                            border: Border.all(color: Colors.grey.shade400)),
                        child: Center(
                          child: Icon(Icons.add_a_photo),
                        ),
                      ),
                    ),
                    ..._imagePaths.map((e) => Container(
                          height: 100,
                          width: 100,
                          decoration: BoxDecoration(
                              borderRadius: BorderRadius.circular(6),
                              image: DecorationImage(
                                  fit: BoxFit.cover,
                                  image: e.contains("http")
                                      ? Image.network(e).image
                                      : Image.file(File(e)).image)),
                        ))
                  ],
                ),
                sh(20),
                isPressed
                    ? LoadingButton()
                    : CustomButton(
                        label: 'Sacuvaj',
                        onPressed: () async {
                          setState(() {
                            isPressed = true;
                          });
                          var userDataToUpdate = {
                            "id": AuthProvider.instance.user!.id,
                            "firstName": _nameController.text,
                            "lastName": _surnameController.text,
                            "phone": _phoneController.text,
                            // "email": _emailController.text,
                          };

                          try {
                            if (_imagePaths.isNotEmpty) {
                              await UserServices.uploadUserFiles(_imagePaths);
                            }
                            await UserServices.updateUser(userDataToUpdate);
                            appSnackBar(
                                context: context,
                                msg: 'Uspjesno izmjenjeno',
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
