using Avalonia.Controls;
using Microsoft.Extensions.DependencyInjection;

namespace Backend.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceProvider? GetServiceProvider(this IResourceHost control) {
            return (IServiceProvider) control.FindResource(typeof(IServiceProvider))!;
        }

        public static T CreateInstance<T>(this IResourceHost control) {
            return ActivatorUtilities.CreateInstance<T>(control.GetServiceProvider() ?? throw new InvalidOperationException());
        }
    }
}
