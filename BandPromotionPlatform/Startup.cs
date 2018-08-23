using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BandPromotionPlatform.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using BandPromotionPlatform.Models;
using Stripe;
using Microsoft.AspNetCore.Authentication.OpenIdConnect;

namespace BandPromotionPlatform
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
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //AddIdentity adds cookie based authentication
            //Adds scoped classes for things like UserManager, SignInManager, PasswordHashers etc...
            //NOTE: automatically addss valited user to from a cookie to the HttpContext.User
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));

            //services.AddIdentity<ApplicationUser, IdentityRole>()
            //    //Adds UserStore and RoleStore from the context  
            //    //That are consumed by the UserManager and RoleManager
            //    .AddEntityFrameworkStores<ApplicationDbContext>()
            //    //Adds a provider that generates unique keys and hashes for things like 
            //    //forgot password links, phone number verification codes etc...
            //    .AddDefaultTokenProviders();
            // TODO: Change Login Url
            // and change cookie timeout

            //Old code below(before finding awesome tutorial)
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddDefaultUI()
                .AddDefaultTokenProviders()
                .AddEntityFrameworkStores<ApplicationDbContext>();

            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            //Store instance of the Dependancy Injection service provider so our application can access it anywhere
            //IoCContainer.Provider = (ServiceProvider)serviceProvider;
            //Setup Identity

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseAuthentication();
            app.UseStaticFiles();
            app.UseCookiePolicy();

           
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
