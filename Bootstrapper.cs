using Prism.DryIoc;
using Prism.Ioc;
using System.Windows;
using CRUDMaster.Interfaces;
using CRUDMaster.Services;
using CRUDMaster.ViewModels;
using CRUDMaster.Views;

namespace CRUDMaster
{
    public class Bootstrapper : PrismBootstrapper
    {
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterScoped<IProfileService, ProfileService>();
            containerRegistry.RegisterForNavigation<ProfileMenuView, ProfileMenuViewModel>();
            containerRegistry.RegisterForNavigation<ProfileView, ProfileViewModel>();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
    }
}
