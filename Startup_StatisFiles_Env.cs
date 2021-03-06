﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration; // IConfiguration reads appsettings.json properties.
using Microsoft.Extensions.Logging;
using OdeToFood.Services;

namespace OdeToFood
{
    public class Startup_StatisFiles_Env
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
                            IHostingEnvironment env,  // ASPNETCORE_ENVIRONMENT variable is default "Production"
                            //IConfiguration configuration, **1**
                            IGreeter greeter,
                            ILogger<Startup> logger)
        {
            // This gives error details only if development runs.. not in Production
            if (env.IsDevelopment())
            {
                 app.UseDeveloperExceptionPage(); // **1.1**
            }

            // app.UseDefaultFiles(); // Default file names are configurable. Like "index.html". You can configure in method parameters.(args)
            // app.UseStaticFiles(); // Serves the files under wwwroot folder... If nothing finds a releated file passes to next method
        
            app.UseFileServer(); // Allow static files

            app.Run(async (context) =>
            {
                //  if (env.IsDevelopment()){
                //     throw new Exception("Error!!"); // **1.1** Throw error and UseDeveloperExceptionPage handles and displays above****
                //  }
                //var greeting = configuration["Greeting"]; // **1** Gets "Greeting" property from appsettings.json file by IConfiguration object
                // Looks if there is Environment variable is named "Greeting" is override to appsettings, 
               
                //Command Line Arguments also overrides to all.
                var greeting = greeter.GetMessageOfTheDay();
                await context.Response.WriteAsync( $"{greeting} : {env.EnvironmentName} ");
            });
        }
    }
}
