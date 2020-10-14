using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Nkey.BookRegistration.Challenge.Data.Context;
using Nkey.BookRegistration.Challenge.Data.Repositories;
using Nkey.BookRegistration.Challenge.Domain.Services;
using Nkey.BookRegistration.Challenge.Domain.Services.Interfaces;

namespace Nkey.BookRegistration.Challenge.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        readonly string AllowedSpecificOrigins = "_AllowedSpecificOrigins";
        readonly string[] SpecifcUrlOriginsList = { "http://localhost:9000" };

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options =>
                options.AddPolicy(AllowedSpecificOrigins, builder => builder.WithOrigins(SpecifcUrlOriginsList).AllowAnyHeader().AllowAnyMethod()));
            services.AddControllers();
            services.AddDbContext<BookRegistrationContext>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IBookService, BookService>();

            services.AddSwaggerGen(x =>
            {
                x.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Nkey Book Registration API",
                    Version = "v1",
                    Description = "Book Registration API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(AllowedSpecificOrigins);

            app.UseRouting();

            app.UseAuthorization();

            app.UseSwagger();
            app.UseSwaggerUI(x =>
            {
                x.SwaggerEndpoint(url: "/swagger/v1/swagger.json", name: "Book Registration");
            });

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
