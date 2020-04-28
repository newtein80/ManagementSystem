using ManagementSystem.Application.Dapper.Interface;
using ManagementSystem.Infra.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace ManagementSystem.Infra
{
    public static class InfraDependencyInjection
    {
        public static IServiceCollection AddInfraDependencyInjection(this IServiceCollection services)
        {
            services.AddTransient<ITestTableRepository, TestTableRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
