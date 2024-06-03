using MvvmCross.Platforms.Wpf.Views;
using MvxCore.ViewModels;

namespace DesktopUI.Views;
/// <summary>
/// Interaction logic for GreetView.xaml
/// </summary>
public partial class GreetView : MvxWpfView<GreetViewModel>
{
    public GreetView()
    {
        InitializeComponent();
    }
}
