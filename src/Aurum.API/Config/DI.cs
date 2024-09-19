using Aurum.Application.Commands;
using Aurum.Application.CommandValidators;
using Aurum.Application.Handlers;
using Aurum.Domain.Entity.Product;
using Aurum.Domain.Repositories;
using Aurum.Domain.Validators;
using Aurum.Infra.Repositories;
using FluentValidation;

namespace Aurum.API.Config {
    public static class DependencyInjectionCommandValidators {
        public static void AddDependency(IServiceCollection services) {
            services.AddScoped<IValidator<UpdateProductCommand>, UpdateProductCommandValidator>();
        }
    }

    public static class DependencyInjectionCommandMediator {
        public static void AddDependency(IServiceCollection services) {
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(CreateProductCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(UpdateProductCommandHandler).Assembly));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(GetProductByIdQueryHandler).Assembly));
        }
    }

}
