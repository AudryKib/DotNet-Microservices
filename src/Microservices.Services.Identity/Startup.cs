using Microservices.Common.RabbitMq;

namespace Microservices.Services.Identity
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
            //services.AddMongoDb(Configuration);

            //// Link handlers interfaces with handlers.
            //    services.AddSingleton<ICommandHandler<ActivityCreated>, ActivityCreatedhandler>();
            //services.AddSingleton<IEventHandler<UserAuthenticated>, UserAuthenticatedHandler>();
            //services.AddSingleton<IEventHandler<UserCreated>, UserCreatedHandler>();
            //services.AddSingleton<IActivityRepository, ActivityRepository>();
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

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
