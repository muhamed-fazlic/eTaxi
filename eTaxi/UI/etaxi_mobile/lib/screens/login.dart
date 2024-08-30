import 'dart:developer';

import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/screens/forgot_password.dart';
import 'package:etaxi_mobile/screens/mode_selector.dart';
import 'package:etaxi_mobile/screens/register.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/services/home_service.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
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
          builder: (_) => ModeSelectorScreen(),
        ),
      );
    } catch (e) {
      print(e.toString());
      AuthProvider.instance.setError(e.toString(), 'login');
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
        child: Column(children: [
          SizedBox(
            height: 30,
          ),
          Image.asset(
            'assets/images/login_illus.png',
            width: 178,
            height: 133,
          ),
          SizedBox(
            height: 50,
          ),
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
                  SizedBox(height: 30),
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
                  SizedBox(height: 20),
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
                    },
                  ),
                  SizedBox(height: 20),
                  InkWell(
                      onTap: () => {
                            Navigator.of(context).push(MaterialPageRoute(
                                builder: (_) => const ForgotPasswordScreen()))
                          },
                      child: Text('Zaboravljena sifra?',
                          style: TextStyle(
                              fontWeight: FontWeight.w700,
                              color: Colors.black,
                              fontSize: 14))),
                  SizedBox(height: 20),
                  Center(
                      child: isPressed
                          ? LoadingButton()
                          : CustomButton(
                              label: 'Login',
                              onPressed: () async {
                                FocusScope.of(context).unfocus();
                                if (!_formKey.currentState!.validate())
                                  return null;

                                setState(() {
                                  isPressed = true;
                                });
                                login();
                              },
                            )),
                  SizedBox(height: 10),
                  Consumer<AuthProvider>(
                      builder: (context, authProvider, child) {
                    if (authProvider.loginError != null) {
                      return Center(
                        child: Text(
                          authProvider.loginError!,
                          style: TextStyle(
                            color: Colors.red,
                            fontSize: 14,
                          ),
                        ),
                      );
                    } else {
                      return Container();
                    }
                  }),
                  SizedBox(height: 20),
                  Row(mainAxisAlignment: MainAxisAlignment.center, children: [
                    Text(
                      'Nemate kreiran racun? ',
                      style: TextStyle(
                        fontSize: 14,
                        fontWeight: FontWeight.w700,
                      ),
                    ),
                    InkWell(
                      onTap: () {
                        Navigator.of(context).push(
                          MaterialPageRoute(
                            builder: (_) => const RegisterScreen(),
                          ),
                        );
                      },
                      child: Text(
                        'Napravi racun',
                        style: TextStyle(
                          fontSize: 14,
                          fontWeight: FontWeight.w700,
                          color: secondaryColor,
                        ),
                      ),
                    ),
                  ]),
                ],
              ))
        ]),
      )),
    );
  }

  @override
  void dispose() {
    super.dispose();
  }
}
