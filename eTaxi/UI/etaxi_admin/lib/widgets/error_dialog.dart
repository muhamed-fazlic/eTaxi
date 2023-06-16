import 'package:flutter/material.dart';

class ErrorDialog extends StatelessWidget {
  ErrorDialog({super.key, this.message});
  String? message;

  @override
  Widget build(BuildContext context) {
    return AlertDialog(
      icon: Icon(Icons.error),
      title: Text('Error'),
      content: SingleChildScrollView(
        child: Column(
          mainAxisSize: MainAxisSize.min,
          children: [
            Text('Doslo je do greske!'),
            if (message != null) Text(message!),
          ],
        ),
      ),
    );
  }
}
