using System.IO;
using CRUDMaster.Entities;
using CRUDMaster.Interfaces;
using Microsoft.WindowsAPICodePack.Dialogs;
using Prism.Commands;
using Prism.Mvvm;

namespace CRUDMaster.ViewModels;

public class ProfileViewModel : BindableBase
{
    private readonly IProfileService _profileService;
    private DelegateCommand<string> _openFolderDialogCommand;
    private DelegateCommand _saveProfileCommand;
    private string _controllerPath;
    private string _entityPath;
    private string _extensionPath;
    private string _interfacePath;
    private string _lastPath = "C:\\Users";
    private string _profileName;
    private string _profilePath;
    private string _projectApiPath;
    private string _projectDomainPath;
    private string _projectInfrastructurePath;
    private string _repositoryPath;
    private string _requestPath;
    private string _responsePath;
    private string _schemaPath;
    private string _servicePath;
    private string _solutionPath;

    public ProfileViewModel(IProfileService profileService)
    {
        _profileService = profileService;
    }

    public DelegateCommand SaveProfileCommand =>
        _saveProfileCommand ?? new DelegateCommand(ExecuteSaveProfileCommand);

    private void ExecuteSaveProfileCommand()
    {
        var profile = new Profile()
        {
            Name = ProfileName,
            ProjectApiPath = ProjectApiPath,
            ProjectDomainPath = ProjectDomainPath,
            RepositoryPath = RepositoryPath,
            ProjectInfrastructurePath = ProjectInfrastructurePath,
            ControllerPath = ControllerPath,
            EntityPath = EntityPath,
            ExtensionPath = ExtensionPath,
            InterfacePath = InterfacePath,
            ProfilePath = ProfilePath,
            ServicePath = ServicePath,
            SolutionPath = SolutionPath,
            RequestPath = RequestPath,
            ResponsePath = ResponsePath,
            SchemaPath = SchemaPath
        };

        _profileService.SaveProfile(profile);
    }

    public DelegateCommand<string> OpenFolderDialogCommand =>
        _openFolderDialogCommand ?? new DelegateCommand<string>(ExecuteOpenFolderDialogCommand);

    public string ControllerPath
    {
        get => _controllerPath;
        set
        {
            SetProperty(ref _controllerPath, value);
            RaisePropertyChanged();
        }
    }

    public string EntityPath
    {
        get => _entityPath;
        set
        {
            SetProperty(ref _entityPath, value);
            RaisePropertyChanged();
        }
    }

    public string ExtensionPath
    {
        get => _extensionPath;
        set
        {
            SetProperty(ref _extensionPath, value);
            RaisePropertyChanged();
        }
    }

    public string InterfacePath
    {
        get => _interfacePath;
        set
        {
            SetProperty(ref _interfacePath, value);
            RaisePropertyChanged();
        }
    }

    public string ProfileName
    {
        get => _profileName;
        set
        {
            SetProperty(ref _profileName, value);
            RaisePropertyChanged();
        }
    }

    public string ProfilePath
    {
        get => _profilePath;
        set
        {
            SetProperty(ref _profilePath, value);
            RaisePropertyChanged();
        }
    }

    public string ProjectApiPath
    {
        get => _projectApiPath;
        set
        {
            SetProperty(ref _projectApiPath, value);
            RaisePropertyChanged();
        }
    }

    public string ProjectDomainPath
    {
        get => _projectDomainPath;
        set
        {
            SetProperty(ref _projectDomainPath, value);
            RaisePropertyChanged();
        }
    }

    public string ProjectInfrastructurePath
    {
        get => _projectInfrastructurePath;
        set
        {
            SetProperty(ref _projectInfrastructurePath, value);
            RaisePropertyChanged();
        }
    }

    public string RepositoryPath
    {
        get => _repositoryPath;
        set
        {
            SetProperty(ref _repositoryPath, value);
            RaisePropertyChanged();
        }
    }

    public string RequestPath
    {
        get => _requestPath;
        set
        {
            SetProperty(ref _requestPath, value);
            RaisePropertyChanged();
        }
    }

    public string ResponsePath
    {
        get => _responsePath;
        set
        {
            SetProperty(ref _responsePath, value);
            RaisePropertyChanged();
        }
    }

    public string SchemaPath
    {
        get => _schemaPath;
        set
        {
            SetProperty(ref _schemaPath, value);
            RaisePropertyChanged();
        }
    }

