using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.Repositories
{
    /// <summary>
    /// Verilənlər mənbəyi ilə qarşılıqlı əlaqə üçün metodlar təyin edən ümumi depo interfeysi.
    /// </summary>
    /// <typeparam name="TEntity">Entity növü.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Entity-i identifikatoruna görə tapır.
        /// </summary>
        /// <param name="id">Entity-nin identifikatoru.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-ni ehtiva edir.</returns>
        Task<TEntity> FindById(int id);

        /// <summary>
        /// Entity-i identifikatoruna görə tapır və izləmə (tracking) və daxil etmə (includes) parametrləri ilə konfiqurasiya edir.
        /// </summary>
        /// <param name="id">Entity-nin identifikatoru.</param>
        /// <param name="tracking">Entity-nin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-ni ehtiva edir.</returns>
        Task<TEntity> FindById(int id, bool tracking = true, params string[] includes);

        /// <summary>
        /// Şərtə uyğun olaraq entity tapır.
        /// </summary>
        /// <param name="predicate">Entity-ni təyin edən şərt.</param>
        /// <param name="tracking">Entity-nin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-ni ehtiva edir.</returns>
        Task<TEntity> GetAsync(Expression<Func<TEntity, bool>> predicate, bool tracking = true, params string[] includes);

        /// <summary>
        /// Şərtə uyğun olaraq sorğu (query) qaytarır.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <param name="tracking">Entity-nin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi sorğunu (query) ehtiva edir.</returns>
        Task<IQueryable<TEntity>> GetAsyncQuery(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes);

        /// <summary>
        /// Şərtə uyğun olaraq bütün entity-ləri qaytarır.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <param name="tracking">Entity-lərin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-lərin sorğusunu (query) ehtiva edir.</returns>
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes);

        /// <summary>
        /// Şərtə uyğun olaraq müəyyən sayda entity-ləri qaytarır.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <param name="count">Qaytarılacaq entity-lərin sayı.</param>
        /// <param name="tracking">Entity-lərin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-lərin sorğusunu (query) ehtiva edir.</returns>
        Task<IQueryable<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> expression, int count, bool tracking = true, params string[] includes);

        /// <summary>
        /// Şərtə uyğun olaraq hər hansı bir entity-nin mövcud olub-olmadığını yoxlayır.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq. Tapşırığın nəticəsi entity-nin mövcud olub-olmadığını göstərir.</returns>
        Task<bool> IsAny(Expression<Func<TEntity, bool>> expression);

        /// <summary>
        /// Şərtə uyğun olaraq tək bir entity qaytarır.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <param name="tracking">Entity-nin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Entity-ni ehtiva edən nəticə.</returns>
        TEntity Get(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes);

        /// <summary>
        /// Yeni entity əlavə edir.
        /// </summary>
        /// <param name="entity">Əlavə ediləcək entity.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task InsertAsync(TEntity entity);

        /// <summary>
        /// Yeni entity-lər əlavə edir.
        /// </summary>
        /// <param name="entities">Əlavə ediləcək entity-lər siyahısı.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task InsertRangeAsync(List<TEntity> entities);

        /// <summary>
        /// Şərtə uyğun olaraq entity silir.
        /// </summary>
        /// <param name="expression">Entity-ni təyin edən şərt.</param>
        /// <param name="tracking">Entity-nin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task Remove(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes);

        /// <summary>
        /// Entity-i identifikatoruna görə silir.
        /// </summary>
        /// <param name="id">Entity-nin identifikatoru.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task RemoveAsync(int id);

        /// <summary>
        /// Şərtə uyğun olaraq entity-ləri silir.
        /// </summary>
        /// <param name="expression">Entity-ləri təyin edən şərt.</param>
        /// <param name="tracking">Entity-lərin izlənib-izlənməyəcəyini göstərir.</param>
        /// <param name="includes">Daxil etmə üçün əlaqəli entity-lər.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task RemoveRange(Expression<Func<TEntity, bool>> expression, bool tracking = true, params string[] includes);

        /// <summary>
        /// Entity-ləri siyahıya görə silir.
        /// </summary>
        /// <param name="entities">Silinəcək entity-lər siyahısı.</param>
        /// <returns>Asinxron əməliyyatı təmsil edən tapşırıq.</returns>
        Task RemoveRange(List<TEntity> entities);

        /// <summary>
        /// Entity-i identifikatoruna görə silir.
        /// </summary>
        /// <param name="id">Entity-nin identifikatoru.</param>
        void Remove(int id);
    }

}
