using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using ApplicationForVacancy.Models;
using ApplicationForVacancy.Service;

namespace ApplicationForVacancy.Controllers
{
    [Route("api/v1")]
    public class HomeController : Controller
    {
        private readonly IAbstract service;
        public HomeController(IAbstract _service)
        {
            service = _service;
        }

        [HttpPost("product/{name}")]
        public async Task<Product> PostNameAsync(string name)
        {
           return await service.PostByNameAsync(name);
        }
        
        [HttpGet("product/{id}")]
        public async Task<Product> GetIdAsync(Guid id)
        {
           return await service.GetByIdAsync(id);
        }

        [HttpPost("product")]
        public async Task<Product> AddAsync(Product product)
        { 
            return await service.PostAddAsync(product);
        }

        [HttpPut("product")]
        public async Task<Product> PutAsync(Product product)
        {
            return await service.PutUpdAsync(product);
        }

        [HttpDelete("product/{id}")]
        public async Task<Product> DelAsync(Guid id)
        {
            return await service.DeleteAsync(id);
        }
    }
}
