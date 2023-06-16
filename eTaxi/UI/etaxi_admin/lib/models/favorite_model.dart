class Favorite {
  int id;
  int companyId;

  Favorite({
    required this.id,
    required this.companyId,
  });

  factory Favorite.fromJson(Map<String, dynamic> json) {
    return Favorite(
      id: json['id'],
      companyId: json['companyId'],
    );
  }
}
