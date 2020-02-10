using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using EmployeeDirectory.DataAccess;
using EmployeeDirectory.DataAccess.Context;
using EmployeeDirectory.DataAccess.Contracts;
using EmployeeDirectory.DataAccess.Implementations;
using EmployeeDirectory.Example.BLL.Contracts;
using EmployeeDirectory.Example.BLL.Implementation;
using EmployeeDirectory.Example.Client.DTO.Create;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EmployeeDirectory.Example.WebAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddAutoMapper(typeof(Startup));
            
            // BLL
            services.Add(new ServiceDescriptor(typeof(IEmployeeCreateService), typeof(EmployeeCreateService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEmployeeGetService), typeof(EmployeeGetService), ServiceLifetime.Scoped));
            
            // DataAccess
            services.Add(new ServiceDescriptor(typeof(IEmployeeDataAccess), typeof(EmployeeDataAccess), ServiceLifetime.Transient));
            services.Add(new ServiceDescriptor(typeof(IDepartmentDataAccess), typeof(DepartmentDataAccess), ServiceLifetime.Transient));
            
            // DB Contexts
            services.AddDbContext<EmployeeDirectoryContext>(options =>
                options.UseSqlServer(this.Configuration.GetConnectionString("EmployeeDirectory")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
        }
    }
}