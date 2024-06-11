import 'dart:convert';
import 'dart:developer';

import 'package:etaxi_mobile/providers/auth_provider.dart';
import 'package:http/http.dart' as http;

const realDeviceUri = '192.168.1.108:7152';
const localUri = '10.0.2.2:7152';

const googleApiKey = 'AIzaSyCc4MW5r36acVY2XNC1EoqLqKbvHZ99KKA';

class ApiModels {
  String apiUrl =
      const String.fromEnvironment("baseUrl", defaultValue: localUri);

  Future postRequest({required String url, Object data = const {}}) async {
    final dataJson = jsonEncode(data);

    final uri = Uri.http(apiUrl, url);
    final response = await http.post(uri,
        headers: <String, String>{
          'Content-Type': 'application/json',
          "Authorization": "Bearer ${AuthProvider.instance.token}"
        },
        body: dataJson);
    return response;
  }

  Future putRequest({required String url, Object data = const {}}) async {
    final dataJson = jsonEncode(data);

    final uri = Uri.http(apiUrl, url);
    final response = await http.put(uri,
        headers: <String, String>{
          'Content-Type': 'application/json',
          "Authorization": "Bearer ${AuthProvider.instance.token}"
        },
        body: dataJson);
    return response;
  }

  Future deleteRequest({required String url, Object data = const {}}) async {
    final dataJson = jsonEncode(data);

    final uri = Uri.http(apiUrl, url);
    final response = await http.delete(uri,
        headers: <String, String>{
          'Content-Type': 'application/json',
          "Authorization": "Bearer ${AuthProvider.instance.token}"
        },
        body: dataJson);
    return response;
  }

  Future getRequest(
      {required String url, Map<String, dynamic>? queryParams}) async {
    final uri = Uri.http(apiUrl, url, queryParams);
    print(uri);
    final response = await http.get(
      uri,
      headers: <String, String>{
        'Content-Type': 'application/json',
      },
    );
    return response;
  }

  Future addFile(String filePath, int userId,
      {String? type, int? feedbackId}) async {
    var request = http.MultipartRequest(
      'POST',
      Uri.http(
        apiUrl,
        "api/File",
      ),
    );

    request.headers["Content-Type"] = "multipart/form-data";
    request.headers["accept"] = "text/plain";
    request.headers["Authorization"] = "Bearer ${AuthProvider.instance.token}";

    request.files.add(await http.MultipartFile.fromPath('File', filePath));

    request.fields["UserId"] = userId.toString();
    request.fields["Type"] = type ?? '';
    if (feedbackId != null)
      request.fields["FeedbackId"] = feedbackId.toString();

    http.Response res = await http.Response.fromStream(await request.send());
    if (res.statusCode == 200) {
      return jsonDecode(res.body);
    } else {
      throw jsonDecode(res.body)['title'];
    }
  }
}
