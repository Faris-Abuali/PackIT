using PackIT.Domain.Factories;
using PackIT.Domain.Policies;
using PackIT.Shared;

namespace PackIT.Application;

public static class Extensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddCommands();
        services.AddSingleton<IPackingListFactory, PackingListFactory>();
        
        // Automatic Command Handlers Registration
        services.Scan(s => s.FromAssemblies(typeof(IPackingItemsPolicy).Assembly)
            .AddClasses(c => c.AssignableTo(typeof(IPackingItemsPolicy)))
            .AsImplementedInterfaces() // Registers each matching concrete type as all of its implemented interfaces.
            .WithSingletonLifetime());
        
        return services;
    }
}