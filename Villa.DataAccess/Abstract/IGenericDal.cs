﻿using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Villa.DataAccess.Abstract
{
    public interface IGenericDal<T> where T : class
    {
        Task CreateAsync(T entity);
        Task Delete(ObjectId id);
        Task UpdateAsync(T entity);
        Task<List<T>> GetListAsnc();
        Task<T> GetByIdAsync(ObjectId id);
        Task<int> CountAsync();
        Task<List<T>> GetFilteredListAsync(Expression<Func<T , bool>> predicate);


    }
}
