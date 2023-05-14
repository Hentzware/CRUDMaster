using System.Collections.Generic;
using System.Linq;
using CRUDMaster.Entities;
using CRUDMaster.Events;
using CRUDMaster.Interfaces;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;

namespace CRUDMaster.ViewModels;

public class MainViewModel : BindableBase
{
    private readonly IEventAggregator _eventAggregator;
    private readonly ISolutionScannerService _scanner;
    private readonly ITemplateService _templateService;
    private bool _createEndpointEnabled;
    private bool _deleteEndpointEnabled;
    private DelegateCommand _createEndpointCommand;
    private DelegateCommand _deleteEndpointCommand;
    private List<string> _endpoints;
    private Profile _profile;
    private string _endpointName;
    private string _selectedEndpoint;

    public MainViewModel(IEventAggregator eventAggregator, ISolutionScannerService scanner, ITemplateService templateService)
    {
        _eventAggregator = eventAggregator;
        _scanner = scanner;
        _templateService = templateService;

        _eventAggregator.GetEvent<SolutionSelectedEvent>().Subscribe(OnSolutionSelected);
    }

    public DelegateCommand CreateEndpointCommand =>
        _createEndpointCommand ?? new DelegateCommand(ExecuteCreateEndpointCommand);

    public DelegateCommand DeleteEndpointCommand =>
        _deleteEndpointCommand ?? new DelegateCommand(ExecuteDeleteEndpointCommand);

    public bool CreateEndpointEnabled => !string.IsNullOrEmpty(_endpointName);

    public bool DeleteEndpointEnabled => !string.IsNullOrEmpty(_selectedEndpoint);

    public List<string> Endpoints
    {
        get => _endpoints;
        set
        {
            SetProperty(ref _endpoints, value);
            RaisePropertyChanged();
        }
    }

    public string EndpointName
    {
        get => _endpointName;
        set
        {
            SetProperty(ref _endpointName, value);
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(CreateEndpointEnabled));
        }
    }

    public string SelectedEndpoint
    {
        get => _selectedEndpoint;
        set
        {
            SetProperty(ref _selectedEndpoint, value);
            RaisePropertyChanged();
            RaisePropertyChanged(nameof(DeleteEndpointEnabled));
        }
    }

    private void ExecuteCreateEndpointCommand()
    {
        _profile.EntityName = EndpointName;
        _profile.EntityNameLower = char.ToLower(EndpointName[0]) + EndpointName.Substring(1);
        _templateService.CreateEndpoint(_profile);
    }

    private void ExecuteDeleteEndpointCommand()
    {
        _profile.EntityName = SelectedEndpoint;
        _profile.EntityNameLower = char.ToLower(EndpointName[0]) + EndpointName.Substring(1);
        _templateService.DeleteEndpoint(_profile);
    }

    private void OnSolutionSelected(string solutionPath)
    {
        _profile = new Profile
        {
            SolutionPath = solutionPath
        };

        _profile = _scanner.ScanSolution(_profile);

        Endpoints = _scanner.ScanEndpoints(_profile).ToList();
    }
}