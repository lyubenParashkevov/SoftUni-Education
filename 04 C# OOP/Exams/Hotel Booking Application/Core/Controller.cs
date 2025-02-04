using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private IRepository<IHotel> hotels = new HotelRepository();
        private IRepository<IBooking> bookings = new BookingRepository();
        private IRepository<IRoom> rooms = new RoomRepository();
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel;
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotel = new Hotel(hotelName, category);
            hotels.AddNew(hotel);
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category, hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IRoom room;
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);
            if(hotel is null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            if (hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated, roomTypeName);
            }

            if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }

            else if (roomTypeName == nameof(Studio))
            {
                 room = new Studio();
            }

            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }

            else
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }

            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded, roomTypeName, hotelName);

        }
        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotels.All().FirstOrDefault(r => r.FullName == hotelName);

            if (hotel is null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (roomTypeName != nameof(DoubleBed) && roomTypeName != nameof(Studio) 
                && roomTypeName != nameof(Apartment))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (!hotel.Rooms.All().Any(r => r.GetType().Name == roomTypeName))
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);
            }
            IRoom room = hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName);
            if (room.PricePerNight > 0)
            {
                throw new InvalidOperationException(ExceptionMessages.PriceAlreadySet);
            }
            room.SetPrice(price);
            return string.Format(OutputMessages.PriceSetSuccessfully, roomTypeName, hotelName);
        }
        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            IRoom room;
            var orderedHotels = hotels.All().Where(h => h.Category == category).OrderBy(h => h.FullName);
            foreach (var h in orderedHotels)
            {
                 room = h.Rooms.All().Where(r => r.PricePerNight > 0).OrderBy(r => r.BedCapacity)
                .FirstOrDefault(r => r.BedCapacity >= adults + children);

                if (room is not null)
                {
                    IBooking booking = new Booking(room, duration, adults, children, h.Bookings.All().Count + 1);
                    h.Bookings.AddNew(booking);
                    return string.Format(OutputMessages.BookingSuccessful, h.Bookings.All().Count + 1, h.FullName);
                }
            }
            
            if (orderedHotels is null)
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }

            return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotels.All().FirstOrDefault(h => h.FullName == hotelName);
            if (hotel is null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }

            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Hotel name: {hotel.FullName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            sb.AppendLine("--Bookings:");
            foreach (var book in hotel.Bookings.All())
            {
                sb.AppendLine(book.BookingSummary());
            }
            return sb.ToString().TrimEnd();
        }

        

        
    }
}
