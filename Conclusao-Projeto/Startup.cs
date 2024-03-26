using Conclusao_Projeto.Persistence;
using Conclusao_Projeto.Repository;
using Conclusao_Projeto.Services;
using Dev.DesafioPratico.Repository;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;

namespace Conclusao_Projeto
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            // Configuração para banco de dados.
            services.AddDbContext<UserDbContext>(options =>
                options.UseInMemoryDatabase("DefaultConnection")
            );

            services.AddControllers();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITransactionService, TransactionService>();
            services.AddScoped<ITransactionRepository, TransactionRepository>();
            services.AddScoped<INotificationService, NotificationService>();

            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc(
                    "v1",
                    new OpenApiInfo
                    {
                        Title = "User.Api",
                        Version = "v1",
                        Contact = new OpenApiContact
                        {
                            Name = "Ivanete Silva",
                            Email = "ivanetevieira1000@gmail.com"
                        }
                    }
                );
            });
        }
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "User.Api v1");
                    c.SwaggerEndpoint("/swagger/v2/swagger.json", "Transaction.Api v1");
                });
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "home",
                    pattern: "Home/{action=Index}/{id?}",
                    defaults: new { controller = "Home" }
                );

                endpoints.MapControllerRoute(
                    name: "other",
                    pattern: "Other/{action=Index}/{id?}",
                    defaults: new { controller = "Other" }
                );

                endpoints.MapControllerRoute(
                    name: "root",
                    pattern: "",
                    defaults: new { controller = "Home", action = "Index" }
                );
            });
        }
    }
}
