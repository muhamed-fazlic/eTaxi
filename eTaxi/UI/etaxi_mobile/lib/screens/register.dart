import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/screens/login.dart';
import 'package:etaxi_mobile/screens/mode_selector.dart';
import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';
import 'package:provider/provider.dart';

class RegisterScreen extends StatefulWidget {
  const RegisterScreen({Key? key}) : super(key: key);

  @override
  _RegisterScreenState createState() => _RegisterScreenState();
}

class _RegisterScreenState extends State<RegisterScreen> {
  final GlobalKey<FormState> _formKey = GlobalKey<FormState>();
  TextEditingController firstNameController = TextEditingController();
  TextEditingController lastNameController = TextEditingController();

  TextEditingController emailController = TextEditingController();
  TextEditingController phoneController = TextEditingController();
  TextEditingController pwdController = TextEditingController();
  TextEditingController confPwdController = TextEditingController();

  bool isPwdVisible = false;
  bool isConfVisible = false;

  bool isPressed = false;

  String passwordError = '';
  bool isError1 = false;

  bool isMisMatch = false;

  @override
  void initState() {
    // emailController.text = 'email@email.com';
    // pwdController.text = 'Sifra123_';
    // confPwdController.text = 'Sifra123_';
    // phoneController.text = '603572781';
    // firstNameController.text = 'Bilal';
    // lastNameController.text = "Hodzic";
    super.initState();
  }

