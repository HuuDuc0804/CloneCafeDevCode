using CafeDevCode.Logic.Queries.Implement;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CafeDevCode.Logic
{
    public static class Register
    {
        public static IServiceCollection AddQueries(this IServiceCollection services)
        {
            services.AddScoped<IAuthorQueries, AuthorQueries>();
            services.AddScoped<IUserQueries, UserQueries>();
            return services;
        }
    }
}
