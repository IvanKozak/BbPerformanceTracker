using MvvmCross.Platforms.Wpf.Views;
using MvxCore.ViewModels;

namespace DesktopUI.Views;
/// <summary>
/// Interaction logic for ProfileView.xaml
/// </summary>
public partial class ProfileView : MvxWindow<ProfileViewModel>
{
    public ProfileView()
    {
        InitializeComponent();
    }
}
