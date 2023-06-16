class FileModel {
  int id;
  int userId;
  String url;
  String? type;
  String? fileName;
  int? feedbackId;

  FileModel(
      {required this.id,
      required this.userId,
      required this.url,
      this.type,
      this.feedbackId,
      this.fileName});

  factory FileModel.fromJson(Map<String, dynamic> json) {
    return FileModel(
        id: json['id'],
        userId: json['userId'],
        url: json['url'],
        type: json['type'],
        fileName: json['fileName'],
        feedbackId: json['feedbackId']);
  }
}
