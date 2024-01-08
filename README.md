# Commands Package

## Description

Commands Package gives you <strong>CLI</strong> commands for your project by creating commands with a specific signature.

## Usage
 -  As this a private package only in ABB you will have to create `nuget.config` in the same directory of the sln and go to <a href="https://dev.azure.com/ABB-IAA-EUOPC/Digital%20Excitation/_artifacts/feed/ABB-IAA-EUOPC/connect" target="_blank">Nuget Auth</a>
 - ```dotnet add package ABB.Commands --interactive```
 - Add this after build the web app : `await builder.Services.AddCommands(string[] args, WebApplication w);`
 - `services.AddScoped<ACommand, SeedCommand>()`
## Example of command class

```
using ABB.Commands;
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


