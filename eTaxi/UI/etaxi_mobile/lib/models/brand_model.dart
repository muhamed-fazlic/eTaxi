class BrandModel {
  int? modelId;
  String? modelName;
  String? brand;
  String? modelNo;

  BrandModel({this.modelId, this.modelName, this.brand, this.modelNo});

  BrandModel.fromJson(Map<String, dynamic> json) {
    modelId = json['model_id'];
    modelName = json['model_name'];
    brand = json['brand'];
    modelNo = json['model_number'];
  }
}
