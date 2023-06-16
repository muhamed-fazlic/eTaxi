import 'package:etaxi_mobile/services/user_services.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:flutter/material.dart';

class ResetPasswordScreen extends StatefulWidget {
  const ResetPasswordScreen({Key? key}) : super(key: key);

  @override
  _ResetPasswordScreenState createState() => _ResetPasswordScreenState();
}

class _ResetPasswordScreenState extends State<ResetPasswordScreen> {
  TextEditingController emailController = TextEditingController();
  TextEditingController pwdController = TextEditingController();
  TextEditingController confPwdController = TextEditingController();
  TextEditingController pinController = TextEditingController();

  bool isPressed = false;
  String? error;
  GlobalKey<FormState> _formKey = GlobalKey<FormState>();

  resetPass() async {
    FocusScope.of(context).unfocus();
    if (_formKey.currentState!.validate()) {
      setState(() {
        isPressed = true;
        error = null;
      });
      final dataToSend = {
        'email': emailController.text,
        'password': pwdController.text,
        'confirmPassword': confPwdController.text,
        'pin': pinController.text
      };

      try {
        await UserServices.resetPassword(dataToSend);

        appSnackBar(
          context: context,
          msg: 'Uspjesno resetovana sifra',
          isError: false,
        );
        Navigator.of(context).pop();
      } catch (e) {
        setState(() {
          error = e.toString();
        });
      } finally {
        setState(() {
          isPressed = false;
        });
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return Scaffold(
      backgroundColor: Colors.white,
      body: SafeArea(
        child: SingleChildScrollView(
          padding: EdgeInsets.symmetric(horizontal: b * 28, vertical: h * 30),
          child: Form(
            key: _formKey,
            child: Column(
              crossAxisAlignment: CrossAxisAlignment.start,
              children: [
                InkWell(
                  highlightColor: Colors.transparent,
                  splashColor: Colors.transparent,
                  onTap: () {
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
                    ),
                  ),
                ),
                sh(15),
                sh(50),
                Text(
                  'Resetuj sifru',
                  style: TextStyle(
                    fontSize: b * 24,
                    fontWeight: FontWeight.w900,
                    letterSpacing: 0.5,
                  ),
                ),
                sh(30),
                CustomTextField(
                  label: 'Unesite pin iz vaseg email',
                  controller: pinController,
                  suffix: null,
                  isVisibilty: null,
                  inputType: TextInputType.number,
                ),
                sh(20),
                CustomTextField(
                  label: 'Upisite vas email',
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
                      return 'Email nije validan';
                    } else
                      return null;
                  },
                ),
                sh(20),
                CustomTextFieldPassword(
                  label: 'Sifra',
                  controller: pwdController,
                ),
                sh(20),
                CustomTextFieldPassword(
                  label: 'Ponovi sifru',
                  controller: confPwdController,
                ),
                sh(20),
                Center(
                    child: isPressed
                        ? LoadingButton()
                        : CustomButton(label: 'Resetuj', onPressed: resetPass)),
                if (error != null)
                  Padding(
                    padding: const EdgeInsets.all(8.0),
                    child: Text(
                      error!,
                      style: TextStyle(
                        color: Colors.red,
                        fontSize: b * 14,
                      ),
                    ),
                  ),
              ],
            ),
          ),
        ),
      ),
    );
  }
}
