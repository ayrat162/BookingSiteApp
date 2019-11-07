using BookingShared.Models;
using BookingShared.ViewModels;
using System;
using System.Collections.Generic;

namespace BookingShared.Interfaces
{
    public interface IRepository
    {
        T GetById<T>(int id) where T : BaseEntity;
        List<T> List<T>() where T : BaseEntity;
        List<T> ListQuery<T>(Func<T,bool> f) where T : BaseEntity;
        T Add<T>(T entity) where T : BaseEntity;
        void Update<T>(T entity) where T : BaseEntity;
        void Delete<T>(T entity) where T : BaseEntity;
        List<HotelModel> SearchHotels(SearchViewModel searchViewModel);
    }
}
