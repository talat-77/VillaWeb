using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Villa.DataAccess.Abstract;
using Villa.DataAccess.Context;

namespace Villa.DataAccess.Repository
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly VillaContext _context;

        public GenericRepository(VillaContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync()
      => await _context.Set<T>().CountAsync();

        public async Task CreateAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(ObjectId id)
        {
            var deleted =  await _context.Set<T>().FindAsync(id);
             _context.Remove(deleted);  
            await _context.SaveChangesAsync();  
      
        }
        public async Task<T> GetByIdAsync(ObjectId id)
        {
            return await _context.Set<T>().FindAsync(id);
        }
        public async Task<List<T>> GetFilteredListAsync(Expression<Func<T, bool>> predicate)
        {
           return await _context.Set<T>().Where(predicate).ToListAsync();  
        }

        public async Task<List<T>> GetListAsnc()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _context.Update(entity);    
            await _context.SaveChangesAsync();  
        }
    }
}
