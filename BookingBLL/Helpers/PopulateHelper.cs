using BookingShared.Interfaces;
using BookingShared.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BookingBLL.Helpers
{
    public class PopulateHelper
    {
        public static void PopulateHotels(IRepository repository)
        {
            repository.Add(new HotelModel { Name = "Bulak", Address = "49 Pravo Bulachnaya", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Hotel Tranzit", Address = "Highway Moscow ufa 812 km", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Regina Hotel Kazan", Address = "11 50 Let Oktyabrya street", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Safyan", Address = "Ulitsa Safyan 6", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Vostok Guest House", Address = "Ulitsa Novo-Davlikeevskaya 19", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Zebra Hostel", Address = "Fatykha Amirkhana Prospect 18A", City = "Kazan Russia", Stars = 1 });
            repository.Add(new HotelModel { Name = "Luciano Spa Complex", Address = "Ostrovskogo Street 26", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Mirage Hotel Kazan", Address = "Moskovskaya Street 1A", City = "Kazan Russia", Stars = 5 });
            repository.Add(new HotelModel { Name = "Shalyapin Palace", Address = "University Street 7/80", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Hayall Hotel", Address = "Universitetskaya Street 16", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Hotel Riviera Kazan", Address = "1A Fatkin Amirkhana Street", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Art Hotel Kazan", Address = "Ostrowski Street 33", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Korston Hotel & Mall Kazan", Address = "North Ershova Street 1A", City = "Kazan Russia", Stars = 5 });
            repository.Add(new HotelModel { Name = "Grand Hotel Kazan", Address = "Ulice Petersburg 1", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Dunai Hotel", Address = "Bolotnikova Street 9", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Premium Hotel", Address = "Maksima Gorkogo Street 3", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Hotel Bon Ami", Address = "Ulice Ostrovsky House 31", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Osobnyak Na Teatralnoy", Address = "Teatralnaya Street 3", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Gulf Stream Hotel", Address = "2nd Azinskaya Street 1G", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Best Eastern Novinka Hotel", Address = "Korolenko Street 30", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Hotel Ibis Kazan Centre", Address = "Pravo-Bulachnaya Street 43/1", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Hotel Giuseppe", Address = "Kremlin 15/25", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Park Inn Kazan", Address = "Ulitsa Lesgafta 9-11", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Suleiman Palace Hotel", Address = "Peterburgskaya Street 55", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Ilmar City Hotel Kazan", Address = "Karbysheva Street 12A", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "IT-Park Hotel", Address = "Peterburgskaya Street 52", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Milena Hotel Kazan", Address = "19 Tazi Gizatta Street", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Regina na Peterburgskoy", Address = "Peterburgskaya Street 11", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Ryan Johnson Hotel", Address = "Uritzky Street 15", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Tatarstan Hotel Complex", Address = "Pushkina Street 4", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Courtyard by Marriott Kazan Kremlin", Address = "6 Karl Marx Street Vakhitovskiy District", City = "Kazan Russia", Stars = 4 });
            repository.Add(new HotelModel { Name = "Regina Hotel na Kirpichnikova", Address = "Akademika Kirpichnikova Street 11", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Regina Na Baumana", Address = "Baumana Street 47/9", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Voyage Hotel Kazan", Address = "29A Zhurnalistov", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Safar Hotel", Address = "Odnostoronnyaya Grivka Street 1", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Shushma Hotel Kazan", Address = "Narimanov Street 15", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Yal na Kalinina Hotel Kazan", Address = "Kalinina Street 69", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Kolvi Hotel", Address = "7 M Khudyakov street", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Yal Hotel Kazan", Address = "Orenburgsky tract 20", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Bulak Hotel Kazan", Address = "Levobulachnaya Street 36/1", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Hotel Bulgar", Address = "Vishnevskogo Street 21", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Castro", Address = "Internatsionalnaya Street 1/1", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Hotel Hills", Address = "Ayvazovskogo Street 11А", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Volga Hotel", Address = "Said-Galeeva Street 1", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Gvardeiskaya Hotel", Address = "Gvardeiskaya Street 35", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Hotel DIS Kazan", Address = "Said-Galeeva Street 25", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Hotel Aviator Kazan", Address = "Akademika Pavlova Street 1", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Bulgaru Hostel Kazan", Address = "Universitetskaya street 4/34 Apt. 8", City = "Kazan Russia", Stars = 1 });
            repository.Add(new HotelModel { Name = "Gorky 6 Hostel", Address = "Gorkogo Street 6", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Fatima Hotel Kazan", Address = "Karla Marksa Street 2", City = "Kazan Russia", Stars = 3 });
            repository.Add(new HotelModel { Name = "Vhostele", Address = "Volkova Street 54A", City = "Kazan Russia", Stars = 2 });
            repository.Add(new HotelModel { Name = "Tatianin Den Hostel", Address = "Suleimanovoy Street 5", City = "Kazan Russia", Stars = 2 });


            repository.Add(new HotelDetailsModel { HotelModelId = 1, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 2, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 3, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 4, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 5, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 6, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 7, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 8, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 9, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });
            repository.Add(new HotelDetailsModel { HotelModelId = 10, FullDescription = "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua. Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat. Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur.Excepteur sint occaecat cupidatat non proident, sunt in culpa qui officia deserunt mollit anim id est laborum." });

            repository.Add(new RoomModel { RoomNumber = "Room 1", HotelModelId = 1, Description = "Very comfortable room with bed, bathroom, shower and refrigerator", PhotoLink = "~/img/room.jpg", Price = 46.5 });
            repository.Add(new RoomModel { RoomNumber = "Room 2", HotelModelId = 1, Description = "Very comfortable room with bed, bathroom, shower and refrigerator", PhotoLink = "~/img/room.jpg", Price = 50.1 });
            repository.Add(new RoomModel { RoomNumber = "Room 3", HotelModelId = 1, Description = "Very comfortable room with bed, bathroom, shower and refrigerator", PhotoLink = "~/img/room.jpg", Price = 47.6 });
            repository.Add(new RoomModel { RoomNumber = "Room 4", HotelModelId = 1, Description = "Very comfortable room with bed, bathroom, shower, refrigerator, and air conditioning", PhotoLink = "~/img/room.jpg", Price = 101.5 });
            repository.Add(new RoomModel { RoomNumber = "Room 5", HotelModelId = 1, Description = "Very comfortable room with bed, bathroom, and shower", PhotoLink = "~/img/room.jpg", Price = 43.0 });
        }
    }
}
