using Microsoft.AspNetCore.Mvc.Authorization;
using SampleNetCoreWebAPI.Business.Class;
using SampleNetCoreWebAPI.Business.Interface;

namespace SampleNetCoreWebAPI
{
    public class Startup
    {
        public IConfiguration configRoot
        {
            get;
        }
        public Startup(IConfiguration configuration)
        {
            configRoot = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
            {
                options.AddPolicy(
                    "_hhaOrigins",
                    builder =>
                    {
                        builder.SetIsOriginAllowedToAllowWildcardSubdomains()
                               .WithOrigins("*")
                               .AllowAnyMethod()
                               .AllowAnyHeader();
                    });
            });
            services.AddTransient<ISweetMakerBL, SweetMakerBL>();

            services.AddMvcCore(options =>
            {
                options.EnableEndpointRouting = false;
                options.Filters.Add(new AllowAnonymousFilter());
            });
        }
        public void Configure(WebApplication app, IWebHostEnvironment env)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
            app.UseAuthorization();
            app.MapControllers();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseRouting();
            app.UseCors("_hhaOrigins");
            app.Run();
            app.UseMvc();
            
        }
    }
}
