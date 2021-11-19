﻿using Microsoft.Extensions.DependencyInjection;
using StorageXamarinApp.Services;
using StorageXamarinApp.ViewModels;
using Refit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace StorageXamarinApp
{
    public static class DependencyInjectionContainer
    {
        public static IServiceCollection ConfigureServices(this IServiceCollection services)
        {
            services.AddRefitClient<IStorageServer>(new RefitSettings()
            {
                ContentSerializer = new SystemTextJsonContentSerializer(
                    new JsonSerializerOptions()
                    {
                        PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                        WriteIndented = true
                    })
            }).ConfigureHttpClient(c => c.BaseAddress = new Uri("https://storageapiservice.azurewebsites.net/api"));
            services.AddSingleton<IAccountService, AccountsService>();
            services.AddSingleton<INomenclatureService, NomenclatureService>();
            services.AddSingleton<IReceiveService, ReceiveService>();
            services.AddSingleton<IShippingService, ShippingService>();
            return services;
        }

        public static IServiceCollection ConfigureViewModels(this IServiceCollection services)
        {
            services.AddTransient<AccountsViewModel>();
            services.AddTransient<AddNomenclatureViewModel>();
            services.AddTransient<AddReceiveOperationViewModel>();
            services.AddTransient<AddShippingOperationViewModel>();
            services.AddTransient<ShippingViewModel>();
            services.AddTransient<NomenclatureViewModel>();
            services.AddTransient<ReceiveViewModel>();
            services.AddSingleton<MainPageModel>();
            return services;
        }
    }
}
