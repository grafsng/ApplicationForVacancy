using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using ApplicationForVacancy.Models;

namespace ApplicationForVacancy.Context
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products { get; set; }


    }
    
}
