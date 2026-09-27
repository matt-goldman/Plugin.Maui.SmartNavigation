using DemoClassLibrary.ViewModels;

namespace DemoClassLibrary.Pages;

public partial class ClassLibPage : ContentPage
{
    public ClassLibPage(ClassLibViewModel viewModel)
    {
        InitializeComponent();
        BindingContext = viewModel;
    }
}