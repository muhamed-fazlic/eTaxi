import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_admin/api/api_model.dart';
import 'package:etaxi_admin/models/order_model.dart';
import 'package:etaxi_admin/providers/auth_provider.dart';
import 'package:etaxi_admin/providers/order_provider.dart';
import 'package:http/http.dart';

class OrderService {
  static Future<List<Order>> getAllOrders(
      {Map<String, dynamic>? queryParams}) async {
    List<Order> orders = [];
    try {
      Response res = await ApiModels()
          .getRequest(url: 'api/Order', queryParams: queryParams);

      var data = jsonDecode(res.body);

      data.forEach((e) {
        orders.add(Order.fromJson(e));
      });

      return orders;
    } catch (e) {
      print('ERROR ON GE ORDERS $e');
    }

    return [];
  }

  static Future setOrderStatus(data) async {
    try {
      Response res = await ApiModels()
          .putRequest(url: 'api/Order/setOrderStatus', data: data);
      inspect(res);
    } catch (e) {
      print('ERROR ON SET ORDER STATUS $e');
      throw e;
    }
  }

  static Future createOrder({bool isSelfDrive = false}) async {
    var vehicle = OrderProvider.instance.selectedVehicle!;

    var startLocationData = {
      "address": OrderProvider.instance.currentLocationData?.address,
      "latitude": OrderProvider.instance.currentLocationData?.latitude,
      "longitude": OrderProvider.instance.currentLocationData?.longitude,
      "city": OrderProvider.instance.currentLocationData?.city,
      "country": OrderProvider.instance.currentLocationData?.country,
      "postalCode": OrderProvider.instance.currentLocationData?.postalCode,
    };

    var endLocationData = {
      "address": OrderProvider.instance.destinationLocationData?.address,
      "latitude": OrderProvider.instance.destinationLocationData?.latitude,
      "longitude": OrderProvider.instance.destinationLocationData?.longitude,
      "city": OrderProvider.instance.destinationLocationData?.city,
      "country": OrderProvider.instance.destinationLocationData?.country,
      "postalCode": OrderProvider.instance.destinationLocationData?.postalCode,
    };

//create start and end location and add their Ids to OrderProvider
//so we can use them if we want to update order
    var startLocationId = await createLocation(startLocationData);
    OrderProvider.instance.currentLocationData!.id = startLocationId;

    var endLocationId = await createLocation(endLocationData);
    OrderProvider.instance.destinationLocationData!.id = endLocationId;

    var dataToSend = {
      "userDriverId": vehicle.driverId,
      "userId": null,
      "startLocationId": startLocationId,
      "endLocationId": endLocationId,
      "vehicleId": vehicle.vehicleId,
      "isSelfDrive": isSelfDrive,
      "startTime": OrderProvider.instance.startTime?.toIso8601String() ??
          DateTime.now().toIso8601String(),
      "price": OrderProvider.instance.orderPrice,
      "paymentMethod":
          OrderProvider.instance.paymentMethod == PaymentMethod.CASH
              ? "Gotovina"
              : "Online",
    };

    try {
      Response res =
          await ApiModels().postRequest(url: 'api/Order', data: dataToSend);
      inspect(res);
      log(res.body);
      if (res.statusCode == 200) {
        var decoded = jsonDecode(res.body);
        OrderProvider.instance.setOrderId(decoded['id']);
        return decoded;
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future updateOrder({bool isSelfDrive = false}) async {
    var vehicle = OrderProvider.instance.selectedVehicle!;

    var startLocationId = OrderProvider.instance.currentLocationData!.id;
    var endLocationId = OrderProvider.instance.destinationLocationData!.id;

//if you change location in update order, create new location
    if (startLocationId !=
        OrderProvider.instance.selectedOrder!.startLocation!.id) {
      var startLocationData = {
        "address": OrderProvider.instance.currentLocationData?.address,
        "latitude": OrderProvider.instance.currentLocationData?.latitude,
        "longitude": OrderProvider.instance.currentLocationData?.longitude,
        "city": OrderProvider.instance.currentLocationData?.city,
        "country": OrderProvider.instance.currentLocationData?.country,
        "postalCode": OrderProvider.instance.currentLocationData?.postalCode,
      };
      startLocationId = await createLocation(startLocationData);
      OrderProvider.instance.currentLocationData!.id = startLocationId;
    }
    if (endLocationId !=
        OrderProvider.instance.selectedOrder!.endLocation!.id) {
      var endLocationData = {
        "address": OrderProvider.instance.destinationLocationData?.address,
        "latitude": OrderProvider.instance.destinationLocationData?.latitude,
        "longitude": OrderProvider.instance.destinationLocationData?.longitude,
        "city": OrderProvider.instance.destinationLocationData?.city,
        "country": OrderProvider.instance.destinationLocationData?.country,
        "postalCode":
            OrderProvider.instance.destinationLocationData?.postalCode,
      };
      endLocationId = await createLocation(endLocationData);
      OrderProvider.instance.destinationLocationData!.id = endLocationId;
    }

    var orderToUpdate = {
      "id": OrderProvider.instance.orderId!,
      "userDriverId": vehicle.driverId,
      "userId": AuthProvider.instance.user!.id,
      "startLocationId": startLocationId,
      "endLocationId": endLocationId,
      "vehicleId": vehicle.vehicleId,
      "isSelfDrive": isSelfDrive,
      "startTime": OrderProvider.instance.startTime?.toIso8601String() ??
          DateTime.now().toIso8601String(),
      "price": OrderProvider.instance.orderPrice,
      "paymentMethod":
          OrderProvider.instance.paymentMethod == PaymentMethod.CASH
              ? "Gotovina"
              : "Online",
      //"isCanceled": true,
      //"cancelReason": "string",
      //"endTime": "2023-05-18T15:44:06.127Z"
    };

    try {
      Response res =
          await ApiModels().putRequest(url: 'api/Order', data: orderToUpdate);
      //inspect(res);
      if (res.statusCode == 200) {
        return res;
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future createLocation(data) async {
    try {
      Response res =
          await ApiModels().postRequest(url: 'api/Location', data: data);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future deleteOrder(int id) async {
    try {
      await ApiModels().deleteRequest(url: 'api/order/$id');
    } catch (e) {
      throw e;
    }
  }
}
