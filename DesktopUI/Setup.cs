using DesktopUI.Services;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvxCore.Services;
using Serilog;
using Serilog.Extensions.Logging;

namespace DesktopUI;
public class Setup : MvxWpfSetup<MvxCore.App>
{
    protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
    {
        Mvx.IoCProvider.RegisterSingleton<IAuthenticationService>(new WPFAuthenticationService());

        base.InitializeFirstChance(iocProvider);
    }
    protected override ILoggerFactory? CreateLogFactory()
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Debug()
            .WriteTo.Console()
            .CreateLogger();

        return new SerilogLoggerFactory();
    }

    protected override ILoggerProvider? CreateLogProvider()
    {
        return new SerilogLoggerProvider();
    }
}
