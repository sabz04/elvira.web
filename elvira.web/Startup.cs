using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using elvira.web.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace elvira.web
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<MusicModelContext>(
                options => options.UseSqlServer(SqlConnectionIntegratedSecurity));
            services.AddControllers();
        }

        public static string SqlConnectionIntegratedSecurity
        {
            get
            {
                var sb = new SqlConnectionStringBuilder
                {
                    DataSource = "(localdb)\\MSSQLLocalDB",
                    IntegratedSecurity = true,
                    InitialCatalog = "MusicShopDatabase"
                };
                return sb.ConnectionString;
            }
        }

        public void Configure(IApplicationBuilder app)
        {
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseDeveloperExceptionPage();
            app.UseRouting();
            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    }
}