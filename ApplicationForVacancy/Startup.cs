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
            //�������� ������ ����������� �� ����� ������������
            string connection = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ApplicationContext>(options => options.UseSqlServer(connection));
            //���������� ���������������� �����������
            services.AddControllers();
            //����������� �������
            services.AddTransient<IAbstract, Entity>();
            //���������� ��������
            services.AddSwaggerGen();
        }
    

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //����������� ���������� ��������
            app.UseSwagger();
            //��������� ����� ��������
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

            //����������� ����������, ��������� ��������������� ���������� ������� �������
            app.UseMiddleware<ExceptionHandlerMiddleware>();
            //���������� ������������� �� �����������
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}


       

    