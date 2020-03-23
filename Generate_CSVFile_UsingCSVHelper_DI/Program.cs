using Microsoft.Extensions.DependencyInjection;
using System;

namespace Generate_CSVFile_UsingCSVHelper_DI
{
    class Program
    {
        public static IServiceCollection Services = new ServiceCollection();
        public static IServiceProvider ServiceProvider;
        private static Guid _sessionId = Guid.NewGuid();
        private static ConnectionStrings _connectionString = new ConnectionStrings();
        private static IOSettings _ioSettings = new IOSettings();


        static void Main(string[] args)
        {
            BootstrapServices();

            var appService = ServiceProvider.GetService<IApplicationService>();

            try
            {
                //calling the serivce
                appService.GenerateExtract();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        private static void BootstrapServices()
        {
            Services.AddConfigurationOptions();
            Services.AddServices();
            ServiceProvider = Services.BuildServiceProvider();
        }
    }
}
