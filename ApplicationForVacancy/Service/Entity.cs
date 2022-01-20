using ApplicationForVacancy.Models;
using System;
using System.Linq;
using System.Threading.Tasks;
using ApplicationForVacancy.Context;
using ApplicationForVacancy.CustomExceptionClasses;
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
            throw new NotFoundException("ggg");
            
            var product = await db.Product.FirstOrDefaultAsync(p=>p.Name==name);
            if (product == null)
            {
                throw new NotFoundException("Сущность не найдена");
            }

            return product;
        }
        public async Task<Product> GetByIdAsync(Guid id)
        {
            var product = await db.Product.FirstOrDefaultAsync(p => p.Id==id);
            if (product == null)
            {
                throw new NotFoundException("Сущность не найдена");
            }

            return product;
        }
        public async Task<Product> PostAddAsync(Product product)
        {
            if (product == null)
            {
                throw new BadRequestException("Неверный запрос");
            }
            db.Product.Add(product);
            await db.SaveChangesAsync();
            return product;
        }
        public async Task<Product> PutUpdAsync(Product product)
        {
            if (product == null)
            {
                throw new BadRequestException("Неверный запрос");
            }

            if (!db.Product.Any(p => p.Id == product.Id))
            {
                throw new NotFoundException("Сущность не найдена");
            }
            db.Update(product);
            await db.SaveChangesAsync();
            return product;
        }
        public async Task <Product> DeleteAsync(Guid id)
        {
            Product product = await db.Product.FirstOrDefaultAsync(p => p.Id==id);
            if (product == null)
            {
                throw new NotFoundException("Сущность не найдена");
            }
            db.Product.Remove(product);
            await db.SaveChangesAsync();
            return product;
        }

    }
}
