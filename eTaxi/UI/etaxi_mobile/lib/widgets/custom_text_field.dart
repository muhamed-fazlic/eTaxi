import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:flutter/material.dart';

class CustomTextField extends StatelessWidget {
  CustomTextField({
    required this.label,
    required this.controller,
    this.suffix,
    this.isVisibilty,
    this.inputType,
    this.maxLines,
    this.size,
    this.spacing,
    this.minLines,
    this.vertPad,
    this.hint,
    this.validator,
    this.readOnly,
    this.maxLength,
    this.labelSize,
    this.isBold = false,
  });

  final String? label;
  final TextEditingController? controller;
  final Widget? suffix;
  final bool? isVisibilty;
  final TextInputType? inputType;
  final int? maxLines;
  final double? size;
  final double? spacing;
  final double? vertPad;
  final int? minLines;
  final String? hint;
  final String? Function(String?)? validator;
  final bool? readOnly;
  final int? maxLength;
  final double? labelSize;
  final bool? isBold;

  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var b = SizeConfig.screenWidth / 375;

    const outlineInputBorder = OutlineInputBorder(
      borderSide: BorderSide(
        color: borderColor,
      ),
    );
    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        if (label != null)
          Text(
            label!,
            style: TextStyle(
              fontWeight: isBold! ? FontWeight.w500 : FontWeight.w400,
              fontSize: labelSize ?? b * 14,
              color: Color(0xff3c3b3b),
            ),
          ),
        if (label != null) sh(10),
        TextFormField(
          key: key,
          readOnly: readOnly ?? false,
          validator: validator ??
              (val) {
                return null;
              },
          style: TextStyle(
            fontSize: size ?? b * 14,
            fontWeight: FontWeight.w500,
            letterSpacing: spacing ?? 0,
          ),
          maxLength: maxLength ?? null,
          controller: controller,
          keyboardType: inputType ?? TextInputType.text,
          maxLines: maxLines ?? 1,
          minLines: minLines ?? 1,
          decoration: InputDecoration(
            isDense: true,
            counterText: '',
            prefixIcon: suffix != null
                ? Row(
                    mainAxisSize: MainAxisSize.min,
                    children: [
                      sb(15),
                      suffix!,
                    ],
                  )
                : null,
            hintText: hint,
            hintStyle: TextStyle(
              fontSize: size ?? b * 14,
              fontWeight: FontWeight.w400,
              color: Colors.black.withOpacity(0.7),
              letterSpacing: spacing ?? 0,
            ),
            errorStyle: TextStyle(
              fontSize: b * 10,
              fontWeight: FontWeight.w400,
              color: warningColor,
              letterSpacing: spacing ?? 0,
            ),
            contentPadding: EdgeInsets.symmetric(
              horizontal: b * 12,
              vertical: vertPad ?? 12,
            ),
            focusedBorder: outlineInputBorder,
            focusedErrorBorder: OutlineInputBorder(
              borderSide: BorderSide(
                color: Colors.black,
              ),
            ),
            border: outlineInputBorder,
            errorBorder: OutlineInputBorder(
              borderSide: BorderSide(
                color: warningColor,
              ),
            ),
            enabledBorder: outlineInputBorder,
          ),
        )
      ],
    );
  }
}

class CustomTextFieldPassword extends StatefulWidget {
  CustomTextFieldPassword(
      {@required this.label,
      @required this.controller,
      this.inputType,
      this.size,
      this.spacing,
      this.vertPad,
      this.hint,
      this.validator,
      this.error = '',
      this.isMisMatch = false,
      this.onChanged});

  final String? label;
  final TextEditingController? controller;
  final TextInputType? inputType;
  final double? size;
  final double? spacing;
  final double? vertPad;
  final String? hint;
  final String? error;
  final String? Function(String?)? validator;
  bool? isMisMatch;
  final Function(String)? onChanged;
  @override
  _AppTextFieldPasswordState createState() => _AppTextFieldPasswordState();
}

class _AppTextFieldPasswordState extends State<CustomTextFieldPassword> {
  bool isVisibilty = false;
  @override
  Widget build(BuildContext context) {
    SizeConfig().init(context);
    var b = SizeConfig.screenWidth / 375;

    return Column(
      crossAxisAlignment: CrossAxisAlignment.start,
      children: [
        Text(
          widget.label!,
          style: TextStyle(
            fontSize: b * 14,
          ),
        ),
        sh(10),
        Container(
          padding: EdgeInsets.symmetric(
            horizontal: b * 12,
            vertical: widget.vertPad ?? 0,
          ),
          decoration: BoxDecoration(
            border: Border.all(
              color: widget.error != '' ? warningColor : borderColor,
            ),
            borderRadius: BorderRadius.circular(4),
          ),
          child: Row(
            children: [
              Expanded(
                child: TextFormField(
                  onChanged: widget.onChanged,
                  validator: widget.validator ??
                      (val) {
                        return null;
                      },
                  style: TextStyle(
                    fontSize: widget.size ?? b * 14,
                    fontWeight: FontWeight.w500,
                    letterSpacing: widget.spacing ?? 0,
                  ),
                  controller: widget.controller,
                  obscureText: !isVisibilty,
                  obscuringCharacter: "*",
                  keyboardType: widget.inputType ?? TextInputType.text,
                  maxLines: 1,
                  minLines: 1,
                  decoration: InputDecoration(
                    isDense: true,
                    hintText: widget.hint,
                    hintStyle: TextStyle(
                      fontSize: widget.size ?? b * 14,
                      fontWeight: FontWeight.w400,
                      color: Colors.black.withOpacity(0.8),
                      letterSpacing: widget.spacing ?? 0,
                    ),
                    errorStyle:
                        TextStyle(fontSize: 0, height: 0, color: warningColor),
                    contentPadding: EdgeInsets.symmetric(vertical: 12),
                    focusedBorder: InputBorder.none,
                    focusedErrorBorder: InputBorder.none,
                    border: InputBorder.none,
                    errorBorder: InputBorder.none,
                    enabledBorder: InputBorder.none,
                  ),
                ),
              ),
              InkWell(
                highlightColor: Colors.transparent,
                splashColor: Colors.transparent,
                onTap: () {
                  isVisibilty = !isVisibilty;
                  setState(() {});
                },
                child: Icon(
                  isVisibilty ? Icons.visibility : Icons.visibility_off,
                  size: 22,
                  color: Colors.black,
                ),
              ),
            ],
          ),
        ),
        sh(5),
        widget.error != ''
            ? widget.isMisMatch!
                ? Text(
                    widget.error!,
                    style: TextStyle(
                      fontSize: b * 10,
                      fontWeight: FontWeight.w400,
                      color: warningColor,
                    ),
                  )
                : Text(
                    widget.error!,
                    style: TextStyle(
                      fontSize: b * 10,
                      fontWeight: FontWeight.w400,
                      color: warningColor,
                    ),
                  )
            : sh(0),
      ],
    );
  }
}
