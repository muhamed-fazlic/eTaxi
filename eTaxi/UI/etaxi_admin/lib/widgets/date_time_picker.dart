import 'package:flutter/material.dart';
import 'package:intl/intl.dart'; // Ensure you have the intl package for date formatting.

class CustomMaterialDateTimePicker extends StatefulWidget {
  final DateTime initialDate;
  final DateTime firstDate;
  final DateTime lastDate;
  final Function(DateTime) onChanged;

  const CustomMaterialDateTimePicker({
    Key? key,
    required this.initialDate,
    required this.firstDate,
    required this.lastDate,
    required this.onChanged,
  }) : super(key: key);

  @override
  _CustomMaterialDateTimePickerState createState() =>
      _CustomMaterialDateTimePickerState();
}

class _CustomMaterialDateTimePickerState
    extends State<CustomMaterialDateTimePicker> {
  late DateTime _selectedDate;
  late TextEditingController _controller;
  String? _errorText; // Variable to hold error text.

  @override
  void initState() {
    super.initState();
    _selectedDate = widget.initialDate;
    _controller = TextEditingController(
        text: DateFormat('dd.MM.yyyy HH:mm').format(_selectedDate));
  }

  @override
  void dispose() {
    _controller.dispose();
    super.dispose();
  }

  void _showDateTimePicker(BuildContext context) async {
    final DateTime? date = await showDatePicker(
      context: context,
      initialDate: _selectedDate,
      firstDate: widget.firstDate,
      lastDate: widget.lastDate,
    );
    if (date != null) {
      // Determine if the selected date is today to adjust initial and ending time.
      final bool isToday = date.year == DateTime.now().year &&
          date.month == DateTime.now().month &&
          date.day == DateTime.now().day;

      TimeOfDay initialTime = isToday
          ? TimeOfDay.fromDateTime(
              DateTime.now()) // Start from the current time if today
          : TimeOfDay(hour: 0, minute: 0); // Otherwise allow any time

      final TimeOfDay? time = await showTimePicker(
        context: context,
        initialTime: initialTime,
        builder: (BuildContext context, Widget? child) {
          return MediaQuery(
            data: MediaQuery.of(context).copyWith(
              alwaysUse24HourFormat: false,
            ),
            child: child!,
          );
        },
      );

      if (time != null) {
        final DateTime selectedDateTime =
            DateTime(date.year, date.month, date.day, time.hour, time.minute);
        if (isToday && selectedDateTime.isBefore(DateTime.now())) {
          setState(() {
            // Show error message directly in the dialog.
            _errorText = "Nije moguce odabrati vrijeme u proslosti. ";
            _selectedDate = DateTime.now();
            _controller.text =
                DateFormat('dd.MM.yyyy HH:mm').format(_selectedDate);
          });
        } else {
          setState(() {
            _selectedDate = selectedDateTime;
            _controller.text =
                DateFormat('dd.MM.yyyy HH:mm').format(_selectedDate);
            _errorText =
                null; // Clear error message when valid time is selected.
          });
          widget.onChanged(_selectedDate);
        }
      }
    }
  }

  @override
  Widget build(BuildContext context) {
    return TextField(
      controller: _controller,
      decoration: InputDecoration(
        labelText: 'Odaberi datum i vrijeme',
        errorText: _errorText, // Display error text when applicable.
        suffixIcon: Icon(Icons.calendar_today),
      ),
      readOnly: true,
      onTap: () => _showDateTimePicker(context),
    );
  }
}
