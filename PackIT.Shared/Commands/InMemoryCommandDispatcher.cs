using PackIT.Shared.Abstractions.Commands;

namespace PackIT.Shared.Commands;

internal sealed class InMemoryCommandDispatcher : ICommandDispatcher
{
    private readonly IServiceProvider _serviceProvider;
    
    public InMemoryCommandDispatcher(IServiceProvider serviceProvider)
        => _serviceProvider = serviceProvider;

    public async Task DispatchAsync<TCommand>(TCommand command) where TCommand : class, ICommand
    {
        using var scope = _serviceProvider.CreateScope();
        var handler = scope.ServiceProvider.GetRequiredService<ICommandHandler<TCommand>>();

        await handler.HandleAsync(command);
    }
}

/***
 * The combination of internal and sealed in this context ensures that the InMemoryCommandDispatcher class can only be used within the same assembly, and it cannot be subclassed or extended by any other class, ensuring its integrity and preventing accidental modifications from external assemblies.
 */

