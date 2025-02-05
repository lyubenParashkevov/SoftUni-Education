﻿using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class RoomRepository : IRepository<IRoom>
    {
        private List<IRoom> rooms = new List<IRoom>();
        public void AddNew(IRoom model)
        {
            rooms.Add(model);
        }
        public IRoom Select(string criteria)
        {
            return rooms.FirstOrDefault(r => r.GetType().Name == criteria);
        }
        public IReadOnlyCollection<IRoom> All()
        {
            return rooms.AsReadOnly();
        }

       
    }
}
