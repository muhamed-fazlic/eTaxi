class RatingModel {
  int? userId;
  int? userDriverId;
  int? orderId;
  int? grade;
  String? comment;

  RatingModel({
    this.userId,
    this.userDriverId,
    this.orderId,
    this.grade,
    this.comment,
  });

  factory RatingModel.fromJson(Map<String, dynamic> json) {
    return RatingModel(
      userId: json['userId'],
      userDriverId: json['userDriverId'],
      orderId: json['orderId'],
      grade: json['grade'],
      comment: json['comment'],
    );
  }
}
