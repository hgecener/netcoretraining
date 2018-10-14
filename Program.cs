using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace OdeToFood
{
    public class Program
    {
        // .Net Core is constructed as a console mode application.. Uses Main is entry point
        public static void Main(string[] args) // Run this first.. entry point
        {
            BuildWebHost(args).Run(); // Web server runs the args. Runs the builded WebHost
        }
        // IIS Express .. The web server is configured
        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)  // Will use Kestrel seb server. Sets up IIS integration
                                                // This is web host builder. Also sets Logging... 
                                                //IConfiguration object is created by WebHostBuilder
                                                //reads JSON file (appsettings.json)
                                                //reads User secrets
                                                //reads Environment variables
                                                //reads command line arguments
                                                // Configuration service in startup.cs reads these
                .UseStartup<Startup>() // Startup class configure the web host ... Look at startup.cs how is configured 
                                        //*** Important
                .Build(); // Build
    }
}
