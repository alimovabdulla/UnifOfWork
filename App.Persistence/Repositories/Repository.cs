using App.Application.Repositories;
using App.Persistence.Contexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Verilənlər bazası kontekstini saxlayan dəyişən.
        /// </summary>
        private readonly DataContext _dataContext;

        /// <summary>
        /// Repository üçün konstruktor. DataContext obyektini qəbul edir.
        /// </summary>
        /// <param name="dataContext">Verilənlər bazası konteksti.</param>
        public Repository(DataContext dataContext)
        {
            _dataContext = dataContext; // Konstruktorun qəbul etdiyi DataContext obyektini saxlayır.
        }

        /// <summary>
        /// Entity-lərin DbSet obyektinə çıxış təmin edən xüsusiyyət.
        /// </summary>
        DbSet<TEntity> Table
        {
            get => _dataContext.Set<TEntity>(); // Entity-lərin DbSet obyektini qaytarır.
            set => _dataContext.Set<TEntity>(); // Entity-lərin DbSet obyektini təyin edir.
        }

        public Task<TEntity> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> FindById(int id, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public TEntity Get(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, int count, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task<IQueryable<TEntity>> GetAsyncQuery(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task InsertAsync(TEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task InsertRangeAsync(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsAny(Expression<Func<TEntity, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public Task Remove(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public void Remove(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes)
        {
            throw new NotImplementedException();
        }

        public Task RemoveRange(List<TEntity> entities)
        {
            throw new NotImplementedException();
        }
    }
}
