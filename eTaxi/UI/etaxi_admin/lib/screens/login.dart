import 'dart:developer';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/screens/layout_page.dart';
import 'package:etaxi_admin/services/user_service.dart';
import 'package:etaxi_admin/utils/sizeConfig.dart';
import 'package:etaxi_admin/widgets/app_snack_bar.dart';
import 'package:etaxi_admin/widgets/custom_button.dart';
import 'package:etaxi_admin/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class LoginScreen extends StatefulWidget {
  LoginScreen({Key? key}) : super(key: key);

  @override
  _LoginScreenState createState() => _LoginScreenState();
}

class _LoginScreenState extends State<LoginScreen> {
  TextEditingController emailController = TextEditingController();
  TextEditingController pwdController = TextEditingController();
  bool isVisibilty = false;
  bool isPressed = false;
  String passwordError = '';
  bool isError = false;

  GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  @override
  void initState() {
    emailController.text = 'admin@admin.com';
    pwdController.text = 'test12345';
    super.initState();
  }

  login() async {
    final dataToSend = {
      'email': emailController.text,
      'password': pwdController.text
    };
    try {
      await UserServices.loginService(dataToSend);

      Navigator.of(context).pushReplacement(
        MaterialPageRoute(
          builder: (_) => LayoutPageAdmin(),
        ),
      );
    } catch (e) {
      print(e);
      AuthProvider.instance.setError(e, 'login');
    } finally {
      setState(() {
        isPressed = false;
      });
    }
  }

  @override
  Widget build(BuildContext context) {
    AuthProvider authProvider =
        Provider.of<AuthProvider>(context, listen: false);

    return Scaffold(
      backgroundColor: Colors.white,
      body: SafeArea(
          child: SingleChildScrollView(
        padding: EdgeInsets.symmetric(horizontal: 30, vertical: 16),
        child: Center(
          child: SizedBox(
            width: MediaQuery.of(context).size.width / 2.5,
            child: Column(children: [
              sh(30),
              Image.asset(
                'assets/images/login_illus.png',
                width: 178,
                height: 133,
              ),
              sh(50),
              Form(
                  key: _formKey,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      Text('Login',
                          style: TextStyle(
                              fontSize: 24,
                              fontWeight: FontWeight.w900,
                              letterSpacing: 0.65)),
                      sh(30),
                      CustomTextField(
                        controller: emailController,
                        label: 'Unesite email',
                        validator: (value) {
                          Pattern emailPattern =
                              r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
                          RegExp regex = new RegExp(emailPattern.toString());
                          if (value!.isEmpty) {
                            setState(() {
                              isError = true;
                            });
                            return 'Polje ne moze biti prazno!';
                          } else if ((!regex.hasMatch(value.trim()))) {
                            setState(() {
                              isError = true;
                            });
                            return 'Email nije validan!';
                          } else
                            return null;
                        },
                      ),
                      sh(20),
                      CustomTextFieldPassword(
                        controller: pwdController,
                        onChanged: (value) {
                          authProvider.setError(null, 'login');
                        },
                        label: 'Enter password',
                        error: passwordError,
                        validator: (val) {
                          if (val!.trim() == "") {
                            setState(() {
                              passwordError = 'Polje ne smije biti prazno';
                            });
                            //  return 'Field cannot be empty';
                          } else {
                            setState(() {
                              passwordError = '';
                            });
                            return null;
                          }
                          return null;
                        },
                      ),
                      sh(20),
                      sh(20),
                      Center(
                          child: CustomButton(
                        label: 'Login',
                        onPressed: () async {
                          FocusScope.of(context).unfocus();
                          if (!_formKey.currentState!.validate()) return null;

                          isPressed = true;
                          setState(() {});
                          login();
                        },
                      )),
                      sh(20),
                      Consumer<AuthProvider>(
                        builder: (context, authProvider, _) {
                          return authProvider.loginError != null
                              ? Center(
                                  child: Text(
                                    authProvider.loginError!,
                                    style: TextStyle(
                                        color: Colors.red, fontSize: 16),
                                  ),
                                )
                              : Container();
                        },
                      ),
                      sh(20),
                    ],
                  ))
            ]),
          ),
        ),
      )),
    );
  }

  @override
  void dispose() {
    super.dispose();
  }
}
