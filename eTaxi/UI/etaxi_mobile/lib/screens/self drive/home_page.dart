import 'package:cached_network_image/cached_network_image.dart';
import 'package:etaxi_mobile/models/current_loc_model.dart';
import 'package:etaxi_mobile/models/vehicle_type_model.dart';
import 'package:etaxi_mobile/providers/home_provider.dart';
import 'package:etaxi_mobile/services/home_service.dart';
import 'package:etaxi_mobile/utils/colors.dart';
import 'package:etaxi_mobile/utils/sizeConfig.dart';
import 'package:etaxi_mobile/widgets/vehicle_card.dart';
import 'package:flutter/material.dart';
import 'package:flutter_svg/svg.dart';
import 'package:intl/intl.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  TextEditingController searchController = TextEditingController();
  Future? getClasses;
  Future<void>? getAvailableVehicle;
  List<VehicleType> vehicleTypes = [];
  CurrentLoc currentLoc = CurrentLoc(
    pickCity: ' pick city',
    dropCity: 'drop city',
    pickCityAddr: 'pick address',
    dropCityAddr: ' drop addrss',
    dropCityID: '',
    pickCityID: '',
    dropTime: DateTime.now(),
    pickTime: DateTime(2021),
    //dropCoordinates: LatLng(0, 0),
    //pickCoordinates: LatLng(0, 0),
  );
  VehicleType allVehicleType =
      VehicleType(name: 'Svi', vehicleTypeId: -1, seats: 0, icon: "");

  int vehicleType = -1;
  bool isSearching = false;

  @override
  void didChangeDependencies() async {
    super.didChangeDependencies();

    // await getUser();
    // await checkCity();
  }

  @override
  void initState() {
    super.initState();

    getClasses = HomeService.getVehicleTypes();

    // getClasses =
    //     Provider.of<HomeProvider>(context, listen: false).getVehicleClasses();

    // getAvailableVehicle =
    //     Provider.of<HomeProvider>(context, listen: false).getModelByDateCity();
  }

  // getUser() async {
  //   Future.delayed(Duration(seconds: 2));
  //   final user = await PreferencesUtils.getUser();
  //   Provider.of<AuthProvider>(context, listen: false).setUser(user);
  // }

  // checkCity() async {
  //   var checkForCity = await HomeProvider().checkForCity();
  //   if (!checkForCity)
  //     Navigator.of(context).pushAndRemoveUntil(
  //         MaterialPageRoute(
  //           builder: (context) => SelectCityScreen(),
  //         ),
  //         (route) => false);
  //   else {
  //     currentLoc = (await PreferencesUtils.getLoc())!;
  //     if (currentLoc.pickTime != DateTime(2021)) {
  //       if (currentLoc.pickTime!.compareTo(DateTime.now()) < 0) {
  //         await changeDateDialog(context);
  //         Navigator.of(context).pushAndRemoveUntil(
  //             MaterialPageRoute(
  //               builder: (context) => SelectCityScreen(),
  //             ),
  //             (route) => false);
  //       }
  //     }
  //   }
  // }

  DateTime startDate = DateTime.now().add(Duration(days: 1));
  DateTime endDate = DateTime.now().add(Duration(days: 11));

  late String startDateFormat = DateFormat('EEE, d MMMM, yy')
      .format(DateTime.now().add(Duration(days: 1)));
  late String endDateFormat = DateFormat('EEE, d MMMM, yy')
      .format(DateTime.now().add(Duration(days: 11)));

  @override
  Widget build(BuildContext context) {
    final provider = HomeProvider.instance;
    return Scaffold(
      resizeToAvoidBottomInset: false,
      backgroundColor: primaryColor,
      body: SafeArea(
        child: Column(children: [
          Container(
            decoration: BoxDecoration(
              gradient: buttonGradient,
            ),
            child: Row(
              mainAxisAlignment: MainAxisAlignment.center,
              children: [
                InkWell(
                  // onTap: () {
                  //   Navigator.of(context).push(
                  //     MaterialPageRoute(
                  //       builder: (_) => SelectCityScreen(),
                  //     ),
                  //   );
                  // },
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
                Spacer(),
                Text(
                  'Izaberite auto',
                  style: TextStyle(
                    fontSize: 18,
                    fontWeight: FontWeight.w700,
                  ),
                ),
                Spacer(flex: 2),
              ],
            ),
          ),
          Expanded(
            child: Container(
              child: Column(
                children: [
                  Expanded(
                    child: SingleChildScrollView(
                      physics: BouncingScrollPhysics(),
                      child: Column(
                        crossAxisAlignment: CrossAxisAlignment.start,
                        children: [
                          sh(10),
                          Container(
                            width: SizeConfig.screenWidth,
                            margin: EdgeInsets.symmetric(horizontal: 15),
                            padding: EdgeInsets.fromLTRB(17, 11, 27, 14),
                            decoration: BoxDecoration(
                              color: Colors.white,
                              borderRadius: BorderRadius.circular(4),
                              boxShadow: [
                                BoxShadow(
                                  color: Color(0xff0000000).withOpacity(0.1),
                                  blurRadius: 4,
                                  offset: Offset(0, 4),
                                ),
                              ],
                            ),
                            child: Column(
                              crossAxisAlignment: CrossAxisAlignment.start,
                              children: [
                                Row(
                                  children: [
                                    SvgPicture.asset(
                                      'assets/icons/blue_cirle.svg',
                                      width: 17,
                                    ),
                                    sb(19),
                                    Expanded(
                                      child: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.start,
                                        children: [
                                          Text(
                                            currentLoc.pickCityAddr ?? "",
                                            style: TextStyle(
                                              letterSpacing: 0.45,
                                              fontSize: 11.7,
                                            ),
                                          ),
                                          sh(5),
                                          Row(
                                            children: [
                                              Text(
                                                "Start : " +
                                                    DateFormat().format(
                                                        currentLoc.pickTime!),
                                                style: TextStyle(
                                                  fontSize: 11.5,
                                                ),
                                              ),
                                              Spacer(),
                                              Text(
                                                "Start " +
                                                    DateFormat().format(
                                                        currentLoc.pickTime!),
                                                style: TextStyle(
                                                  fontSize: 11.5,
                                                ),
                                              ),
                                            ],
                                          ),
                                        ],
                                      ),
                                    ),
                                  ],
                                ),
                                Transform.translate(
                                  offset: Offset(-3, 0),
                                  child: Icon(
                                    Icons.more_vert,
                                    color: Color(0xff999999),
                                  ),
                                ),
                                Row(
                                  children: [
                                    SvgPicture.asset(
                                      'assets/icons/choose_city.svg',
                                      color: secondaryColor,
                                      height: 20,
                                    ),
                                    sb(19),
                                    Expanded(
                                      child: Column(
                                        crossAxisAlignment:
                                            CrossAxisAlignment.start,
                                        children: [
                                          Text(
                                            currentLoc.dropCityAddr ?? "",
                                            style: TextStyle(
                                              fontSize: 11.7,
                                              letterSpacing: 0.45,
                                            ),
                                          ),
                                          sh(5),
                                          Row(
                                            children: [
                                              Text(
                                                "End : " +
                                                    DateFormat().format(
                                                        currentLoc.dropTime!),
                                                style: TextStyle(
                                                  fontSize: 11.5,
                                                ),
                                              ),
                                              Spacer(),
                                              Text(
                                                "End: " +
                                                    DateFormat().format(
                                                        currentLoc.dropTime!),
                                                style: TextStyle(
                                                  fontSize: 11.5,
                                                ),
                                              ),
                                            ],
                                          ),
                                        ],
                                      ),
                                    ),
                                  ],
                                ),
                              ],
                            ),
                          ),
                          sh(5),
                          FutureBuilder(
                            future: HomeService.getVehicles(),
                            builder: (context, snap) {
                              if (!(snap.connectionState ==
                                  ConnectionState.waiting)) {
                                int len = vehicleType == -1
                                    ? provider.availableModel.length
                                    : provider.availableModel.where((element) {
                                        if (element.typeId == vehicleType)
                                          return true;
                                        else
                                          return false;
                                      }).length;

                                if (len == 0)
                                  return noCarErrorWidget();
                                else
                                  return ListView.builder(
                                    padding: EdgeInsets.only(top: 5),
                                    shrinkWrap: true,
                                    itemCount: len,
                                    physics: NeverScrollableScrollPhysics(),
                                    itemBuilder: (context, index) {
                                      return InkWell(
                                        onTap: () {
                                          // dialogBoxDetail(
                                          //   context,
                                          //   vehicleType == -1
                                          //       ? provider.availableModel[index]
                                          //       : provider.availableModel
                                          //           .where((element) {
                                          //           if (element.typeId ==
                                          //               vehicleType) {
                                          //             return true;
                                          //           } else {
                                          //             return false;
                                          //           }
                                          //         }).toList()[index],
                                          // );
                                        },
                                        child: VehicleCard(
                                          fun: () {
                                            // Navigator.of(context).push(
                                            //   MaterialPageRoute(
                                            //     builder: (context) => BookCar(
                                            //       vehicle: vehicleType == -1
                                            //           ? provider
                                            //               .availableModel[index]
                                            //           : provider.availableModel
                                            //               .where((element) {
                                            //               if (element.typeId ==
                                            //                   vehicleType)
                                            //                 return true;
                                            //               else
                                            //                 return false;
                                            //             }).toList()[index],
                                            //       isUpdate: false,
                                            //     ),
                                            //   ),
                                            // );
                                          },
                                          vehicle: vehicleType == -1
                                              ? provider.availableModel[index]
                                              : provider.availableModel
                                                  .where((element) {
                                                  if (element.typeId ==
                                                      vehicleType)
                                                    return true;
                                                  else
                                                    return false;
                                                }).toList()[index],
                                        ),
                                      );
                                    },
                                  );
                              } else {
                                return ListView.builder(
                                  padding: EdgeInsets.only(top: 5),
                                  shrinkWrap: true,
                                  itemCount: 5,
                                  physics: NeverScrollableScrollPhysics(),
                                  itemBuilder: (context, index) {
                                    // return VehicleCardShimmer();
                                    return Container();
                                  },
                                );
                              }
                            },
                          ),
                        ],
                      ),
                    ),
                  ),
                  Container(
                    decoration: BoxDecoration(
                      border: Border.all(
                        color: Color(0xfff9f9f9),
                        width: 3,
                      ),
                    ),
                    height: 81,
                    child: FutureBuilder(
                      future: getClasses,
                      builder: (context, snap) {
                        print(snap.connectionState);
                        // if (snap.connectionState == ConnectionState.done) {
                        vehicleTypes.clear();
                        vehicleTypes.add(allVehicleType);
                        vehicleTypes.addAll(provider.vehicleType);

                        return ListView.builder(
                          physics: BouncingScrollPhysics(),
                          padding: EdgeInsets.symmetric(vertical: 8.2),
                          scrollDirection: Axis.horizontal,
                          itemCount: vehicleTypes.length,
                          itemBuilder: (context, index) {
                            final vehicleType = vehicleTypes[index];
                            return vehicleClassCard(vehicleType);
                          },
                        );
                        // } else {
                        //   return ListView.builder(
                        //     physics: BouncingScrollPhysics(),
                        //     padding: EdgeInsets.symmetric(vertical:  8.2),
                        //     scrollDirection: Axis.horizontal,
                        //     itemCount: 10,
                        //     itemBuilder: (context, index) {
                        //       return tempvehicleClassCard();
                        //     },
                        //   );
                        // }
                      },
                    ),
                  ),
                ],
              ),
            ),
          )
        ]),
      ),
    );
  }

  noCarErrorWidget() {
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;

    return Center(
      child: Column(
        children: [
          sh(80),
          Image.asset(
            'assets/images/emptyHome_illus.png',
            width: 206,
            height: 139,
          ),
          sh(40),
          Text(
            'Book car now',
            style: TextStyle(
              fontSize: 24,
              fontWeight: FontWeight.w700,
            ),
          ),
          sh(10),
          Padding(
            padding: EdgeInsets.symmetric(horizontal: 60),
            child: Text(
              'Have ride',
              textAlign: TextAlign.center,
              style: TextStyle(
                fontSize: 14,
              ),
            ),
          )
        ],
      ),
    );
  }

  Widget vehicleClassCard(VehicleType VehicleType) {
    return InkWell(
      onTap: () {
        setState(() {
          vehicleType = VehicleType.vehicleTypeId!;
        });
      },
      child: Container(
        margin: EdgeInsets.symmetric(horizontal: 6),
        alignment: Alignment.center,
        height: 58,
        width: 70,
        decoration: BoxDecoration(
          color: vehicleType == VehicleType.vehicleTypeId
              ? primaryColor
              : Color(0xfff9f9f9),
          borderRadius: BorderRadius.circular(4),
        ),
        child: Column(
          mainAxisAlignment: MainAxisAlignment.center,
          children: [
            VehicleType.name != 'All'
                ? CachedNetworkImage(
                    imageUrl: VehicleType.icon!,
                    height: 26,
                    fit: BoxFit.fitHeight,
                  )
                : sh(0),
            Text(
              VehicleType.name!,
              style: TextStyle(
                fontSize: VehicleType.name == 'All ' ? 14 : 12,
                fontWeight: FontWeight.w500,
              ),
            ),
          ],
        ),
      ),
    );
  }

  Widget tempvehicleClassCard() {
    var h = SizeConfig.screenHeight / 812;
    var b = SizeConfig.screenWidth / 375;
    return Container(
      margin: EdgeInsets.symmetric(horizontal: 6),
      alignment: Alignment.center,
      height: 58,
      width: 70,
      decoration: BoxDecoration(
        color: Color(0xfff9f9f9),
        borderRadius: BorderRadius.circular(4),
      ),
    );
  }
}
