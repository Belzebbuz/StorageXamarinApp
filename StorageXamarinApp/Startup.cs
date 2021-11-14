using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StorageXamarinApp
{
    public static class Startup
    {
        public static IServiceProvider ServiceProvider { get; set; }

        public static IServiceProvider Init()
        {
            IServiceProvider serviceProvider = new ServiceCollection()
                .ConfigureServices()
                .ConfigureViewModels()
                .BuildServiceProvider();

            ServiceProvider = serviceProvider;
            return serviceProvider;
        }
    }
}
