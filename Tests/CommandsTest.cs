using Microsoft.Extensions.DependencyInjection;
using Commands;
using Microsoft.AspNetCore.Builder;

namespace Tests;

public class UnitTest1
{
    private IServiceCollection _serviceProvider;
    public UnitTest1()
    {
        _serviceProvider = new ServiceCollection();
        _serviceProvider.BuildServiceProvider();
    }
    [Fact]
    public async void TestShouldRunCommand()
    {

        var sw = new StringWriter();
        Console.SetOut(sw);

        string[] args = {"custom-command", "test"};
        _serviceProvider.AddScoped<ACommand, TestCommands>();
        var asd = WebApplication.CreateBuilder(args);
        var asdasd = asd.Build();
        await _serviceProvider.AddCommands(args , asdasd);
        try
        {
            asdasd.Run();
        }
        catch (OperationCanceledException)
        {
        }
        Assert.Contains("this is command ran",sw.ToString());
        Assert.Contains("Application is shutting down",sw.ToString());
    }

    [Fact]
    public async void TestShouldNotRunCommandIfNotFound()
    {

        var sw = new StringWriter();
        Console.SetOut(sw);

        string[] args = {"custom-command", "test2"};
        _serviceProvider.AddScoped<ACommand, TestCommands>();
        var asd = WebApplication.CreateBuilder(args);
        var asdasd = asd.Build();
        await _serviceProvider.AddCommands(args , asdasd);
        try
        {
            asdasd.Run();
        }
        catch (OperationCanceledException x)
        {
        }
        Assert.Contains("The command test2 is not found",sw.ToString());
        Assert.Contains("Application is shutting down",sw.ToString());
    }
}