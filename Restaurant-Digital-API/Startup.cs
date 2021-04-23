using AccessData;
using AccessData.Commands;
using Application.Services;
using Domain.Commands;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using SqlKata.Compilers;
using System.Data;

namespace Restaurant_Digital_API
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

            services.AddControllers();
            var connectionString = Configuration.GetSection("ConnectionString").Value;
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(connectionString));

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Restaurant_Digital_API", Version = "v1" });
            });

            // SqlKata
            services.AddTransient<Compiler, SqlServerCompiler>();
            services.AddTransient<IDbConnection>(b =>
            {
                return new SqlConnection(connectionString);
            });


            //Injection dependences
            services.AddTransient<IGenericRepository, GenericRepository>();
            services.AddTransient<IComandaService, ComandaService>();
            services.AddTransient<IMercaderiaService, MercaderiaService>();
            //services.AddTransient<IMercaderiaQueries, MercaderiaQueries>();
            //services.AddTransient<IComandaQueries, ComandaQueries>();

            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
            });

        }



        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "Restaurant_Digital_API v1"));
            }

            app.UseHttpsRedirection();

            app.UseRouting();
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
