namespace Commands;

public abstract class ACommand
{
    public ACommand() { }
    public string[]? Args { get; set; }
    public abstract Task Run();
    public abstract string Name();
}
