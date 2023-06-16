import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class ContactUs extends StatefulWidget {
  @override
  _ContactUsState createState() => _ContactUsState();
}

class _ContactUsState extends State<ContactUs> {
  TextEditingController messageController = TextEditingController();
  TextEditingController emailController = TextEditingController();
  TextEditingController nameController = TextEditingController();
  TextEditingController phoneController = TextEditingController();

  bool isPressed = false;
  GlobalKey<FormState> _formKey = GlobalKey<FormState>();
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
          "Kontakt",
          style: TextStyle(
            fontSize: 18,
            fontWeight: FontWeight.w700,
          ),
        ),
      ),
      body: Column(
        children: [
          Expanded(
            child: Container(
              padding: EdgeInsets.only(left: 30, right: 30),
              child: SingleChildScrollView(
                physics: BouncingScrollPhysics(),
                child: Form(
                  key: _formKey,
                  child: Column(
                    crossAxisAlignment: CrossAxisAlignment.start,
                    children: [
                      sh(40),
                      Text('Ime'),
                      sh(10),
                      TextFormField(
                        controller: nameController,
                        validator: (val) {
                          if (nameController.text.trim() == "")
                            return 'Polje ne smije biti prazno';
                          else
                            return null;
                        },
                      ),
                      sh(20),
                      Text('Email'),
                      sh(10),
                      TextFormField(
                        controller: emailController,
                        validator: (value) {
                          Pattern emailPattern =
                              r'^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$';
                          RegExp regex = new RegExp(emailPattern.toString());
                          if (value!.isEmpty) {
                            return 'Polje ne smije biti prazno';
                          } else if ((!regex.hasMatch(value.trim()))) {
                            return "Email nije validan";
                          } else
                            return null;
                        },
                      ),
                      sh(20),
                      Text('Broj telefona'),
                      sh(10),
                      TextFormField(
                        controller: phoneController,
                        maxLength: 10,
                        validator: (val) {
                          if (phoneController.text.trim() == "")
                            return 'Polje ne smije biti prazno';
                          else if (phoneController.text.length != 10)
                            return "* Enter a valid number";
                          else
                            return null;
                        },
                      ),
                      sh(20),
                      Text('Vasa poruka'),
                      sh(10),
                      TextField(
                        controller: messageController,
                        maxLines: 6,
                        minLines: 6,
                      ),
                      sh(50),
                      MaterialButton(
                        height: 40,
                        minWidth: double.infinity,
                        color: Colors.black,
                        onPressed: () {},
                        child: Text(
                          'Posalji'.toUpperCase(),
                          style: TextStyle(
                              color: Colors.white, fontWeight: FontWeight.w700),
                        ),
                      ),
                    ],
                  ),
                ),
              ),
            ),
          ),
        ],
      ),
    );
  }
}
