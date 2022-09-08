using System.Collections.Generic;
using System.Linq;

namespace Dk.BankApp.Web.Data.Interfaces
{
    public interface IRepository<T> where T : class, new()
    {
        void Create(T entity);
        void Update(T entity);  
        void Remove(T entity);
        T GetById(object id);
        List<T> GetAll();
        IQueryable<T> GetQueryable(); // Eğer bir method Queryable ise henüz databasede işi bitmemiş. Yaptığımız işlemler önce db ye gönderilecek, daha sonra bize döndürülecek.
    }
}
