using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // IConfiguration reads appsettings.json properties.
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class StartupAppUse1
    {
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        // Configures how .Net framework bhaves
        // HTTP pipe line , you need to register services here. Example you can add AntiForgery or AddNodeJsServices...
        // Add your custome services like 
        public void ConfigureServices(IServiceCollection services)
        {
            // Here Dependency injections
            services.AddSingleton<IGreeter, Greeter>(); // Paseses Interface and Class here.. Class is implementation here. Dpendincy Injection
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline. **** IMPORTANT
        // Configures the response
        // Uses dependency injection and looks up the cunfigure parameters which are like IApplicationBuilder and IHostingEnvironment
        // Responde the request
        public void Configure(IApplicationBuilder app, 
                            IHostingEnvironment env,
                            //IConfiguration configuration, **1**
                            IGreeter greeter,
                            ILogger<Startup> logger)
        {
            // if (env.IsDevelopment())
            // {
            //     app.UseDeveloperExceptionPage();
            // }

            app.Use(next => {
                // This is middleware
                return async context =>{
                    logger.LogInformation("Request incomming ****");
                    if (context.Request.Path.StartsWithSegments("/mym")){
                        await context.Response.WriteAsync("Hit!!!"); // Response is sent. no next step.
                        logger.LogInformation("Request handled ****");
                    }
                    else
                    {
                        await next(context); // Goes next method in the pipeline below
                        logger.LogInformation("Request outgoing ****");
                    }

                };
            });  //Adds a middleware delegate to the application's request pipeline.

            app.UseWelcomePage(new WelcomePageOptions
            {
                Path="/wp" // only returns /wp is entered in URL. 
            }); // This allows pass object which is now WelcomPageOptios..
            // If you don't give Welcome object always return Welcome page and does not run rest of the code below.. *** Important

            app.Run(async (context) =>
            {
                //var greeting = configuration["Greeting"]; // **1** Gets "Greeting" property from appsettings.json file by IConfiguration object
                // Looks if there is Environment variable is named "Greeting" is override to appsettings, 
                //Command Line Arguments also overrides to all.
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync( greeting );
            });
        }
    }
}
