namespace DemoClassLibrary.Services;

public interface IClassLibService
{
    public string GetNewGuid();
}

public class ClassLibService : IClassLibService
{
    public string GetNewGuid() => Guid.NewGuid().ToString();
}