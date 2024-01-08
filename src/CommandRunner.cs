using Microsoft.Extensions.DependencyInjection;

namespace ABB.Commands;
public class CommandRunner
{
    private readonly IServiceProvider _serviceProvider;
    private readonly Dictionary<string, ACommand> _commands = new Dictionary<string, ACommand>();
    public CommandRunner(IServiceProvider serviceProvider) { 
        _serviceProvider = serviceProvider;
        _resolveCommands();
    }
    private void _resolveCommands()
    {
        IEnumerable<ACommand> commands = (IEnumerable<ACommand>) _serviceProvider.GetServices(typeof(ACommand));

        
        foreach (ACommand command in commands)
        {
            _commands.Add(command.Name(), command);
        }
    }

    public async Task Run(string commandName, string[] Args)
    {
        try
        {
            ACommand command = _commands[commandName];
            command.Args = Args.Skip(2).ToArray();
            await command.Run();
        }
        catch (KeyNotFoundException) {
            Console.WriteLine("The command {0} is not found.", commandName);
        }
    }
}

