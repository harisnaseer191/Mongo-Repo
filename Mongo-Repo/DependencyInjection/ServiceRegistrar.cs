using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Mongo_Repo.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo.DependencyInjection
{
    public static class ServiceRegistrar
    {
        public static void RegisterMongo(IServiceCollection services)
        {
            services.AddSingleton<IAcquireMongoClient>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<AcquireMongoClient>>().Value);

            // MongoRepo Registering
            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));

        }
    }
}
