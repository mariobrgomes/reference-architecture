﻿using Application.UseCases;
using Microsoft.Extensions.DependencyInjection;

namespace WebApi.DependencyInjection
{
    public static class ApplicationExtensions
    {
        public static IServiceCollection AddUseCases(this IServiceCollection services)
        {
            services.AddScoped<Application.Boundaries.CreateCheckingAccount.IUseCase, CreateCheckingAccount>();

            return services;
        }
    }
}
