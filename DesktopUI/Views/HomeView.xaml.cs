using MvvmCross.Platforms.Wpf.Views;
using MvxCore.ViewModels;

namespace DesktopUI.Views;

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
public partial class HomeView : MvxWpfView<HomeViewModel>
{
    public HomeView()
    {
        InitializeComponent();
    }
}
