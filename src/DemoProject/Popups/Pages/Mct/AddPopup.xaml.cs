namespace DemoProject.Popups.Pages.Mct;

public partial class AddPopup : BasePopup
{
    public AddPopup()
    {
        InitializeComponent();
    }

    public override void SetLoadValues(BasePopup container, Border popupContainer)
    {
        container.Opacity = 0;
        popupContainer.TranslationY = -200;
    }

    public override void AnimationOnOpen(BasePopup container, Border popupContainer)
    {
        Animation openAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 1, Easing.SinOut) },
            { 0, 1, new Animation(_ => popupContainer.TranslationY = _, popupContainer.TranslationY, 0, Easing.SinOut) }
        };

        openAnimation.Commit(this, nameof(openAnimation), 16, 1500u, null);
    }

    public override async Task AnimationOnClose(BasePopup container, Border popupContainer)
    {
        TaskCompletionSource tcs = new();

        Animation closeAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 0, Easing.SinIn) },
            { 0, 1, new Animation(_ => popupContainer.TranslationY = _, popupContainer.TranslationY, -200, Easing.SinIn) }
        };

        closeAnimation.Commit(this, nameof(closeAnimation), 16, 700u, null, finished: delegate
        {
            tcs.SetResult();
        });

        await tcs.Task;
    }
}