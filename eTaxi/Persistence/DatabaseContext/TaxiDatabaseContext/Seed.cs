using eTaxi.Domain;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace eTaxi.Persistence.DatabaseContext.TaxiDatabaseContext
{
    public static class Seed
    {
        public static void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<User>();
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 1, Name = "Admin", NormalizedName = "ADMIN" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 2, Name = "User", NormalizedName = "USER" });
            modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 3, Name = "CompanyAdmin", NormalizedName = "COMPANYADMIN" });
            //modelBuilder.Entity<IdentityRole<int>>().HasData(new IdentityRole<int> { Id = 4, Name = "Driver", NormalizedName = "DRIVER" });

            //Company seed Data
            var companies = new List<Company>
            {
                new Company
                {
                    Id=1,
                    Name="Sarajevo Taxi",
                },
                new Company
                {
                    Id=2,
                    Name="Mostar Taxi",
                },

            };
            modelBuilder.Entity<Company>().HasData(companies);


            //User seed Data
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 1,
                UserName = "admin",
                FirstName = "Admin",
                LastName = "eTaxi",
                NormalizedUserName = "ADMIN".ToUpper(),
                Email = "admin@admin.com",
                NormalizedEmail = "ADMIN@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,

            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 2,
                UserName = "kompanija Sarajevo",
                FirstName = "Sarajevo",
                LastName = "Taxi",
                NormalizedUserName = "KOMPANIJA SARAJEVO".ToUpper(),
                Email = "kompanija@admin.com",
                NormalizedEmail = "KOMPANIJA@ADMIN.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
                CompanyId = 1
            });

            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 3,
                UserName = "user br1",
                FirstName = "User",
                LastName = "br1",
                NormalizedUserName = "USER BR1".ToUpper(),
                Email = "user1@taxi.com",
                NormalizedEmail = "USER1@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 4,
                UserName = "user br2",
                FirstName = "User",
                LastName = "br2",
                NormalizedUserName = "USER BR2".ToUpper(),
                Email = "user2@taxi.com",
                NormalizedEmail = "USER2@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 5,
                UserName = "user br3",
                FirstName = "User",
                LastName = "br3",
                NormalizedUserName = "USER BR3".ToUpper(),
                Email = "user3@taxi.com",
                NormalizedEmail = "USER3@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 6,
                UserName = "user br4",
                FirstName = "User",
                LastName = "br4",
                NormalizedUserName = "USER BR4".ToUpper(),
                Email = "user4@taxi.com",
                NormalizedEmail = "USER4@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 7,
                UserName = "user br5",
                FirstName = "User",
                LastName = "br5",
                NormalizedUserName = "USER BR5".ToUpper(),
                Email = "user5@taxi.com",
                NormalizedEmail = "USER5@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });
            modelBuilder.Entity<User>().HasData(new User
            {
                Id = 8,
                UserName = "user br6",
                FirstName = "User",
                LastName = "br6",
                NormalizedUserName = "USER BR6".ToUpper(),
                Email = "user6@taxi.com",
                NormalizedEmail = "USER6@TAXI.COM".ToUpper(),
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, "test12345"),
                SecurityStamp = string.Empty,
            });

            //UserRoles seed Data
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 1, RoleId = 1 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 2, RoleId = 3 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 3, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 4, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 5, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 6, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 7, RoleId = 2 });
            modelBuilder.Entity<IdentityUserRole<int>>().HasData(new IdentityUserRole<int> { UserId = 8, RoleId = 2 });


            //VehicleType Seed Data
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 1,
                Type = "Malo auto",
                NumberOfSeats = 4,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/car_l5aypi.png"
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 2,
                Type = "Limuzina",
                NumberOfSeats = 5,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/sedan_j0oo9s.png"
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 3,
                Type = "SUV",
                NumberOfSeats = 5,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/SUV_hjqwbi.png"
            });
            modelBuilder.Entity<VehicleType>().HasData(new VehicleType
            {
                Id = 4,
                Type = "MiniVan",
                NumberOfSeats = 9,
                ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656661697/rs2/Bus_ogtv6k.png"
            });

            //Location Seed Data
            var locations = new List<Location>
            {
                new Location
                {
                    Id=1,
                    StreetNumber = "12",
                    StreetName = "Marsala Tita",
                    District = "Centar",
                    City = "Sarajevo",
                    PostalCode = "71000",
                    Latitude = 43.8563,
                    Longitude = 18.4131,
                    Address = "Marsala Tita 12, Centar, Sarajevo, 71000, Bosnia and Herzegovina"
                },
                new Location
                {
                    Id=2,
                    StreetNumber = "185",
                    StreetName = "Dzemala Bijedica",
                    District = "Sarajevo",
                    City = "Sarajevo",
                    PostalCode = "71000",
                    Latitude = 43.8449611,
                    Longitude = 18.3378662,
                    Address = "Dzemala Bijedica St 185, Sarajevo 71000"
                },
                new Location
                {
                    Id=3,
                    StreetNumber = "8",
                    StreetName = "Maršala Tita",
                    District = "Stari Grad",
                    City = "Mostar",
                    PostalCode = "88000",
                    Latitude = 43.3424,
                    Longitude = 17.8089,
                    Address = "Maršala Tita 8, Stari Grad, Mostar, 88000, Bosnia and Herzegovina"
                },
                new Location
                {
                    Id=4,
                    StreetNumber = "15",
                    StreetName = "Aleja Bosne Srebrene",
                    District = "Novi Grad",
                    City = "Sarajevo",
                    PostalCode = "71000",
                    Latitude = 43.8708,
                    Longitude = 18.4314,
                    Address = "Aleja Bosne Srebrene 15, Novi Grad, Sarajevo, 71000, Bosnia and Herzegovina"
                },
                new Location
                {
                    Id=5,
                    StreetNumber = "3",
                    StreetName = "Titova",
                    District = "Centar",
                    City = "Tuzla",
                    PostalCode = "75000",
                    Latitude = 44.5350,
                    Longitude = 18.6714,
                    Address = "Titova 3, Centar, Tuzla, 75000, Bosnia and Herzegovina"
                },
                new Location
                {
                    Id=6,
                    StreetNumber = "58",
                    StreetName = "Patriotske lige",
                    District = "Centar",
                    City = "Sarajevo",
                    PostalCode = "71000",
                    Latitude = 43.8742066,
                    Longitude = 18.4087534,
                    Address = "VCJ7+59H, Patriotske lige 58, Sarajevo 71000"
                },
                 new Location
                {
                    Id=7,
                    StreetNumber = "30",
                    StreetName = "Hasan Brkica",
                    District = "Centar",
                    City = "Sarajevo",
                    PostalCode = "71000",
                    Latitude = 43.8510649,
                    Longitude = 18.3907597,
                    Address = "Hasana Brkića 30, Sarajevo 71000"
                },
            };
            modelBuilder.Entity<Location>().HasData(locations);

            //Vehicle Seed Data
            var vehicles = new List<Vehicle>
            {
                new Vehicle
                {
                    Id=1,
                    Name = "Audi A8",
                    KmTraveled = 50000,
                    LicenceNumber = "ABC123",
                    Year = 2019,
                    AirCondition = true,
                    AirBag = true,
                    FuelType = "Benzin",
                    Transmission = "Automatic",
                    CurrentLocationId = null,
                    Color = "Siva",
                    Brand = "Audi",
                    PricePerKm = 6.0,
                    UserDriverId = 3,
                    TypeId = 2,
                    ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656523883/rs2/audia8_gckbfh.png",
                    CompanyId = 1
                },
                new Vehicle
                {
                    Id=2,
                    Name = "Volkswagen Golf 7",
                    KmTraveled = 80000,
                    LicenceNumber = "XYZ789",
                    Year = 2017,
                    AirCondition = true,
                    AirBag = true,
                    FuelType = "Dizel",
                    Transmission = "Manual",
                    CurrentLocationId = null,
                    Color = "Siva",
                    Brand = "Volkswagen",
                    PricePerKm = 3.0,
                    UserDriverId = 4,
                    TypeId = 1,
                    ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1656523879/rs2/golf_7_didjje.jpg",
                    CompanyId = 1
                },
                new Vehicle
                {
                    Id = 3,
                    Name = "BMW X5",
                    KmTraveled = 60000,
                    LicenceNumber = "DEF456",
                    Year = 2020,
                    AirCondition = true,
                    AirBag = true,
                    FuelType = "Dizel",
                    Transmission = "Automatic",
                    CurrentLocationId = null,
                    Color = "Plava",
                    Brand = "BMW",
                    PricePerKm = 9.0,
                    UserDriverId = 5,
                    TypeId = 3,
                    ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1686762738/bmw-x5_qbbvec.jpg",
                    CompanyId = 1
                },
                new Vehicle
                {
                    Id = 4,
                    Name = "Mercedes-Benz C-Class",
                    KmTraveled = 40000,
                    LicenceNumber = "GHI789",
                    Year = 2021,
                    AirCondition = true,
                    AirBag = true,
                    FuelType = "Benzin",
                    Transmission = "Automatic",
                    CurrentLocationId = null,
                    Color = "White",
                    Brand = "Mercedes",
                    PricePerKm = 10.0,
                    UserDriverId = 6,
                    TypeId = 2,
                    ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1686765411/benz-c-class_msuspq.jpg",
                    CompanyId = 2
                },
                new Vehicle
                {
                    Id = 5,
                    Name = "Audi A3",
                    KmTraveled = 55000,
                    LicenceNumber = "JKL012",
                    Year = 2016,
                    AirCondition = false,
                    AirBag = true,
                    FuelType = "Dizel",
                    Transmission = "Automatic",
                    CurrentLocationId = null,
                    Color = "Red",
                    Brand = "Audi",
                    PricePerKm = 4.0,
                    UserDriverId = 7,
                    TypeId = 1,
                    ImageUrl = "https://res.cloudinary.com/doswamdah/image/upload/v1686765730/Audi_A3_snaxht.webp",
                    CompanyId = null
                }
            };
            modelBuilder.Entity<Vehicle>().HasData(vehicles);

            //Order Seed Data
            var orders = new List<Order>
            {
                new Order
                {
                    Id=1,
                    IsActive = true,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 3,
                    UserId = 8,
                    StartLocationId = 1,
                    EndLocationId = 2,
                    VehicleId = 1,
                    IsSelfDrive = false,
                    Price = 36.00,
                    StartTime = DateTime.Now.AddHours(1),
                    EndTime = DateTime.Now.AddHours(2),
                    PaymentMethod = "Online"
                },

                new Order
                {
                    Id=2,
                    IsActive = true,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 4,
                    UserId = 7,
                    StartLocationId = 2,
                    EndLocationId = 3,
                    VehicleId = 2,
                    IsSelfDrive = false,
                    Price = 357.00,
                    StartTime = DateTime.Now.AddHours(2),
                    EndTime = DateTime.Now.AddHours(4),
                    PaymentMethod = "Gotovina"
                },
                 new Order
                {
                    Id = 3,
                    IsActive = false,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 5,
                    UserId = 8,
                    StartLocationId = 4,
                    EndLocationId = 6,
                    VehicleId = 3,
                    IsSelfDrive = false,
                    Price = 83.70,
                    StartTime = DateTime.Now.AddHours(-2),
                    EndTime = DateTime.Now.AddHours(-1),
                    PaymentMethod = "Gotovina"
                },
                new Order
                {
                    Id = 4,
                    IsActive = false,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 6,
                    UserId = 4,
                    StartLocationId = 5,
                    EndLocationId = 1,
                    VehicleId = 4,
                    IsSelfDrive = false,
                    Price = 1210.00,
                    StartTime = DateTime.Now.AddDays(-1).AddHours(-4),
                    EndTime = DateTime.Now.AddDays(-1).AddHours(-2),
                    PaymentMethod = "Online"
                },
                new Order
                {
                    Id=5,
                    IsActive = true,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 7,
                    UserId = 8,
                    StartLocationId = 3,
                    EndLocationId = 1,
                    VehicleId = 5,
                    IsSelfDrive = false,
                    Price = 500.00,
                    StartTime = DateTime.Now.AddDays(-3).AddHours(-6),
                    EndTime = DateTime.Now.AddDays(-3).AddHours(-4),
                    PaymentMethod = "Gotovina"
                },
                new Order
                {
                    Id=6,
                    IsActive = true,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 3,
                    UserId = 6,
                    StartLocationId = 6,
                    EndLocationId = 1,
                    VehicleId = 1,
                    IsSelfDrive = false,
                    Price = 32.30,
                    StartTime = DateTime.Now.AddMinutes(2),
                    EndTime = DateTime.Now.AddMinutes(20),
                    PaymentMethod = "Online"
                },
                new Order
                {
                    Id=7,
                    IsActive = false,
                    IsCanceled = true,
                    CancelReason = "Pokvareno vozilo",
                    UserDriverId = 3,
                    UserId = 5,
                    StartLocationId = 2,
                    EndLocationId = 1,
                    VehicleId = 1,
                    IsSelfDrive = false,
                    Price = 36.00,
                    StartTime = DateTime.Now.AddHours(-11),
                    EndTime = DateTime.Now.AddHours(-9),
                    PaymentMethod = "Gotovina"
                },
                new Order
                {
                    Id = 8,
                    IsActive = false,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 6,
                    UserId = null,
                    StartLocationId = 1,
                    EndLocationId = 4,
                    VehicleId = 4,
                    IsSelfDrive = false,
                    Price = 78.00,
                    StartTime = DateTime.Now.AddDays(-1).AddHours(-1),
                    EndTime = DateTime.Now.AddDays(-1),
                    PaymentMethod = "Gotovina"
                },

                new Order
                {
                    Id = 9,
                    IsActive = true,
                    IsCanceled = false,
                    CancelReason = null,
                    UserDriverId = 6,
                    UserId = 5,
                    StartLocationId = 7,
                    EndLocationId = 1,
                    VehicleId = 4,
                    IsSelfDrive = false,
                    Price = 25.00,
                    StartTime = DateTime.Now.AddDays(+1).AddHours(-1),
                    EndTime = DateTime.Now.AddDays(+1),
                    PaymentMethod = "Gotovina"
                },
            };
            modelBuilder.Entity<Order>().HasData(orders);

            //Rating User Seed Data
            var ratings = new List<Rating>
            {
                new Rating
                {
                    Id=1,
                    UserId = 6,
                    UserDriverId = 3,
                    OrderId = 6,
                    Grade = 5,
                    Comment = "Odlična vožnja, vozač je bio veoma ljubazan i profesionalan."
                },
                new Rating
                {
                    Id=2,
                    UserId = 4,
                    UserDriverId = 6,
                    OrderId = 4,
                    Grade = 5,
                    Comment = "Sjajno iskustvo, vozač je bio veoma pristojan i vozilo je bilo čisto i udobno."
                },
                 new Rating
                {
                    Id=3,
                    UserId = 5,
                    UserDriverId = 3,
                    OrderId = 7,
                    Grade = 2,
                    Comment = "taxi nikad nije ni dosao. Navodno se pokvarilo vozilo"
                },
            };
            modelBuilder.Entity<Rating>().HasData(ratings);        

            //ToDo Seed Data
            var hubStations = new List<HubStation>
            {
                new HubStation
                {
                    Id = 1,
                    Name = "Sarajevo Hub",
                    LocationId = 1
                },
                new HubStation
                {
                    Id=2,
                    Name = "Mostar Hub",
                    LocationId = 3
                },
                new HubStation
                {
                    Id=3,
                    Name = "Tuzla Hub",
                    LocationId = 5
                }
            };
            modelBuilder.Entity<HubStation>().HasData(hubStations);

            //HubStation Seed Data
            var toDoList = new List<ToDo4924>
            {
                new ToDo4924
                {
                    Id = 1,
                    Naziv = "Polozit rs2",
                   Opis="Izac na ispit i polozit",
                   UserId = 1,
                   Status="U toku",
                   KrajnjiRok=DateTime.Now.AddDays(+1),
                },
                new ToDo4924
                {
                    Id = 2,
                    Naziv = "Zavrsit fax",
                   Opis="Zavrsiti sve ispite",
                   UserId = 3,
                   Status="U toku",
                   KrajnjiRok=DateTime.Now.AddDays(+21),
                },
               new ToDo4924
                {
                    Id = 3,
                    Naziv = "Stici na voz",
                   Opis="Stici na voz u 5",
                   UserId = 2,
                   Status="U toku",
                   KrajnjiRok=DateTime.Now.AddDays(+2),
                },
                  new ToDo4924
                {
                    Id = 4,
                    Naziv = "Zavrsiti seminarski iz rs2",
                   Opis="Da seminarski bude prihvacen",
                   UserId = 4,
                   Status="Realizovana",
                   KrajnjiRok=DateTime.Now.AddDays(-4),
                },
                     new ToDo4924
                {
                    Id = 5,
                    Naziv = "Zavrsiti fax u roku",
                   Opis="Ne cekati puno i zavrisit fax na vrijeme",
                   UserId = 1,
                   Status="Istekla",
                   KrajnjiRok=DateTime.Now.AddMonths(-6),
                },
            };
            modelBuilder.Entity<ToDo4924>().HasData(toDoList);






        }
    }
}
