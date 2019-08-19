using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Cors.Internal;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using WebAPI.Application.Interface;
using WebAPI.Application.Repositories;
using WebAPI.Data.Context;
using WebAPI.Data.Repositories;
using WebAPI.Data.Repositories.Base;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Repository.Base;
using WebAPI.Domain.Interfaces.Service;
using WebAPI.Domain.Services;

namespace WebAPI
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
      services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
      //services.Configure<MvcOptions>(options =>
      //{
      //  options.Filters.Add(new CorsAuthorizationFilterFactory("AllowSpecificOrigin"));
      //});
      services.AddCors(options => {
      options.AddPolicy("CorsPolicy",
         builder =>
         builder.AllowAnyOrigin()
         .AllowAnyMethod()
         .WithExposedHeaders("content-disposition")
         .AllowAnyHeader()
         .AllowCredentials()
         .SetPreflightMaxAge(TimeSpan.FromSeconds(3600)));
      });
      services.AddAutoMapper();

      services.AddSingleton(typeof(IRepositoryBase<>), typeof(RepositoryBase<>));

      services.AddSingleton<IClienteApp, ClienteRepositoryApp>();

      services.AddSingleton<IClienteService, ClienteService>();

      services.AddSingleton<IClienteRepository, ClienteRepository>();

      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new Info { Title = "My API", Version = "v1" });
      });

      //services.AddDbContext<DataBaseContext>(options =>
      //options.UseSqlServer(Configuration.GetConnectionString("DevConnection")));
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IHostingEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
      }
      //app.UseCors(option => option.AllowAnyOrigin());
      app.UseCors("CorsPolicy");
      app.UseMvc();

      app.UseSwagger();
      app.UseSwaggerUI(c =>
      {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
      });
    }
  }
}
