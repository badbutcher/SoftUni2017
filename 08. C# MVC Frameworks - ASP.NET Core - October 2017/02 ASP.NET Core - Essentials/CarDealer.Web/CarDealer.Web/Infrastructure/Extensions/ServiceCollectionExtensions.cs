namespace CarDealer.Web.Infrastructure.Extensions
{
    using System.Linq;
    using System.Reflection;
    using CarDealer.Services;
    using Microsoft.Extensions.DependencyInjection;

    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDomainServices(this IServiceCollection services)
        {
            Assembly
                .GetAssembly(typeof(IService))
                .GetTypes()
                .Where(t => t.IsClass && t.GetInterfaces().Any(i => i.Name == $"I{t.Name}"))
                .Select(t => new
                {
                    Intrface = t.GetInterface($"I{t.Name}"),
                    Implementation = t
                }).ToList()
                .ForEach(s => services.AddTransient(s.Intrface, s.Implementation));

            return services;
        }
    }
}