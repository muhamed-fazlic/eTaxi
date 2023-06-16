class CurrentLoc {
  String? pickCity;
  String? pickCityID;
  String? pickCityAddr;
  String? pickCoordinates;

  String? dropCity;
  String? dropCityID;
  String? dropCityAddr;
  String? dropCoordinates;

  DateTime? pickTime;
  DateTime? dropTime;

  CurrentLoc(
      {this.pickCity,
      this.pickCityID,
      this.pickCityAddr,
      this.pickCoordinates,
      this.dropCity,
      this.dropCityID,
      this.dropCityAddr,
      this.dropCoordinates,
      this.pickTime,
      this.dropTime});
}
