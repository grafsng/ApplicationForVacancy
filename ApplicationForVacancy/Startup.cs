using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ApplicationForVacancy.Context;
using ApplicationForVacancy.CustomMiddlewares;
using ApplicationForVacancy.Service;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

namespace ApplicationForVacancy
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            //получаем строку подключения из файла конфигурации
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            //Добавление функциональности контроллера
            services.AddControllers();
            //Регистрация сервиса
            services.AddTransient<IAbstract, Entity>();
            //Добавление сваггера
            services.AddSwaggerGen();
        }
    

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //подключение компонента сваггера
            app.UseSwagger();
            //облегчаем вызов сваггера
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApplicationForVacancy");
                c.RoutePrefix = string.Empty;
            });

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            //подключение компонента, глобально обрабатывающего исключения методов сервиса
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            //подключаем маршрутизацию на контроллеры
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


       

    