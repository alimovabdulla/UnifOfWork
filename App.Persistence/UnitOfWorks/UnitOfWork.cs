using App.Application.Repositories;
using App.Application.UnitOfWorks;
using App.Domain.Entities;
using App.Persistence.Contexts;
using App.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Persistence.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        // Verilənlər bazası kontekstini saxlayan dəyişən
        readonly DataContext _dataContext;

        // Konstruktor, DataContext obyektini qəbul edir və RepositoryPerson obyektini yaradılır
        public UnitOfWork(DataContext dataContext)
        {
            _dataContext = dataContext;
            RepositoryPerson = new Repository<Person>(_dataContext);
        }

        // Person entity-si üçün repository
        public IRepository<Person> RepositoryPerson { get; set; }

        // Verilənlər bazasında dəyişiklikləri saxlayır
        public int Commit()
        {
            return _dataContext.SaveChanges();
        }

        // Verilənlər bazasında dəyişiklikləri asinxron şəkildə saxlayır
        public async Task<int> CommitAsync()
        {
            return await _dataContext.SaveChangesAsync();
        }
    }

}
