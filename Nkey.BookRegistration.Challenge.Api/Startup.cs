using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
