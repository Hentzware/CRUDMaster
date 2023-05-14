using CRUDMaster.Events;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Regions;

namespace CRUDMaster.ViewModels;

public class StartViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    private readonly IRegionManager _regionManager;
    private DelegateCommand _openSolutionCommand;

    public StartViewModel(IRegionManager regionManager, IEventAggregator eventAggregator)
    {
        _regionManager = regionManager;
        _eventAggregator = eventAggregator;
    }

    public DelegateCommand OpenSolutionCommand =>
        _openSolutionCommand ?? new DelegateCommand(ExecuteOpenSolutionCommand);

    private void ExecuteOpenSolutionCommand()
    {
        var openFileDialog = new CommonOpenFileDialog();

        openFileDialog.IsFolderPicker = true;
        openFileDialog.InitialDirectory = "D:\\repos\\HenningEntz";

        if (openFileDialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            _regionManager.RequestNavigate("ContentRegion", "MainView");
            _eventAggregator.GetEvent<SolutionSelectedEvent>().Publish(openFileDialog.FileName);
        }
    }
}