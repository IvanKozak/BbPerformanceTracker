using System.Windows;
using System.Windows.Controls;
using DesktopUI.Views;
using Microsoft.Extensions.Logging;
using MvvmCross.Logging;
using MvvmCross.Platforms.Wpf.Presenters;
using MvvmCross.Platforms.Wpf.Views;
using MvvmCross.Presenters;
using MvvmCross.Presenters.Attributes;
using MvvmCross.ViewModels;

namespace DesktopUI.Presentation;
public class CustomWpfViewPresenter : MvxWpfViewPresenter
{
    public CustomWpfViewPresenter(ContentControl root) : base(root)
    {

    }
    public override void RegisterAttributeTypes()
    {
        base.RegisterAttributeTypes();

        AttributeTypesToActionsDictionary.Register<RegionPresentationAttribute>(
                (_, attribute, request) =>
                {
                    var view = WpfViewLoader.CreateView(request);
                    return ShowRegionView(view, attribute, request);
                },
                (viewModel, _) => CloseRegionView(viewModel));
    }

    protected virtual Task<bool> ShowRegionView(FrameworkElement element, RegionPresentationAttribute attribute, MvxViewModelRequest request)
    {
        var contentControl = FrameworkElementsDictionary.Keys.Last();
        var parentView = (ContentControl)FrameworkElementsDictionary[contentControl].FirstOrDefault(v => v.GetType() == typeof(ProfileView));

        FrameworkElementsDictionary[contentControl].Push(element);
        parentView.Content = element;
        return Task.FromResult(true);
    }

    protected virtual Task<bool> CloseRegionView(IMvxViewModel toClose)
    {
        var item = FrameworkElementsDictionary.FirstOrDefault(i => i.Value.Any() && (i.Value.Peek() as IMvxWpfView)?.ViewModel == toClose);
        var contentControl = item.Key;
        var elements = item.Value;
        var parentView = (ContentControl)elements.FirstOrDefault(v => v.GetType() == typeof(ProfileView));

        if (elements.Any())
            elements.Pop(); // Pop closing view

        var previousElement = elements.Peek();
        if (Attribute.IsDefined(previousElement.GetType(), typeof(RegionPresentationAttribute)))
        {
            parentView.Content = previousElement;
        }
        else
        {
            var v = ((IMvxWpfView)previousElement).ViewModel;

            CloseContentView(v);
        }

        return Task.FromResult(true);

    }

    public override async Task<bool> Close(IMvxViewModel viewModel)
    {
        // toClose is window
        if (FrameworkElementsDictionary.Any(i => (i.Key as IMvxWpfView)?.ViewModel == viewModel) && await CloseWindow(viewModel))
            return true;

        // toClose is content
        var elements = FrameworkElementsDictionary.Values.FirstOrDefault(i => i.Any() && (i.Peek() as IMvxWpfView)?.ViewModel == viewModel);
        if (elements is not null)
        {
            var element = elements.Peek();
            if (Attribute.IsDefined(element.GetType(), typeof(RegionPresentationAttribute)))
            {
                await CloseRegionView(viewModel);
            }
            else
            {
                await CloseContentView(viewModel);
            }

            return true;
        }


        MvxLogHost.Default?.Log(LogLevel.Warning, "Could not close ViewModel type {ViewModelTypeName}", viewModel.GetType().Name);
        return false;
    }
}

public class RegionPresentationAttribute : MvxBasePresentationAttribute
{
}