  register() async {
    final dataToSend = {
      "firstName": firstNameController.text,
      "lastName": lastNameController.text,
      'userName': firstNameController.text + lastNameController.text,
      'password': pwdController.text,
      "email": emailController.text,
      "confirmPassword": confPwdController.text,
      "phoneNumber": phoneController.text,
    };
    try {
      await UserServices.registerService(dataToSend);
      Navigator.of(context).pushReplacement(
        MaterialPageRoute(
          builder: (_) => LoginScreen(),
        ),
      );
    } catch (e) {
      print(e);
      AuthProvider.instance.setError(e.toString(), 'register');
    } finally {
      if (mounted) {
        setState(() {
          isPressed = false;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var b = SizeConfig.screenWidth / 375;
    // ignore: unused_local_variable
    final auth = Provider.of<AuthProvider>(context);

    return Scaffold(
      body: SafeArea(
        child: SingleChildScrollView(
          physics: ClampingScrollPhysics(),
          child: Column(
            crossAxisAlignment: CrossAxisAlignment.start,
            mainAxisAlignment: MainAxisAlignment.center,
            children: [
              sh(10),
              TextButton(
                onPressed: () {
                  Navigator.of(context).pop();
                },
                child: Container(
                  padding: EdgeInsets.only(left: b * 7),
                  width: b * 30,
                  height: b * 30,
                  decoration: BoxDecoration(
                    shape: BoxShape.circle,
                    color: Color(0xffc4c4c4).withOpacity(0.4),
                  ),
                  child: Icon(
                    Icons.arrow_back_ios,
                    size: b * 16,
                    color: Colors.black,
                  ),
                ),
              ),
              Padding(
                padding: EdgeInsets.symmetric(horizontal: b * 30),
                child: Form(
                  key: _formKey,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      sh(20),
                      Text(
                        'Kreiraj svoj racun',
                        style: TextStyle(
                          fontWeight: FontWeight.w900,
                          fontSize: b * 24,
                          letterSpacing: 0.5,
                        ),
                      ),
                      sh(30),
                      CustomTextField(
                        label: 'Ime',
                        controller: firstNameController,
                        suffix: null,
                        isVisibilty: null,
                        validator: (val) {
                          if (firstNameController.text.trim() == "")
                            return 'Polje ne smije biti prazno';
                          else
                            return null;
                        },
                      ),
                      sh(20),
                      CustomTextField(
                        label: 'Prezime',
                        controller: lastNameController,
                        suffix: null,
                        isVisibilty: null,
                        validator: (val) {
                          if (lastNameController.text.trim() == "")
                            return 'Polje ne smije biti prazno';
                          else
                            return null;
                        },
                      ),
                      sh(20),
                      CustomTextField(
                        label: 'Email',
                        controller: emailController,
                        suffix: null,
                        isVisibilty: null,
                        validator: (value) {
                          Pattern emailPattern =
                              r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
                          RegExp regex = new RegExp(emailPattern.toString());
                          if (value!.isEmpty) {
                            return 'Polje ne smije biti prazno';
                          } else if ((!regex.hasMatch(value.trim()))) {
                            return 'Email nije ispravan';
                          } else
                            return null;
                        },
                      ),
                      sh(20),
                      CustomTextField(
                        label: 'Broj telefona',
                        controller: phoneController,
                        maxLength: 10,
                        suffix: Text(
                          "+387",
                          style: TextStyle(
                            fontSize: b * 14,
                            fontWeight: FontWeight.w500,
                          ),
                        ),
                        isVisibilty: null,
                        inputType: TextInputType.number,
                        validator: (val) {
                          if (phoneController.text.trim() == "")
                            return 'Polje ne smije biti prazno';
                          else if (phoneController.text.length != 9)
                            return "* Enter a valid number";
                          else
                            return null;
                        },
                      ),
                      sh(20),
                      CustomTextFieldPassword(
                        label: 'Sifra',
                        controller: pwdController,
                        // isMisMatch: isMisMatch,
                        error: passwordError,
                        validator: (val) {
                          Pattern passwordPattern =
                              r'^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$';
                          RegExp regex = RegExp(passwordPattern.toString());

                          if (val!.isEmpty) {
                            // isError = true;
                            setState(() {
                              passwordError = 'Polje ne smije biti prazno';
                            });
                            //return 'Polje ne smije biti prazno';
                          } else if (!regex.hasMatch(pwdController.text)) {
                            setState(() {
                              passwordError =
                                  'Sifra mora biti imati min 8 karaktera, broj i veliko slovo';
                            });
                            //return 'Sifra mora biti imati min 8 karaktera, broj i veliko slovo';
                          } else if (confPwdController.text !=
                              pwdController.text) {
                            setState(() {
                              isMisMatch = true;
                              passwordError = 'Sifra se ne poklapa';
                            });
                            // return 'Sifra se ne poklapa';
                          } else {
                            setState(() {
                              passwordError = '';
                            });
                            return null;
                          }
                        },
                      ),
                      sh(20),
                      CustomTextFieldPassword(
                        label: 'Ponovi sifru',
                        //isMisMatch: isMisMatch,
                        controller: confPwdController,
                        // error: isError1,
                        validator: (val) {
                          if (confPwdController.text.trim() == "") {
                            setState(() {
                              isError1 = true;
                            });
                            return 'Polje ne smije biti prazno';
                          } else if (confPwdController.text !=
                              pwdController.text) {
                            setState(() {
                              isMisMatch = true;
                              isError1 = true;
                            });
                            return 'Sifra se ne poklapa';
                          } else {
                            setState(() {
                              isMisMatch = false;
                              isError1 = false;
                            });
                            return null;
                          }
                        },
                      ),
                      sh(20),
                      Consumer<AuthProvider>(builder: (_, notifier, __) {
                        if (notifier.registerError != null) {
                          return Column(
                            children: [
                              Text(
                                notifier.registerError!,
                                style: TextStyle(color: warningColor),
                              ),
                              sh(20)
                            ],
                          );
                        }

                        return const SizedBox();
                      }),
                      isPressed
                          ? LoadingButton()
                          : CustomButton(
                              label: 'Registracija',
                              onPressed: () async {
                                FocusScope.of(context).unfocus();
                                if (!_formKey.currentState!.validate())
                                  return null;
                                if (pwdController.text.trim().length < 8) {
                                  appSnackBar(
                                    context: context,
                                    msg:
                                        'Sifra mora imati najmanje 8 karaktera',
                                    isError: true,
                                  );
                                } else {
                                  setState(() {
                                    isPressed = true;
                                  });

                                  register();
                                }
                              },
                            ),
                      sh(15),
                      Row(
                        children: [
                          Expanded(
                            child: Container(
                              margin: EdgeInsets.only(right: b * 10),
                              height: 1,
                              color: Color(0xffe4e4e4),
                            ),
                          ),
                          Text(
                            'ili'.toUpperCase(),
                            style: TextStyle(
                              fontSize: b * 12,
                              color: Color(0xffe4e4e4),
                            ),
                          ),
                          Expanded(
                            child: Container(
                              margin: EdgeInsets.only(left: b * 10),
                              height: 1,
                              color: Color(0xffe4e4e4),
                            ),
                          ),
                        ],
                      ),
                      sh(20),
                      Row(
                        mainAxisAlignment: MainAxisAlignment.center,
                        children: [
                          Text(
                            'Vec imate racun? ',
                            style: TextStyle(
                              fontSize: b * 14,
                              fontWeight: FontWeight.w700,
                            ),
                          ),
                          InkWell(
                            onTap: () {
                              Navigator.of(context).pop();
                            },
                            child: Text(
                              'Login',
                              style: TextStyle(
                                fontSize: b * 14,
                                color: secondaryColor,
                                fontWeight: FontWeight.w700,
                                letterSpacing: 0.5,
                              ),
                            ),
                          )
                        ],
                      ),
                      sh(30),
                    ],
                  ),
                ),
              )
            ],
          ),
        ),
      ),
    );
  }
}
