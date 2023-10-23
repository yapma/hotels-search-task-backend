using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Persistence.Extentions
{
    public static class PersistenceServicesConfig
    {
        public static void AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            
        }
    }
}
