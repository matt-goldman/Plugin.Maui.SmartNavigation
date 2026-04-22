using DemoProject.Popups.ViewModels;

namespace DemoProject.Popups.Pages.Mct;

public partial class MctParamPopup : BasePopup
{
	public MctParamPopup(ParamPopupViewModel viewModel)
    {
        InitializeComponent();

        BindingContext = viewModel;
    }
}