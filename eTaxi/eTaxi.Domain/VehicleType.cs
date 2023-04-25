namespace eTaxi.Domain
{
    public class VehicleType
    {
        public int Id { get; set; }
        public string Type { get; set; }
        public int NumberOfSeats { get; set; }
        public string ImageUrl { get; set; }
        // public int FileId { get; set; }
        //public virtual File File { get; set; }
    }
}
