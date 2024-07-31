using App.Application.Repositories;
using App.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UnitOfWorks
{
    /// <summary>
    /// Verilənlər bazasında bir neçə əməliyyatı bir tranzaksiya daxilində idarə etmək üçün vahid iş interfeysi.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Person entity-si üçün repository təmin edir.
        /// </summary>
        public IRepository<Person> RepositoryPerson { get; set; }

        /// <summary>
        /// Asinxron olaraq dəyişiklikləri verilənlər bazasına tətbiq edir.
        /// </summary>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi tətbiq olunan dəyişikliklərin sayını ehtiva edir.</returns>
        Task<int> CommitAsync();

        /// <summary>
        /// Dəyişiklikləri verilənlər bazasına tətbiq edir.
        /// </summary>
        /// <returns>Tətbiq olunan dəyişikliklərin sayı.</returns>
        int Commit();
    }

}
