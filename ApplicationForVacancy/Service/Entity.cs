using ApplicationForVacancy.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using ApplicationForVacancy.Context;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForVacancy.Service
{
    public class Entity : IAbstract
    {
        private readonly ApplicationContext db;
        public Entity(ApplicationContext _db)
        {
            db = _db;
        }
        public async Task<Product> PostByNameAsync(string name)
        {
            return await db.Product.FirstOrDefaultAsync(p=>p.Name==name);
        }
        public async Task<Product> GetByIdAsync(Guid id)
        {
            return await db.Product.FirstOrDefaultAsync(p => p.Id==id);
        }
        public async Task<Product> PostAddAsync(Product product)
        {
            db.Product.Add(product);
            await db.SaveChangesAsync();
            return product;
        }
        public async Task<Product> PutUpdAsync(Product product)
        {
            db.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
        public async Task <Product> DeleteAsync(Guid id)
        {
            Product product = await db.Product.FirstOrDefaultAsync(p => p.Id==id);
            db.Product.Remove(product);
            await db.SaveChangesAsync();
            return product;
        }

    }
}
