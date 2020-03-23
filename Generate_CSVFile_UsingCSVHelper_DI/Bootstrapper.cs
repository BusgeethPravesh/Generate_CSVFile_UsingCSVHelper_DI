using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    public static class Bootstrapper
    {
        private static IConfigurationRoot _configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", false, true)
           .Build();

        public static void AddConfigurationOptions(this IServiceCollection services)
        {
            // load the json appsettings

            // Adding the Option Extension to the service collection
            services.AddOptions();

            // Adding the configuration sections to the service collection
            services.Configure<ConnectionStrings>(_configuration.GetSection("ConnectionStrings"));
            services.Configure<IOSettings>(_configuration.GetSection("IOSetttings"));
        }

        public static void AddServices(this IServiceCollection services)
        {

            services.AddScoped<IQueryPending, QueryPending>();
            services.AddScoped<IFileService, FileService>();
            services.AddScoped<IApplicationService, ApplicationService>();

        }
    }
}
