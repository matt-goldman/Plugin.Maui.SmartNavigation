using DemoProject.Popups.ViewModels;

namespace DemoProject.Popups.Pages.Mct;

public partial class MctEasyPopup : BasePopup
{
	public MctEasyPopup(PopupViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}