using System.Reflection;
using PackIT.Shared.Abstractions.Commands;
using PackIT.Shared.Commands;

namespace PackIT.Shared;

public static class Extensions
{
    public static IServiceCollection AddCommands(this IServiceCollection services)
    {
        var assembly = Assembly.GetCallingAssembly(); 
            
        services.AddSingleton<ICommandDispatcher, InMemoryCommandDispatcher>();
        
        // Automatic Command Handlers Registration
        services.Scan(s => s.FromAssemblies(assembly)
            .AddClasses(c => c.AssignableTo(typeof(ICommandHandler<>)))
            .AsImplementedInterfaces() // Registers each matching concrete type as all of its implemented interfaces.
            .WithScopedLifetime()); // Registers each matching concrete type with Scoped lifetime.
        
        return services;
    }
}