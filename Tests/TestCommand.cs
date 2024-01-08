using Commands;

namespace Tests;

class TestCommand : ACommand
{
    public override string Name()
    {
        return "test";
    }

    public override Task Run()
    {
        Console.WriteLine("this is command ran");
        return Task.CompletedTask;
    }
}