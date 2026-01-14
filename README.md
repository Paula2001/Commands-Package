# Commands Package

## Description

Commands Package gives you <strong>CLI</strong> commands for your project by creating commands with a specific signature.

```
    builder.Services.AddScoped<ACommand, SeedCommand>();
    builder.Services.AddCommands(args, app);
```

```
using Paula.Commands;
public class SeedCommand : ACommand
{
    public override string Name()
    {
        return "seed";
    }

    public override Task Run()
    {
        Console.WriteLine("this is the seed command");
        return Task.CompletedTask;
    }
}
```


