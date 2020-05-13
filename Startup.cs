using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using AspNetCrud.Providers;
using AspNetCrud.Providers.Contracts;
using AspNetCrud.Services;
using AspNetCrud.Services.Contracts;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace AspNetCrud
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
            services.Configure<AppSettings>(appSettings => {
                appSettings.Issuer = this.Configuration["JwtConfiguration:Issuer"];
                appSettings.Audience = this.Configuration["JwtConfiguration:Audience"];
                appSettings.SecretKey = this.Configuration["JwtConfiguration:SecretKey"];
            });
            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(
                options => {
                    options.TokenValidationParameters = new TokenValidationParameters{
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = this.Configuration["JwtConfiguration:Issuer"],
                        ValidAudience = this.Configuration["JwtConfiguration:Audience"],
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.Configuration["JwtConfiguration:SecretKey"]))
                    };
                }
            );

            // Services dependencies
            services.AddTransient<IEmployeeService, EmployeeService>();
            services.AddTransient<IJwtService, JwtService>();
            // Providers dependencies
            services.AddTransient<IEmployeeProvider, EmployeeProvider>(
                serviceProvider => new EmployeeProvider(this.Configuration["ConnectionString"])
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseStaticFiles();
            }
            app.Map("/api", options => {
                options.UseRouting();
                options.UseAuthentication();
                options.UseAuthorization();
                options.UseEndpoints(endpoints => {
                    endpoints.MapControllers();
                });
            });

            app.UseHttpsRedirection();        

        }
    }
}
