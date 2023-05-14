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
            containerRegistry.RegisterScoped<ISolutionScannerService, SolutionScannerService>();
            containerRegistry.RegisterScoped<ITemplateService, TemplateService>();

            containerRegistry.RegisterForNavigation<StartView, StartViewModel>();
            containerRegistry.RegisterForNavigation<MainView, MainViewModel>();
        }

        protected override DependencyObject CreateShell()
        {
            return Container.Resolve<ShellView>();
        }
    }
}
