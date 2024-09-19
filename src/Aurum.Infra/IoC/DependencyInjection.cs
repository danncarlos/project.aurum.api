//using Aurum.Domain.Commands.Product;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using Aurum.Domain.Validators;
using Aurum.Infra.Repositories;
using FluentValidation;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aurum.Infra.IoC {
    public static class DependencyInjectionValidators {
        public static void AddDependency(IServiceCollection services) {
            services.AddScoped<IValidator<Product>, ProductValidator>();
        }
    }

    public static class DependencyInjectionRepositories {
        public static void AddDependency(IServiceCollection services) {
            services.AddScoped<IProductRepository, ProductRepository>();
        }
    }

}
