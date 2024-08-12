using Microsoft.Extensions.DependencyInjection;
using System.Reflection;


namespace MiniNetflix.Core.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddMediatR(config => config.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
        }
    }
}
