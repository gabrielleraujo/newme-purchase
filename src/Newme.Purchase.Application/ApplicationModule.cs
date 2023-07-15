using Microsoft.Extensions.DependencyInjection;
using Newme.Purchase.Application.Services;
using Newme.Purchase.Application.AutoMapper;
using Newme.Purchase.Application.Subscribers;
using System.Reflection;
using Newme.Purchase.Application.Validations;
using FluentValidation;
using Newme.Purchase.Domain.Models.Discounts;
using Newme.Purchase.Domain.Models.Discounts.Interfaces;
using Newme.Purchase.Application.Subscribers.PaymentResolvedPurchaseOrder;
using Newme.Purchase.Application.Subscribers.ReducedProductItemStockReceived;

namespace Newme.Purchase.Application
{
    public static class ApplicationModule
    {
        public static IServiceCollection AddApplicationModule(this IServiceCollection services)
        {
            services
                .AddSubscribers()
                .AddValidators()
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()))
                .AddApplicationServices()
                .AddAutoMapperConfiguration();

            return services;
        }

        private static IServiceCollection AddSubscribers(this IServiceCollection services) {
            services.AddHostedService<PaymentResolvedPurchaseOrderSubscriber>();
            services.AddHostedService<ReducedProductItemStockReceivedSubscriber>();
            
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<CreatePurchaseCommandValidation>(ServiceLifetime.Scoped);

            return services;
        }

        private static IServiceCollection AddApplicationServices(this IServiceCollection services)
        {
            services.AddScoped<IPurchaseApplicationService, PurchaseApplicationService>();
            services.AddScoped<IChainOfDiscounts, ChainOfDiscounts>();

            return services;
        }

        public static IServiceCollection AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(
                typeof(ConsultingToViewModelMappingProfile), 
                typeof(DomainToConsultingModelMappingProfile),
                typeof(InputModelToCommandMappingProfile), 
                typeof(InputModelToDomainMappingProfile)
            );

            return services;
        }
    }
}