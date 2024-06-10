using MvvmCross.Platforms.Wpf.Presenters.Attributes;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;
using MvxCore.ViewModels;

namespace DesktopUI.Views;

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
public partial class HomeView : IMvxOverridePresentationAttribute
{
    public HomeView()
    {
        InitializeComponent();
    }

    public MvxBasePresentationAttribute PresentationAttribute(MvxViewModelRequest request)
    {
        var instanceRequest = request as MvxViewModelInstanceRequest;
        var viewModel = instanceRequest?.ViewModelInstance as HomeViewModel;

        return new MvxContentPresentationAttribute
        {
            WindowIdentifier = nameof(ProfileView),
            StackNavigation = false
        };
    }
}
