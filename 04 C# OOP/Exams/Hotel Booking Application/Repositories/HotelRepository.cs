﻿using BookingApp.Models.Hotels.Contacts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class HotelRepository : IRepository<IHotel>
    {
        private List<IHotel> hotels = new List<IHotel>();
        public void AddNew(IHotel model)
        {
            hotels.Add(model);
        }
        public IHotel Select(string criteria)
        {
            return hotels.FirstOrDefault(h => h.FullName == criteria);
        }
        public IReadOnlyCollection<IHotel> All()
        {
            return hotels.AsReadOnly();
        }

       
    }
}
