using Microsoft.EntityFrameworkCore;
using MultiShop.Cargo.DataAccessLayer.Abstract;
using MultiShop.Cargo.DataAccessLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Cargo.DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        private readonly CargoContext _cargoContext;

        public GenericRepository(CargoContext cargpContext)
        {
            _cargoContext = cargpContext;
        }

        public async Task DeleteAsync(int id)
        {
            var values=  await _cargoContext.Set<T>().FindAsync(id);
            _cargoContext.Set<T>().Remove(values);
            await _cargoContext.SaveChangesAsync();
        }

        public async Task<List<T>> GetAllAsync()
        {
            return await _cargoContext.Set<T>().ToListAsync();
        }

        public  async Task<T> GetByIdAsync(int id)
        {
            var values = await _cargoContext.Set<T>().FindAsync(id);
            return values;
        }

        public async Task InsertAsync(T entity)
        {
            await _cargoContext.Set<T>().AddAsync(entity);
            await _cargoContext.SaveChangesAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _cargoContext.Set<T>().Update(entity);
            await _cargoContext.SaveChangesAsync();
        }
    }
}
