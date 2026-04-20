using CommunityToolkit.Maui.Views;

namespace DemoProject.Popups.Pages.Mct;

public partial class BasePopup : Popup
{
    public static readonly BindableProperty PopupTitleProperty =
        BindableProperty.Create(nameof(PopupTitle), typeof(string), typeof(BasePopup), null, BindingMode.OneTime, propertyChanged: PopupTitle_PropertyChanged);

    public string PopupTitle
    {
        get => (string)GetValue(PopupTitleProperty);
        set => SetValue(PopupTitleProperty, value);
    }

    public static readonly BindableProperty BasePopupContentProperty =
        BindableProperty.Create(nameof(BasePopupContent), typeof(View), typeof(BasePopup), null, propertyChanged: BasePopupContent_PropertyChanged);

    public View BasePopupContent
    {
        get => (View)GetValue(BasePopupContentProperty);
        set => SetValue(BasePopupContentProperty, value);
    }

    public static readonly BindableProperty PopupVerticalOptionsProperty =
        BindableProperty.Create(nameof(PopupVerticalOptions), typeof(LayoutOptions), typeof(BasePopup), LayoutOptions.Center, propertyChanged: PopupVerticalOptions_PropertyChanged);

    public LayoutOptions PopupVerticalOptions
    {
        get => (LayoutOptions)GetValue(PopupVerticalOptionsProperty);
        set => SetValue(PopupVerticalOptionsProperty, value);
    }

    private bool _isFirstLoad = true;

    public BasePopup()
    {
        InitializeComponent();

        SetLoadValues(this, this.Container);

        Opened += async (s, e) =>
        {
            if(BindingContext is IPageOnAppearing onAppearing)
            {
                await onAppearing.OnAppearing();
            }

            if(_isFirstLoad)
            {
                await Initialise();

                if(BindingContext is IPageInitialise pageInitialise)
                {
                    await pageInitialise.Initialise();
                }
            }

            AnimationOnOpen(this, this.Container);

            _isFirstLoad = false;

            LblTitle.Focus();
        };
    }

    public virtual void SetLoadValues(BasePopup container, Border popupContainer)
    {
        container.Opacity = 0;
        container.Container.Scale = 0;
    }

    public virtual void AnimationOnOpen(BasePopup container, Border popupContainer)
    {
        Animation loadingAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 1, Easing.SinOut) },
            { 0, 1, new Animation(_ => container.Container.Scale = _, container.Container.Scale, 1, Easing.SinOut) }
        };

        loadingAnimation.Commit(this, nameof(loadingAnimation), 16, 300u, null);
    }

    // TODO: Trigger (button + background pressed)
    public virtual async Task AnimationOnClose(BasePopup container, Border popupContainer)
    {
        TaskCompletionSource tcs = new();

        Animation closingAnimation = new()
        {
            { 0, 1, new Animation(_ => container.Opacity = _, container.Opacity, 0, Easing.SinIn) },
            { 0, 1, new Animation(_ => container.Container.Scale = _, container.Container.Scale, 0.8, Easing.SinIn) }
        };

        closingAnimation.Commit(this, nameof(closingAnimation), 16, 300u, null, finished: delegate
        {
            tcs.SetResult();
        });

        await tcs.Task;
    }

    public virtual Task Initialise()
    {
        return Task.CompletedTask;
    }

    private async void BtnClose_OnClicked(object? sender, EventArgs e)
    {
        await AnimationOnClose(this, this.Container);
        await CloseAsync();
    }

    private static void BasePopupContent_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.BaseContent.Content = basePopup.BasePopupContent;
        }
    }

    private static void PopupTitle_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.LblTitle.Text = basePopup.PopupTitle;
        }
    }

    private static void PopupVerticalOptions_PropertyChanged(BindableObject bindable, object oldValue, object newValue)
    {
        if(bindable is BasePopup basePopup)
        {
            basePopup.Container.VerticalOptions = basePopup.PopupVerticalOptions;
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, TappedEventArgs e)
    {
        await AnimationOnClose(this, this.Container);
        await CloseAsync();
    }
}

public interface IPageOnAppearing
{
    Task OnAppearing();
}

public interface IPageInitialise
{
    Task Initialise();
}