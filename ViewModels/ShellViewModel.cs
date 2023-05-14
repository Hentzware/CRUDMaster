using Prism.Mvvm;
using Prism.Regions;
using CRUDMaster.Views;

namespace CRUDMaster.ViewModels
{
    public class ShellViewModel : BindableBase
    {
        private readonly IRegionManager _regionManager;

        public ShellViewModel(IRegionManager regionManager)
        {
            _regionManager = regionManager;

            InitializeViews();
        }

        private void InitializeViews()
        {
            _regionManager.RegisterViewWithRegion<StartView>("ContentRegion");
        }
    }
}
