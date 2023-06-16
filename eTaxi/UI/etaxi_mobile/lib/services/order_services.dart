import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_mobile/api/api_model.dart';
import 'package:etaxi_mobile/models/order_model.dart';
import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:etaxi_mobile/providers/order_provider.dart';
import 'package:http/http.dart';

class OrderServices {
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
    };

    try {
      if (OrderProvider.instance.paymentMethod == PaymentMethod.ONLINE) {
        await createStripePayment();
      }
      Response res =
          await ApiModels().postRequest(url: 'api/Order', data: dataToSend);
      if (res.statusCode == 200) {
        var decoded = jsonDecode(res.body);
        inspect(decoded);
        OrderProvider.instance.setOrderId(decoded["id"]);
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
    print(endLocationId);

//if you change location in update order, create new location
    if (startLocationId !=
        OrderProvider.instance.selectedOrder?.startLocation?.id) {
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
        OrderProvider.instance.selectedOrder?.endLocation?.id) {
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

      //"endTime": "2023-05-18T15:44:06.127Z"
    };
    inspect(orderToUpdate);

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

  static Future cancelOrder(data) async {
    try {
      Response res = await ApiModels()
          .putRequest(url: 'api/Order/setOrderStatus', data: data);
      inspect(res);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future addOrderRating(data) async {
    try {
      Response res =
          await ApiModels().postRequest(url: 'api/Rating', data: data);
      inspect(res);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future addStripeCustomer() async {
    var addCustomerData = {
      "email": AuthProvider.instance.user!.email,
      "name": AuthProvider.instance.user!.firstName! +
          " " +
          AuthProvider.instance.user!.lastName!,
      "creditCard": {
        "name": OrderProvider.instance.creditCardModel!.cardHolderName,
        "cardNumber": OrderProvider.instance.creditCardModel!.cardNumber,
        "expirationMonth":
            OrderProvider.instance.creditCardModel!.expiryDate.substring(0, 2),
        "expirationYear":
            OrderProvider.instance.creditCardModel!.expiryDate.substring(3),
        "cvc": OrderProvider.instance.creditCardModel!.cvvCode,
      }
    };
    try {
      Response res = await ApiModels()
          .postRequest(url: 'api/Stripe/customer/add', data: addCustomerData);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future createStripePayment() async {
    var customer = await addStripeCustomer();
    var addPaymentData = {
      "customerId": customer["customerId"],
      "receiptEmail": customer["email"],
      "description": "eTaxi Narudžba",
      "currency": "BAM",
      "amount": int.parse(
          (OrderProvider.instance.orderPrice! * 100).toStringAsFixed(0))
    };
    try {
      Response res = await ApiModels()
          .postRequest(url: 'api/Stripe/payment/add', data: addPaymentData);
      inspect(res);
      if (res.statusCode == 200) {
        return jsonDecode(res.body);
      } else {
        throw jsonDecode(res.body);
      }
    } catch (e) {
      print(e);
      throw e;
    }
  }

  static Future getOrders({Map<String, dynamic>? queryParams}) async {
    try {
      Response res = await ApiModels()
          .getRequest(url: 'api/Order', queryParams: queryParams);
      if (res.statusCode == 200) {
        List<Order> orders = [];
        var data = json.decode(res.body);
        //inspect(data);
        data.forEach((element) {
          orders.add(Order.fromJson(element));
        });
        OrderProvider.instance.setOrders(orders);
      }
      return jsonDecode(res.body);
    } catch (e) {
      print(e);
      throw e;
    }
  }
}
