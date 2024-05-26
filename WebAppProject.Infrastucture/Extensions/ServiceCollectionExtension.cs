using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WebAppProject.Data;

namespace WebAppProject.Infrastucture.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static IServiceCollection AddApplicationServises(this IServiceCollection services)
        {
            services.AddServices(typeof(ISqlDbAccessService));

            return services;
        }

        public static void AddServices(this IServiceCollection services, Type serviceType)
        {
            Assembly? serviceAssembly = Assembly.GetAssembly(serviceType);
            if (serviceAssembly == null)
            {
                throw new InvalidOperationException("Invalid Service type provided!");
            }
            Type[] serviceTypes = serviceAssembly
                .GetTypes()
                .Where(t => t.Name.EndsWith("Service") && !t.IsInterface)
                .ToArray();
            foreach (Type implamentationType in serviceTypes)
            {
                Type? interfaceType = implamentationType.GetInterface($"I{implamentationType.Name}");

                if (interfaceType == null)
                {
                    throw new InvalidOperationException($"No Interface is provided for the service whih name: {implamentationType.Name}");
                }
                services.AddScoped(interfaceType, implamentationType);
            }
        }
    }
}
