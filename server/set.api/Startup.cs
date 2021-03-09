using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using set.service.Common;
using set.service.Common.Interface;
using set.service.Practice;
using set.service.Practice.Interface;

namespace set.api
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
      services.AddCors();

      services.AddControllers();
      services.AddScoped<ICardGeneratorService, CardGeneratorService>();
      services.AddScoped<IPracticeService, PracticeService>();
      services.AddScoped<ISetValidatorService, SetValidatorService>();
      services.AddSwaggerGen(c =>
      {
        c.SwaggerDoc("v1", new OpenApiInfo { Title = "set.api", Version = "v1" });
      });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
      if (env.IsDevelopment())
      {
        app.UseDeveloperExceptionPage();
        app.UseSwagger();
        app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "set.api v1"));
      }

      app.UseCors(options => options.AllowAnyOrigin()
                                    .AllowAnyMethod()
                                    .AllowAnyHeader());

      app.UseHttpsRedirection();

      app.UseRouting();

      app.UseCors();

      app.UseAuthorization();

      app.UseEndpoints(endpoints =>
      {
        endpoints.MapControllers();
      });
    }
  }
}
