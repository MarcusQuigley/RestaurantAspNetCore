using AspNet_Restaurant.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace OdeToFood
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
            services.AddDbContextPool<RestaurantDBContext>(options=> {
                options.UseSqlServer(Configuration.GetConnectionString("DbConnection"));
                });
            
            //services.AddSingleton<IRestaurantDataService, InMemoryRestaurantDataService>();
            services.AddScoped<IRestaurantDataService, SqlRestaurantData>();
            services.AddMvc().AddRazorRuntimeCompilation();

            services.AddRazorPages();
            services.AddControllers();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //each piece of middleware has ability to stop processing and not call into next piece of middleware
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts(); //instructs browser to only access info over secure connection
            }

            app.Use(SayHelloMiddleware);

            app.UseHttpsRedirection(); // set http redirect if accessing using http
            app.UseStaticFiles(); //attempts to serve request by responding with a file in wwwroot folder
            app.UseNodeModules(); // serves static file from nodemodule folder
            app.UseRouting(); //middleware to track if user has consented to use of cookies


            //app.useMvc(); //if nothing else has served a file or done any work then this will look at request and try to render a razor page or invoke controller that will render a razor view
            //app.UseAuthentication(); //establish identity of user
            //app.UseSignalR; //do realtime websocket communication
           
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
                endpoints.MapControllers();
            });
           
        }

        private  RequestDelegate SayHelloMiddleware(RequestDelegate next)
        {
            return async ctx =>
            {
                if (ctx.Request.Path.StartsWithSegments("/hello"))
                {
                    await ctx.Response.WriteAsync("Hello world!");
                }
                else
                {
                    await next(ctx); 
                }
            };
        }
    }
}
