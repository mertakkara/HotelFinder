﻿using HotelFinder.DataAccess.Abstract;
using HotelFinder.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelFinder.DataAccess.Concrete
{
    public class HotelRepository : IHotelRepository
    {
        public Hotel CreateHotel(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Add(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }

        public void Delete(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                var deletedHotel = GetHotelById(id);
                hotelDbContext.Hotels.Remove(deletedHotel);
                hotelDbContext.SaveChanges();
            }
        }

        public async Task<List<Hotel>> GetAllHotels()
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return await hotelDbContext.Hotels.ToListAsync();
            }

        }

        public Hotel GetHotelById(int id)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.Find(id);
            }
        }

        public Hotel GetHotelByName(string name)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                return hotelDbContext.Hotels.FirstOrDefault(x=>x.Name.ToLower() == name.ToLower());
            }
        }

        public Hotel Update(Hotel hotel)
        {
            using (var hotelDbContext = new HotelDbContext())
            {
                hotelDbContext.Hotels.Update(hotel);
                hotelDbContext.SaveChanges();
                return hotel;
            }
        }
    }
}
