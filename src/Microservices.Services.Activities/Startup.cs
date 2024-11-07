using Microservices.Common.Commands;
using Microservices.Common.Mongo;
using Microservices.Common.RabbitMq;
using Microservices.Services.Activities.Domain.Repositories;
using Microservices.Services.Activities.Handlers;
using Microservices.Services.Activities.Repositories;
using Microservices.Services.Activities.Services;

namespace Microservices.Services.Activities
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
            services.AddLogging();

            //services.AddJwt(Configuration);
            services.AddRabbitMq(Configuration);
            services.AddMongoDb(Configuration);
            services.AddSingleton<ICommandHandler<CreateActivity>, CreateActivityHandler>();
            //services.AddSingleton<IEventHandler<UserAuthenticated>, UserAuthenticatedHandler>();
            //services.AddSingleton<IEventHandler<UserCreated>, UserCreatedHandler>();
            services.AddSingleton<IActivityRepository, ActivityRepository>();
            services.AddSingleton<ICategoryRepository, CategoryRepository>();
            services.AddSingleton<IDatabaseSeeder, CustomMongoSeeder>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                //https://docs.microsoft.com/en-us/aspnet/core/fundamentals/error-handling?view=aspnetcore-2.2
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.ApplicationServices.GetService<IDatabaseInitializer>().InitializeAsync();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
