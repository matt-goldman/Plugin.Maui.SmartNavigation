namespace DemoProject.Popups.Pages.Mct;

public class TestObject
{
    public int Id { get; set; }

    public string Description { get; set; } = string.Empty;

    public override string ToString() => $"ID: {Id}, Description: {Description}";
}