    public string ServicePath
    {
        get => _servicePath;
        set
        {
            SetProperty(ref _servicePath, value);
            RaisePropertyChanged();
        }
    }

    public string SolutionPath
    {
        get => _solutionPath;
        set
        {
            SetProperty(ref _solutionPath, value);
            RaisePropertyChanged();
        }
    }

    private void ExecuteOpenFolderDialogCommand(string context)
    {
        var dialog = new CommonOpenFileDialog();

        dialog.InitialDirectory = _lastPath;
        dialog.IsFolderPicker = true;

        if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
        {
            _lastPath = dialog.FileName;

            switch (context)
            {
                case "Solution":
                    SolutionPath = dialog.FileName;
                    LocatePaths();
                    break;
                case "API":
                    ProjectApiPath = dialog.FileName;
                    break;
                case "Infrastructure":
                    ProjectInfrastructurePath = dialog.FileName;
                    break;
                case "Domain":
                    ProjectDomainPath = dialog.FileName;
                    break;
                case "Service":
                    ServicePath = dialog.FileName;
                    break;
                case "Interface":
                    InterfacePath = dialog.FileName;
                    break;
                case "Profile":
                    ProfilePath = dialog.FileName;
                    break;
                case "Schema":
                    SchemaPath = dialog.FileName;
                    break;
                case "Request":
                    RequestPath = dialog.FileName;
                    break;
                case "Response":
                    ResponsePath = dialog.FileName;
                    break;
                case "Repository":
                    RepositoryPath = dialog.FileName;
                    break;
                case "Controller":
                    ControllerPath = dialog.FileName;
                    break;
                case "Extension":
                    ExtensionPath = dialog.FileName;
                    break;
                case "Entity":
                    EntityPath = dialog.FileName;
                    break;
            }
        }
    }

    private string GetProjectName()
    {
        var pathSplit = SolutionPath.Split('\\');

        return pathSplit[^1];
    }

    private void LocatePaths()
    {
        var projectName = GetProjectName();
        var projectApiPath = Path.Combine(SolutionPath, projectName + ".API");
        var projectDomainPath = Path.Combine(SolutionPath, projectName + ".Domain");
        var projectInfrastructurePath = Path.Combine(SolutionPath, projectName + ".Infrastructure");
        var controllerPath = Path.Combine(projectApiPath, "Controllers");
        var extensionPath = Path.Combine(projectApiPath, "Extensions");
        var profilePath = Path.Combine(projectDomainPath, "Profiles");
        var interfacePath = Path.Combine(projectDomainPath, "Interfaces");
        var servicePath = Path.Combine(projectDomainPath, "Services");
        var requestPath = Path.Combine(projectDomainPath, "Requests");
        var responsePath = Path.Combine(projectDomainPath, "Responses");
        var entityPath = Path.Combine(projectDomainPath, "Entities");
        var schemaPath = Path.Combine(projectInfrastructurePath, "SchemaDefinitions");
        var repositoryPath = Path.Combine(projectInfrastructurePath, "Repositories");

        if (Directory.Exists(projectApiPath))
        {
            ProjectApiPath = projectApiPath;
        }

        if (Directory.Exists(projectDomainPath))
        {
            ProjectDomainPath = projectDomainPath;
        }

        if (Directory.Exists(projectInfrastructurePath))
        {
            ProjectInfrastructurePath = projectInfrastructurePath;
        }

        if (Directory.Exists(controllerPath))
        {
            ControllerPath = controllerPath;
        }

        if (Directory.Exists(extensionPath))
        {
            ExtensionPath = extensionPath;
        }

        if (Directory.Exists(profilePath))
        {
            ProfilePath = profilePath;
        }

        if (Directory.Exists(interfacePath))
        {
            InterfacePath = interfacePath;
        }

        if (Directory.Exists(servicePath))
        {
            ServicePath = servicePath;
        }

        if (Directory.Exists(requestPath))
        {
            RequestPath = requestPath;
        }

        if (Directory.Exists(responsePath))
        {
            ResponsePath = responsePath;
        }

        if (Directory.Exists(entityPath))
        {
            EntityPath = entityPath;
        }

        if (Directory.Exists(schemaPath))
        {
            SchemaPath = schemaPath;
        }

        if (Directory.Exists(repositoryPath))
        {
            RepositoryPath = repositoryPath;
        }
    }
}