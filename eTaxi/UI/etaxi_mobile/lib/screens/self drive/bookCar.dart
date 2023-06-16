import 'package:dropdown_below/dropdown_below.dart';
import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/current_loc_model.dart';
import 'package:etaxi_mobile/models/hub_model.dart';
import 'package:etaxi_mobile/models/vehicle_model.dart';
import 'package:etaxi_mobile/providers/home_provider.dart';
import 'package:etaxi_mobile/screens/self%20drive/checkoutPage.dart';
import 'package:etaxi_mobile/services/home_service.dart';
import 'package:etaxi_mobile/utils/appBar.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/utils/utilFunctions.dart';
import 'package:etaxi_mobile/widgets/app_snack_bar.dart';
import 'package:etaxi_mobile/widgets/custom_button.dart';
import 'package:etaxi_mobile/widgets/custom_text_field.dart';
import 'package:etaxi_mobile/widgets/swipe_car_container.dart';
import 'package:etaxi_mobile/widgets/vehicle_tags.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:place_picker/place_picker.dart';
import 'package:provider/provider.dart';

class BookCar extends StatefulWidget {
  final VehicleModel? vehicle;
  final bool? isUpdate;
  final bool? limited;
  // final BookingHistoryModel? booking;
  BookCar(
      {Key? key,
      required this.vehicle,
      this.isUpdate = false,
      // this.booking,
      this.limited = true})
      : super(key: key);

  @override
  _BookCarState createState() => _BookCarState();
}

class _BookCarState extends State<BookCar> {
  bool limited = true;
  String startDate = DateTime.now().toString().substring(0, 10);
  String endDate =
      DateTime.now().add(Duration(days: 1)).toString().substring(0, 10);

  String startDateFormatted = '';
  String endDateFormatted = '';

  CurrentLoc? currentLoc;

  String selectedPickCity = 'Grad preuzimanja';
  String selectedDropCity = 'Grad dostave';
  String? selectedPickCityID;
  String? selectedDropCityID;

  bool isManualAddrPick = false, isManualAddrDrop = false;

  TextEditingController pickUpAdd = TextEditingController();
  TextEditingController dropOffAdd = TextEditingController();
  TextEditingController estKm = TextEditingController();

  LatLng? pickCoordinates, dropCoordinates;
  String? pickCityFromMap, dropCityFromMap;
  bool isPressed = false;

  Future<void>? getCities;

  @override
  void initState() {
    super.initState();
  }

  formateDateTime() async {
    startDateFormatted = startDate +
        " " +
        startTime!.hour.toString().padLeft(2, '0') +
        ":" +
        startTime!.minute.toString().padLeft(2, '0') +
        ":00";

    endDateFormatted = endDate +
        " " +
        endTime!.hour.toString().padLeft(2, '0') +
        ":" +
        endTime!.minute.toString().padLeft(2, '0') +
        ":00";
  }

  void showPlacePicker(int type) async {
    LocationResult? result = await Navigator.of(context).push(
      MaterialPageRoute(
        builder: (context) => PlacePicker(
          googleApiKey,
        ),
      ),
    );

    if (result == null) return;
    if (type == 0) {
      pickCityFromMap = result.city!.name!;

      pickUpAdd.text = result.formattedAddress ?? "";
      pickCoordinates = result.latLng;
    } else {
      dropCityFromMap = result.city!.name!;
      {
        dropOffAdd.text = result.formattedAddress ?? "";
        dropCoordinates = result.latLng;
      }
    }

    setState(() {});
  }

