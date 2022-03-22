﻿using _0317_Product_Repository.Models.DBEntity;
using System.Linq;

namespace _0317_Product_Repository.Repositories.Interface
{
    public interface IDBRepository
    {
        public ProductsDBContext Context { get; }
        public void Create<T>(T entity) where T : class;
        public void Update<T>(T entity) where T : class;
        public void Delete<T>(T entity) where T : class;
        public IQueryable<T> GetAll<T>() where T : class;
        public void Save();
    }
}
