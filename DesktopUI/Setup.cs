using System.IO;
using System.Net.Http;
using DesktopUI.Services;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.Platforms.Wpf.Core;
using MvxCore.Repositories;
using MvxCore.Services;
using MvxCore.ViewModels;
using Serilog;
using Serilog.Extensions.Logging;

namespace DesktopUI;
public class Setup : MvxWpfSetup<MvxCore.App>
{
    protected override void InitializeFirstChance(IMvxIoCProvider iocProvider)
    {
        var handler = new SocketsHttpHandler
        {
            PooledConnectionLifetime = TimeSpan.FromMinutes(15) // Recreate every 15 minutes
        };
        var sharedClient = new HttpClient(handler);
        Mvx.IoCProvider.RegisterSingleton<HttpClient>(sharedClient);
        Mvx.IoCProvider.RegisterSingleton<IConfiguration>(AddConfiguration());
        Mvx.IoCProvider.RegisterSingleton<IAuthenticationService>(new WPFAuthenticationService(Mvx.IoCProvider.Resolve<IConfiguration>()));

        Mvx.IoCProvider.RegisterType<IUserRepository, UserRepository>();
        Mvx.IoCProvider.RegisterType<IShootingDrillRepository, ShootingDrillRepository>();
        Mvx.IoCProvider.RegisterType<HomeViewModel>();

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

    private IConfiguration AddConfiguration()
    {
        IConfigurationBuilder configurationBuilder = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json");
#if DEBUG
        configurationBuilder.AddJsonFile("appsettings.Development.json", true, true);
#else
            configurationBuilder.AddJsonFile("appsettings.Production.json", optional: true, reloadOnChange: true);
#endif
        return configurationBuilder.Build();
    }
}
