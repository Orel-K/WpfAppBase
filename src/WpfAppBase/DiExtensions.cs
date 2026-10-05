using CommunityToolkit.Mvvm.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using WpfAppBase.ViewModels;

namespace WpfAppBase;

static class DiExtensions
{
    public static IServiceCollection AddViewModelsFromCurrentAssembly(this IServiceCollection services)
    {
        var types = Assembly.GetCallingAssembly().GetTypes();

        var vmTypes = types.Where(x => x.IsAssignableTo(typeof(ViewModelBase)))
            .Where(x => x.IsAbstract == false);

        foreach (var vmType in vmTypes)
        {
            var sd = new ServiceDescriptor(vmType, sp =>
            {
                var vm = ActivatorUtilities.CreateInstance(sp, vmType);

                var msg = sp.GetRequiredService<IMessenger>();

                msg.RegisterAll(vm);

                return vm;

            }, ServiceLifetime.Transient);

            services.Add(sd);
        }

        return services;
    }
}
