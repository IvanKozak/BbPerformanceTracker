using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MvxCore.ViewModels;

namespace MvxCore;
public class App : MvxApplication
{
    public override void Initialize()
    {
        base.Initialize();

        CreatableTypes()
            .EndingWith("Service")
            .AsInterfaces()
            .RegisterAsLazySingleton();

        RegisterAppStart<GreetViewModel>();
    }
}
