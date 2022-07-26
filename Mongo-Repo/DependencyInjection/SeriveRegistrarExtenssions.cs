using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mongo_Repo.DependencyInjection
{
    /// <summary>
    /// Extenssion Method To add
    /// All the required services for Mongo-Repo
    /// </summary>
    public static class SeriveRegistrarExtenssions
    {
        
        public static void AddMongoRepoServices(this IServiceCollection services)
        {
            ServiceRegistrar.RegisterMongo(services);
        }
        
    }
}
