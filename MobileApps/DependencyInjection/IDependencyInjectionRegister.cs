using Microsoft.Practices.Unity;

namespace MobileApps.DependencyInjection
{
    public interface IDependencyInjectionRegister
    {
       IUnityContainer GetCurrentContainer();
    }
}