  @override
  Widget build(BuildContext context) {
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;
    var edgeInsets = EdgeInsets.fromLTRB(
      b * 16,
      h * 0,
      b * 16,
      h * 0,
    );
    var textStyle = TextStyle(
      fontSize: b * 11,
      color: Color(0xff3C3B3B),
      fontWeight: FontWeight.w400,
      letterSpacing: 0.6,
    );

    final provider = Provider.of<HomeProvider>(context);
    return DefaultTabController(
      initialIndex: widget.limited! ? 0 : 1,
      length: 2,
      child: Scaffold(
        appBar: appBarCommon(context, h, b, "Odaberi auto"),
        body: Column(
          children: [
            Expanded(
              child: Container(
                decoration: constBoxDecoration,
                child: SingleChildScrollView(
                  physics: ClampingScrollPhysics(),
                  child: Form(
                    child: Column(
                      crossAxisAlignment: CrossAxisAlignment.start,
                      children: [
                        sh(10),
                        SwipeCar(
                          imgUrl: widget.vehicle!.photo!,
                          vehicleId: widget.vehicle!.vehicleId!.toString(),
                        ),
                        sh(10),
                        Padding(
                          padding: EdgeInsets.symmetric(horizontal: b * 30),
                          child: Column(
                            crossAxisAlignment: CrossAxisAlignment.start,
                            children: [
                              Row(
                                mainAxisSize: MainAxisSize.max,
                                mainAxisAlignment:
                                    MainAxisAlignment.spaceBetween,
                                crossAxisAlignment: CrossAxisAlignment.start,
                                children: [
                                  Expanded(
                                    flex: 3,
                                    child: Column(
                                      crossAxisAlignment:
                                          CrossAxisAlignment.start,
                                      children: [
                                        Text(
                                          widget.vehicle!.vehicleName!,
                                          style: TextStyle(
                                            fontWeight: FontWeight.w500,
                                            fontSize: b * 16,
                                          ),
                                        ),
                                        sh(10),
                                        Text(
                                          widget.vehicle!.price!.toString(),
                                          style: TextStyle(
                                            color: secondaryColor,
                                            fontSize: b * 14,
                                            fontWeight: FontWeight.w700,
                                          ),
                                        ),
                                        sh(5),
                                        Text(
                                          'Self drive vozilo',
                                          style: TextStyle(
                                            color: Color(0xff999999),
                                            fontSize: b * 12,
                                            fontWeight: FontWeight.w500,
                                          ),
                                        ),
                                        sh(10),
                                        Wrap(
                                          runSpacing: h * 5,
                                          children: [
                                            VehicleTags(
                                              txt: widget.vehicle!.seater
                                                  .toString(),
                                              size: b * 12,
                                            ),
                                            sb(6),
                                            VehicleTags(
                                              txt: widget.vehicle!.fuelType,
                                              size: b * 12,
                                            ),
                                            sb(6),
                                            VehicleTags(
                                              txt: widget.vehicle!.transmission,
                                              size: b * 12,
                                            ),
                                            widget.vehicle!.airBags == "Yes"
                                                ? sb(6)
                                                : sh(0),
                                            widget.vehicle!.airBags == "Yes"
                                                ? VehicleTags(
                                                    txt: "Air Bags",
                                                    size: b * 12,
                                                  )
                                                : sh(0),
                                            sb(6),
                                            VehicleTags(
                                              txt: widget.vehicle!.year
                                                  .toString(),
                                              size: b * 12,
                                            ),
                                          ],
                                        ),
                                      ],
                                    ),
                                  ),
                                ],
                              ),
                              sh(20),
                              Container(
                                color: Color(0xfff2f2f2),
                                width: SizeConfig.screenWidth,
                                height: h * 2,
                              ),
                              sh(10),
                              Text(
                                'Grad preuzimanja',
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              Container(
                                width: SizeConfig.screenWidth,
                                padding: EdgeInsets.symmetric(
                                    horizontal: b * 15, vertical: h * 12),
                                decoration: BoxDecoration(
                                  border: Border.all(color: borderColor),
                                  borderRadius: BorderRadius.circular(4),
                                ),
                                child: Text(
                                  selectedPickCity,
                                  style: TextStyle(
                                    fontSize: b * 11,
                                    letterSpacing: 0.6,
                                    color: Colors.black.withOpacity(0.8),
                                  ),
                                ),
                              ),
                              sh(20),
                              Text(
                                'Adresa preuzimanja',
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              Container(
                                width: SizeConfig.screenWidth,
                                decoration: BoxDecoration(
                                  border: Border.all(color: borderColor),
                                  borderRadius: BorderRadius.circular(4),
                                ),
                                child: FutureBuilder(
                                    future: HomeService.getHubs(),
                                    builder: (context, snap) {
                                      if (snap.connectionState ==
                                          ConnectionState.done) {
                                        List<DropdownMenuItem> menuItem = [];

                                        menuItem.add(
                                          DropdownMenuItem<int>(
                                            child: Row(
                                              children: [
                                                Icon(
                                                  Icons.my_location,
                                                  size: b * 16,
                                                ),
                                                sb(10),
                                                Text(
                                                  "Odaberi adresu",
                                                  style: textStyle,
                                                ),
                                              ],
                                            ),
                                            value: -1,
                                          ),
                                        );

                                        menuItem
                                            .addAll(provider.allHub.map((e) {
                                          return DropdownMenuItem(
                                            child: Text(e.address),
                                            value: e.id,
                                          );
                                        }).toList());

                                        return DropdownBelow(
                                          boxHeight: h * 48,
                                          boxPadding: edgeInsets,
                                          itemWidth:
                                              SizeConfig.screenWidth - b * 60,
                                          itemTextstyle: textStyle,
                                          boxTextstyle: textStyle,
                                          boxWidth:
                                              SizeConfig.screenWidth - b * 60,
                                          icon: SvgPicture.asset(
                                            'assets/icons/drop_down_icon.svg',
                                            height: h * 8,
                                          ),
                                          hint: Text(
                                            pickUpAdd.text == ''
                                                ? 'Adresa preuzimanja'
                                                : pickUpAdd.text,
                                            maxLines: 2,
                                            overflow: TextOverflow.ellipsis,
                                            style: textStyle,
                                          ),
                                          items: menuItem,
                                          value: null,
                                          onChanged: (val) {
                                            if (val == -1) {
                                              showPlacePicker(0);
                                            } else {
                                              final selectedHub =
                                                  provider.allHub.where((ele) {
                                                return ele.id == val
                                                    ? true
                                                    : false;
                                              }).first;
                                              selectedPickCity =
                                                  selectedHub.city;
                                              pickUpAdd.text =
                                                  selectedHub.address;
                                              pickCoordinates = LatLng(
                                                  selectedHub.latitude,
                                                  selectedHub.longitude);
                                              isManualAddrPick = false;
                                              setState(() {});
                                            }
                                          },
                                        );
                                      }
                                      return Container(
                                        height: h * 48,
                                        padding: edgeInsets,
                                        alignment: Alignment.centerLeft,
                                        width: SizeConfig.screenWidth,
                                        child: Text(
                                          pickUpAdd.text == ''
                                              ? 'Izaberite adresu preuzimanja'
                                              : pickUpAdd.text,
                                          style: textStyle,
                                        ),
                                      );
                                    }),
                              ),
                              sh(20),
                              Text(
                                'Grad dostave',
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              Container(
                                width: SizeConfig.screenWidth,
                                decoration: BoxDecoration(
                                  border:
                                      Border.all(color: Color(0xffe5e5e5e5)),
                                  borderRadius: BorderRadius.circular(4),
                                ),
                                child: FutureBuilder(
                                  future: HomeService.getHubs(),
                                  builder: (context, snap) {
                                    if (snap.connectionState ==
                                        ConnectionState.done)
                                      return DropdownBelow(
                                        boxHeight: h * 35,
                                        itemWidth:
                                            SizeConfig.screenWidth - b * 60,
                                        itemTextstyle: TextStyle(
                                          fontSize: b * 13,
                                          color: Color(0xff3C3B3B),
                                          fontWeight: FontWeight.w400,
                                          letterSpacing: 0.6,
                                        ),
                                        boxPadding: edgeInsets,
                                        boxTextstyle: textStyle,
                                        boxWidth: SizeConfig.screenWidth,
                                        icon: SvgPicture.asset(
                                          'assets/icons/drop_down_icon.svg',
                                          height: h * 8,
                                        ),
                                        hint: Text(
                                          selectedDropCity !=
                                                  "Krajnja destinacija"
                                              ? selectedDropCity
                                              : 'Grad dostave',
                                          style: textStyle,
                                          maxLines: 2,
                                          overflow: TextOverflow.ellipsis,
                                        ),
                                        value: null,
                                        items: provider.allHub.map((e) {
                                          return DropdownMenuItem(
                                            child: Text(e.city),
                                            value: e,
                                          );
                                        }).toList(),
                                        onChanged: (Hub? val) {
                                          dropOffAdd.clear();
                                          selectedDropCityID = val!.name;
                                          selectedDropCity = val.name;

                                          setState(() {});
                                        },
                                      );
                                    else
                                      return Container(
                                        height: h * 35,
                                        padding: edgeInsets,
                                        alignment: Alignment.centerLeft,
                                        width: SizeConfig.screenWidth,
                                        child: Text(
                                          currentLoc != null
                                              ? selectedDropCity
                                              : 'Grad dostave',
                                          style: textStyle,
                                        ),
                                      );
                                  },
                                ),
                              ),
                              sh(20),
                              Text(
                                'Adresa dostave',
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              InkWell(
                                onTap: () {
                                  if (selectedDropCity == "Krajnja lokacija") {
                                    appSnackBar(
                                      context: context,
                                      msg: "Please choose a drop off location",
                                      isError: true,
                                    );
                                  } else {}
                                },
                                child: Container(
                                    width: SizeConfig.screenWidth,
                                    decoration: BoxDecoration(
                                      border: Border.all(color: borderColor),
                                      borderRadius: BorderRadius.circular(4),
                                    ),
                                    child: FutureBuilder(
                                      future: HomeService.getHubs(),
                                      builder: (context, snap) {
                                        if (snap.connectionState ==
                                            ConnectionState.done) {
                                          List<DropdownMenuItem> menuItem = [];

                                          menuItem.add(
                                            DropdownMenuItem<int>(
                                              child: Row(
                                                children: [
                                                  Icon(
                                                    Icons.my_location,
                                                    size: b * 16,
                                                  ),
                                                  sb(10),
                                                  Text(
                                                    "Odaberi adresu",
                                                    style: textStyle,
                                                  ),
                                                ],
                                              ),
                                              value: -1,
                                            ),
                                          );

                                          menuItem
                                              .addAll(provider.allHub.map((e) {
                                            return DropdownMenuItem(
                                              child: Text(e.address),
                                              value: e.id,
                                            );
                                          }).toList());

                                          return DropdownBelow(
                                            boxHeight: h * 48,
                                            boxPadding: edgeInsets,
                                            itemWidth:
                                                SizeConfig.screenWidth - b * 60,
                                            itemTextstyle: textStyle,
                                            boxTextstyle: textStyle,
                                            boxWidth:
                                                SizeConfig.screenWidth - b * 60,
                                            icon: SvgPicture.asset(
                                              'assets/icons/drop_down_icon.svg',
                                              height: h * 8,
                                            ),
                                            hint: Text(
                                              dropOffAdd.text == ''
                                                  ? 'Adresa dostave'
                                                  : dropOffAdd.text,
                                              style: textStyle,
                                            ),
                                            items: menuItem,
                                            value: null,
                                            onChanged: (val) {
                                              if (val == -1) {
                                                showPlacePicker(1);
                                              } else {
                                                final selectedHub = provider
                                                    .allHub
                                                    .where((ele) {
                                                  return ele.id == val
                                                      ? true
                                                      : false;
                                                }).first;
                                                selectedDropCity =
                                                    selectedHub.city;
                                                dropOffAdd.text =
                                                    selectedHub.address;
                                                dropCoordinates = LatLng(
                                                    selectedHub.latitude,
                                                    selectedHub.longitude);
                                                isManualAddrDrop = false;
                                                setState(() {});
                                              }
                                            },
                                          );
                                        }
                                        return Container(
                                          height: h * 48,
                                          padding: edgeInsets,
                                          alignment: Alignment.centerLeft,
                                          width: SizeConfig.screenWidth,
                                          child: Text(
                                            dropOffAdd.text == ''
                                                ? 'Adresa dostave'
                                                : dropOffAdd.text,
                                            style: textStyle,
                                          ),
                                        );
                                      },
                                    )),
                              ),
                              sh(limited ? 20 : 0),
                              limited
                                  ? CustomTextField(
                                      label: 'Broj kilometara',
                                      controller: estKm,
                                      inputType: TextInputType.number,
                                      suffix: null,
                                      vertPad: h * 10,
                                      size: b * 11,
                                      spacing: 0.6,
                                      labelSize: b * 12,
                                      isBold: true,
                                      isVisibilty: null,
                                      validator: (val) {
                                        if (estKm.text.trim() == "")
                                          return "Polje ne smije biti prazno";
                                        else
                                          return null;
                                      },
                                    )
                                  : sh(0),
                              sh(20),
                              Text(
                                'Datum',
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  letterSpacing: 0.6,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              Row(
                                children: [
                                  Expanded(
                                    child: InkWell(
                                      onTap: () async {
                                        final picked =
                                            await showDateRangePicker(
                                          builder: (BuildContext context,
                                              Widget? child) {
                                            return Theme(
                                              data: ThemeData.dark().copyWith(
                                                primaryColor: Colors.black,
                                                colorScheme: ColorScheme.dark(
                                                  primary: primaryColor,
                                                  surface: secondaryColor,
                                                ),
                                              ),
                                              child: child!,
                                            );
                                          },
                                          context: context,
                                          firstDate: DateTime.now(),
                                          lastDate: DateTime.now()
                                              .add(Duration(days: 730)),
                                          initialDateRange: DateTimeRange(
                                            start: startDate.compareTo(
                                                        DateTime.now()
                                                            .toString()) <
                                                    0
                                                ? DateTime.now()
                                                : DateTime.parse(startDate),
                                            end: endDate.compareTo(
                                                        DateTime.now()
                                                            .toString()) <
                                                    0
                                                ? DateTime.now()
                                                    .add(Duration(days: 1))
                                                : DateTime.parse(endDate),
                                          ),
                                        );
                                        if (picked != null) {
                                          setState(() {
                                            startDate = picked.start
                                                .toString()
                                                .substring(0, 10);
                                            endDate = picked.end
                                                .toString()
                                                .substring(0, 10);
                                          });
                                        }
                                      },
                                      child: Container(
                                        alignment: Alignment.center,
                                        padding: EdgeInsets.symmetric(
                                            vertical: h * 12),
                                        decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(b * 4),
                                          border:
                                              Border.all(color: borderColor),
                                        ),
                                        child: Text(
                                          dateFormatString(startDate),
                                          style: TextStyle(
                                            fontSize: b * 10,
                                            letterSpacing: 0.6,
                                            color:
                                                Colors.black.withOpacity(0.8),
                                          ),
                                        ),
                                      ),
                                    ),
                                  ),
                                  sb(23),
                                  Text(
                                    'do',
                                    style: TextStyle(
                                      fontSize: b * 12,
                                      letterSpacing: 0.6,
                                      color: Colors.black.withOpacity(0.5),
                                    ),
                                  ),
                                  sb(23),
                                  Expanded(
                                    child: InkWell(
                                      onTap: () async {
                                        final picked =
                                            await showDateRangePicker(
                                          builder: (BuildContext context,
                                              Widget? child) {
                                            return Theme(
                                              data: ThemeData.dark().copyWith(
                                                primaryColor: Colors.black,
                                                colorScheme: ColorScheme.dark(
                                                  primary: primaryColor,
                                                  surface: secondaryColor,
                                                ),
                                              ),
                                              child: child!,
                                            );
                                          },
                                          initialDateRange: DateTimeRange(
                                            start: startDate.compareTo(
                                                        DateTime.now()
                                                            .toString()) <
                                                    0
                                                ? DateTime.now()
                                                : DateTime.parse(startDate),
                                            end: endDate.compareTo(
                                                        DateTime.now()
                                                            .toString()) <
                                                    0
                                                ? DateTime.now()
                                                    .add(Duration(days: 1))
                                                : DateTime.parse(endDate),
                                          ),
                                          context: context,
                                          firstDate: DateTime.now(),
                                          lastDate: DateTime.now()
                                              .add(Duration(days: 730)),
                                        );
                                        if (picked != null) {
                                          setState(() {
                                            startDate = picked.start
                                                .toString()
                                                .substring(0, 10);
                                            endDate = picked.end
                                                .toString()
                                                .substring(0, 10);
                                          });
                                        }
                                      },
                                      child: Container(
                                        alignment: Alignment.center,
                                        padding: EdgeInsets.symmetric(
                                            vertical: h * 12),
                                        decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(b * 4),
                                          border:
                                              Border.all(color: borderColor),
                                        ),
                                        child: Text(
                                          dateFormatString(endDate),
                                          style: TextStyle(
                                            fontSize: b * 10,
                                            letterSpacing: 0.6,
                                            color:
                                                Colors.black.withOpacity(0.8),
                                          ),
                                        ),
                                      ),
                                    ),
                                  ),
                                ],
                              ),
                              sh(20),
                              Text(
                                "Vrijeme",
                                style: TextStyle(
                                  fontSize: b * 13,
                                  fontWeight: FontWeight.w500,
                                  letterSpacing: 0.6,
                                  color: Color(0xff3c3b3b),
                                ),
                              ),
                              sh(10),
                              Row(
                                children: [
                                  Expanded(
                                    child: InkWell(
                                      onTap: () {
                                        FocusScope.of(context).unfocus();
                                        selectTime(context, true);
                                      },
                                      child: Container(
                                        alignment: Alignment.center,
                                        padding: EdgeInsets.symmetric(
                                            vertical: h * 12),
                                        decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(b * 4),
                                          border:
                                              Border.all(color: borderColor),
                                        ),
                                        child: Text(
                                          startTime != null
                                              ? timeFormat(startTime!)
                                              : "Pocetak",
                                          style: TextStyle(
                                            fontSize: b * 10,
                                            color:
                                                Colors.black.withOpacity(0.8),
                                          ),
                                        ),
                                      ),
                                    ),
                                  ),
                                  sb(23),
                                  Text(
                                    'do',
                                    style: TextStyle(
                                      fontSize: b * 12,
                                      letterSpacing: 0.6,
                                      color: Colors.black.withOpacity(0.5),
                                    ),
                                  ),
                                  sb(23),
                                  Expanded(
                                    child: InkWell(
                                      onTap: () {
                                        FocusScope.of(context).unfocus();
                                        selectTime(context, false);
                                      },
                                      child: Container(
                                        alignment: Alignment.center,
                                        padding: EdgeInsets.symmetric(
                                            vertical: h * 12),
                                        decoration: BoxDecoration(
                                          borderRadius:
                                              BorderRadius.circular(b * 4),
                                          border:
                                              Border.all(color: borderColor),
                                        ),
                                        child: Text(
                                          endTime != null
                                              ? timeFormat(endTime!)
                                              : "Kraj",
                                          style: TextStyle(
                                            fontSize: b * 10,
                                            color:
                                                Colors.black.withOpacity(0.8),
                                          ),
                                        ),
                                      ),
                                    ),
                                  ),
                                ],
                              ),
                              sh(20),
                              isPressed
                                  ? LoadingButton()
                                  : CustomButton(
                                      label: widget.isUpdate == false ||
                                              widget.isUpdate == null
                                          ? "Nastavi"
                                          : "Izmjeni",
                                      width: b * 140,
                                      onPressed: () {
                                        Navigator.push(
                                            context,
                                            MaterialPageRoute(
                                                builder: (context) =>
                                                    CheckoutPage(
                                                      vehicle: widget.vehicle!,
                                                    )));
                                      },
                                    ),
                              sh(20)
                            ],
                          ),
                        ),
                      ],
                    ),
                  ),
                ),
              ),
            )
          ],
        ),
      ),
    );
  }

  TimeOfDay? startTime;
  TimeOfDay? endTime;

  Future<void> selectTime(BuildContext context, bool isStart) async {
    String? startTimeOnUpdate;
    String? endTimeOnUpdate;
    if (startTime != null) {
      startTimeOnUpdate =
          DateTime.parse(startDate).toString().split(' ').first +
              ' ' +
              startTime!.format(context);
    }

    if (endTime != null) {
      endTimeOnUpdate = DateTime.parse(endDate).toString().split(' ').first +
          ' ' +
          endTime!.format(context);
    }

    TimeOfDay? tempTime;

    // ignore: non_constant_identifier_names
    final TimeOfDay? picked_s = await showTimePicker(
      context: context,
      initialTime: startTime ?? TimeOfDay.now(),
      builder: (BuildContext context, Widget? child) {
        return Theme(
          data: ThemeData.light().copyWith(
            colorScheme: ColorScheme.light(
              primary: primaryColor,
              surface: Colors.white,
              secondary: primaryColor,
            ),
          ),
          child: child!,
        );
      },
    );

    if (picked_s != null) {
      if (isStart)
        startTime = picked_s;
      else
        endTime = picked_s;

      setState(() {});
    }
  }
}
