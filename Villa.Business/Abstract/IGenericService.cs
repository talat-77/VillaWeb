using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Villa.Business.Abstract
{
    public interface IGenericService<T> where T : class
    {
        Task TCreateAsync(T entity);
        Task TDelete(ObjectId id);
        Task TUpdateAsync(T entity);
        Task<List<T>> TGetListAsnc();
        Task<T> TGetByIdAsync(ObjectId id);
        Task<int> TCountAsync();
        Task<List<T>> TGetFilteredListAsync(Expression<Func<T, bool>> predicate);
    }
}
