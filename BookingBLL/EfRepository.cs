using BookingShared.Interfaces;
using BookingShared.Models;
using BookingShared.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BookingBLL
{
    public class EfRepository : IRepository
    {
        private readonly DbContext _dbContext;

        public EfRepository(DbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public T GetById<T>(int id) where T : BaseEntity
        {
            return _dbContext.Set<T>().SingleOrDefault(e => e.Id == id);
        }
        public List<T> ListQuery<T>(Func<T,bool> f) where T : BaseEntity
        {
            return _dbContext.Set<T>().Where(f).ToList();
        }

        public List<T> List<T>() where T : BaseEntity
        {
            return _dbContext.Set<T>().ToList();
        }

        public T Add<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Add(entity);
            _dbContext.SaveChanges();

            return entity;
        }

        public void Delete<T>(T entity) where T : BaseEntity
        {
            _dbContext.Set<T>().Remove(entity);
            _dbContext.SaveChanges();
        }

        public void Update<T>(T entity) where T : BaseEntity
        {
            _dbContext.Entry(entity).State = EntityState.Modified;
            _dbContext.SaveChanges();
        }


        public List<HotelModel> SearchHotels(SearchViewModel searchViewModel)
        {
            var bookings = _dbContext.Set<BookingModel>().Where(b =>
                    (b.BeginDate < searchViewModel.BeginDate && b.EndDate > searchViewModel.BeginDate)
                    || (b.BeginDate < searchViewModel.EndDate && b.EndDate > searchViewModel.EndDate));
            var emptyRooms = _dbContext.Set<RoomModel>().Where(r => !bookings.Select(b => b.RoomModelId).Contains(r.Id));
            var emptyHotels = _dbContext.Set<HotelModel>()
                .Where(h =>
                    h.Stars >= searchViewModel.Stars
                    && emptyRooms.Select(r => r.HotelModelId).Contains(h.Id));
            if (!string.IsNullOrEmpty(searchViewModel.Name))
                emptyHotels = emptyHotels.Where(h => h.Name.Contains(searchViewModel.Name));
            if (!string.IsNullOrEmpty(searchViewModel.City))
                emptyHotels = emptyHotels.Where(h => h.City.Contains(searchViewModel.City));
            return emptyHotels.ToList();
        }
    }
}
