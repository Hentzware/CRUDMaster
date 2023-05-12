using System.Collections.Generic;
using System.IO;
using CRUDMaster.Entities;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;

namespace CRUDMaster.ViewModels;

public class ProfileMenuViewModel : BindableBase
{
    private readonly IRegionManager _regionManager;
    private bool _isProfileSelected;
    private DelegateCommand _deleteProfileCommand;
    private DelegateCommand _editProfileCommand;
    private DelegateCommand _loadProfileCommand;
    private DelegateCommand _newProfileCommand;
    private string _selectedProfile;

    public ProfileMenuViewModel(IRegionManager regionManager)
    {
        _regionManager = regionManager;

        CreateProfilesDirectory();
        LoadProfiles();
    }

    public DelegateCommand DeleteProfileCommand =>
        _deleteProfileCommand ?? new DelegateCommand(ExecuteDeleteProfileCommand);

    public DelegateCommand EditProfileCommand =>
        _editProfileCommand ?? new DelegateCommand(ExecuteEditProfileCommand);

    public DelegateCommand LoadProfileCommand =>
        _loadProfileCommand ?? new DelegateCommand(ExecuteLoadProfileCommand);

    public DelegateCommand NewProfileCommand =>
        _newProfileCommand ?? new DelegateCommand(ExecuteNewProfileCommand);

    public bool IsProfileSelected
    {
        get => _isProfileSelected;
        set
        {
            SetProperty(ref _isProfileSelected, value);
            RaisePropertyChanged();
        }
    }

    public List<Profile> Profiles { get; set; }

    public string SelectedProfile
    {
        get => _selectedProfile;
        set
        {
            SetProperty(ref _selectedProfile, value);
            IsProfileSelected = !string.IsNullOrEmpty(value);
            RaisePropertyChanged();
        }
    }

    private void CreateProfilesDirectory()
    {
        var profilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Profiles");

        if (!Directory.Exists(profilesPath))
        {
            Directory.CreateDirectory(profilesPath);
        }
    }

    private void DeleteProfile()
    {
        var profilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Profiles");
    }

    private void ExecuteDeleteProfileCommand()
    {
    }

    private void ExecuteEditProfileCommand()
    {
    }

    private void ExecuteLoadProfileCommand()
    {
    }

    private void ExecuteNewProfileCommand()
    {
        _regionManager.RequestNavigate("ContentRegion", "ProfileView");
    }

    private void LoadProfiles()
    {
        var profilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Profiles");
        var files = Directory.EnumerateFiles(profilesPath, ".xml");

        Profiles = new List<Profile>();

        for (var i = 0; i < 10; i++)
        {
            var profile = new Profile
            {
                Name = $"Profile {i}"
            };

            Profiles.Add(profile);
        }
    }
}