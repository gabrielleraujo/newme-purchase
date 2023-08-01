using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;
using MongoDB.Driver;
using Newme.Purchase.Domain.Repositories;
using Newme.Purchase.Domain.Messaging;
using Newme.Purchase.Infrastructure.Persistence;
using Newme.Purchase.Infrastructure.Persistence.Repositories;
using Newme.Purchase.Infrastructure.Consulting.Repositories;
using Newme.Purchase.Infrastructure.Consulting;
using MongoDB.Bson.Serialization;
using MongoDB.Bson.Serialization.Serializers;
using Newme.Purchase.Infrastructure.Messaging;
using Newme.Purchase.Application.Consulting.Repositories;
using Newme.Purchase.Infrastructure.Consulting.Mappings;

namespace Newme.Purchase.Infrastructure
{
    public static class InfrastructureModule
    {
        public static IServiceCollection AddInfrastructureModule(this IServiceCollection services)
        {            
            services
                .AddSqlServer()
                .AddMongo()
                .AddRepositories()
                .AddMessageBus();

            return services;
        }

        private static IServiceCollection AddSqlServer(this IServiceCollection services)
        {
            var configuration = services.BuildServiceProvider().GetService<IConfiguration>();
            
            services.AddDbContext<PurchaseCommandContext>(opt => {
                opt.UseSqlServer(configuration.GetConnectionString("Default"));
            });

            return services;
        }

        private static IServiceCollection AddMongo(this IServiceCollection services)
        {
            services.AddSingleton<MongoDbOptions>(sp => {
                var options = new MongoDbOptions();
                var configuration = sp.GetService<IConfiguration>();

                configuration.GetSection("Mongo").Bind(options);

                return options;
            });

            services.AddSingleton<IMongoClient>(sp => {
                var options = sp.GetService<MongoDbOptions>();

                var client = new MongoClient(options.ConnectionString);
                var db = client.GetDatabase(options.Database);

                return client;
            });

            services.AddSingleton(sp => {
                BsonSerializer.RegisterSerializer(new GuidSerializer(BsonType.String));
                BsonSerializer.RegisterSerializer(new DateTimeSerializer(BsonType.String));

                MongoMapper.Configure();

                var options = sp.GetService<MongoDbOptions>();
                var mongoClient = sp.GetService<IMongoClient>();

                var db = mongoClient.GetDatabase(options.Database);

                return db;
            });

            return services;
        }

        private static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped(typeof(IBaseQueryRepository<>), typeof(BaseQueryRepository<>));

            services.AddScoped<IPurchaseCommandRepository, PurchaseCommandRepository>();
            services.AddScoped<IPurchaseQueryRepository, PurchaseQueryRepository>();

            return services;
        }

        private static IServiceCollection AddMessageBus(this IServiceCollection services) {
            services.AddScoped<IMessageBusServer, RabbitMqService>();
            
            return services;
        }
    }
}