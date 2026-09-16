namespace DemoProject.Popups.Pages.Mct;

public partial class MessagePopup : BasePopup
{
    public MessagePopupModel Message { get; set; }
    public MessagePopup(MessagePopupModel message)
    {
        InitializeComponent();

        Message = message;

        BindingContext = this;
    }

    private async void OnCloseClicked(object? sender, EventArgs e)
    {
        await CloseAsync();
    }
}

public sealed record MessagePopupModel()
{
    public string? Button { get; set; }
    public string? ButtonLink { get; set; }
    public bool ButtonEnabled { get; set; } = true;
    public EventHandler? ButtonCallBack { get; set; }
    public required string Title { get; set; }
    public required string Message { get; set; }
}