using BOOKSTORE.DOMAIN.Interfaces;
using BOOKSTORE.DOMAIN.Models;
using BOOKSTORE.IOC.Context;
using BOOKSTORE.IOC.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BOOKSTORE.APPLICATION.DI
{
    public class Initializer
    {
        public static void Configure(IServiceCollection services, string connection)
        {
            services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connection));

            services.AddScoped(typeof(IRepository<Book>), typeof(BookRepository));
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(BookService));
            services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));
        }
    }
}
