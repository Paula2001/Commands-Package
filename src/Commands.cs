using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Commands;

public static class Commands
{
    public async static Task<IServiceCollection> AddCommands(this IServiceCollection services, string[] args,WebApplication w)
    {        
        if (isValidCommand(args))
        {
            CommandRunner? cr = new CommandRunner(services.BuildServiceProvider());
            await cr.Run(args[1], args);
            w.Lifetime.StopApplication();
        }

        return services;
    }
    
    private static bool isValidCommand(string[] args)
    {
        return args.Length > 0 && Array.IndexOf(args, "custom-command") != -1;
    }
}
