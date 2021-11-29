using System;
using System.Threading.Tasks;
using ApplicationForVacancy.Models;

namespace ApplicationForVacancy.Service
{
    public interface IAbstract
    {
        Task<Product> PostByNameAsync(string name);
        Task<Product> GetByIdAsync(Guid id);
        Task<Product> PostAddAsync(Product product);
        Task<Product> PutUpdAsync(Product product);
        Task<Product> DeleteAsync(Guid id);

    }
}
