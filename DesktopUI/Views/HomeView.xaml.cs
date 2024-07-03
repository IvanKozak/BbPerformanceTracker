using DesktopUI.Presentation;

namespace DesktopUI.Views;

/// <summary>
/// Interaction logic for HomeView.xaml
/// </summary>
[NestedPresentation(typeof(ProfileView))]
public partial class HomeView
{
    public HomeView()
    {
        InitializeComponent();
    }
}
