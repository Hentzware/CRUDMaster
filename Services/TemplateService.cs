using System;
using System.IO;
using System.Windows;
using CRUDMaster.Entities;
using CRUDMaster.Interfaces;

namespace CRUDMaster.Services;

public class TemplateService : ITemplateService
{
    private Profile _profile;

    public void CreateEndpoint(Profile profile)
    {
        _profile = profile;

        CreateService();
        CreateServíceInterface();
        CreateRepository();
        CreateRepositoryInterface();
        CreateProfile();
        CreateGetRequest();
        CreateAddRequest();
        CreateEditRequest();
        CreateDeleteRequest();
        CreateResponse();
        CreateSchemaDefinition();
        CreateController();
        CreateEntity();
        MessageBox.Show("Ok");
    }

    public void DeleteEndpoint(Profile profile)
    {
        _profile = profile;
    }

    private void CreateService()
    {
        var serviceFilePath = Path.Combine(_profile.ServicesPath, $"{_profile.EntityName}Service.cs");
        var serviceTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ServiceTemplate.txt");

        if (!Directory.Exists(_profile.ServicesPath))
        {
            Directory.CreateDirectory(_profile.ServicesPath);
        }

        if (File.Exists(serviceFilePath))
        {
            File.Delete(serviceFilePath);
        }

        var text = File.ReadAllText(serviceTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(serviceFilePath, text);
    }

    private void CreateServíceInterface()
    {
        var serviceInterfaceFilePath = Path.Combine(_profile.InterfacesPath, _profile.EntityName, $"I{_profile.EntityName}Service.cs");
        var serviceInterfaceTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ServiceInterfaceTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.InterfacesPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.InterfacesPath, _profile.EntityName));
        }

        if (File.Exists(serviceInterfaceFilePath))
        {
            File.Delete(serviceInterfaceFilePath);
        }

        var text = File.ReadAllText(serviceInterfaceTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(serviceInterfaceFilePath, text);
    }

    private void CreateRepository()
    {
        var repositoryFilePath = Path.Combine(_profile.RepositoriesPath, $"{_profile.EntityName}Repository.cs");
        var repositoryTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RepositoryTemplate.txt");

        if (!Directory.Exists(_profile.RepositoriesPath))
        {
            Directory.CreateDirectory(_profile.RepositoriesPath);
        }

        if (File.Exists(repositoryFilePath))
        {
            File.Delete(repositoryFilePath);
        }

        var text = File.ReadAllText(repositoryTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(repositoryFilePath, text);
    }

    private void CreateRepositoryInterface()
    {
        var repositoryInterfaceFilePath = Path.Combine(_profile.InterfacesPath, _profile.EntityName, $"I{_profile.EntityName}Repository.cs");
        var repositoryInterfaceTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "RepositoryInterfaceTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.InterfacesPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.InterfacesPath, _profile.EntityName));
        }

        if (File.Exists(repositoryInterfaceFilePath))
        {
            File.Delete(repositoryInterfaceFilePath);
        }

        var text = File.ReadAllText(repositoryInterfaceTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(repositoryInterfaceFilePath, text);
    }

    private void CreateProfile()
    {
        var profileFilePath = Path.Combine(_profile.ProfilesPath, $"{_profile.EntityName}Profile.cs");
        var profileTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ProfileTemplate.txt");

        if (!Directory.Exists(_profile.ProfilesPath))
        {
            Directory.CreateDirectory(_profile.ProfilesPath);
        }

        if (File.Exists(profileFilePath))
        {
            File.Delete(profileFilePath);
        }

        var text = File.ReadAllText(profileTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(profileFilePath, text);
    }

    private void CreateGetRequest()
    {
        var getRequestFilePath = Path.Combine(_profile.RequestsPath, _profile.EntityName, $"Get{_profile.EntityName}Request.cs");
        var getRequestTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "GetRequestTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.RequestsPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.RequestsPath, _profile.EntityName));
        }

        if (File.Exists(getRequestFilePath))
        {
            File.Delete(getRequestFilePath);
        }

        var text = File.ReadAllText(getRequestTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(getRequestFilePath, text);
    }

    private void CreateAddRequest()
    {
        var addRequestFilePath = Path.Combine(_profile.RequestsPath, _profile.EntityName, $"Add{_profile.EntityName}Request.cs");
        var addRequestTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "AddRequestTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.RequestsPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.RequestsPath, _profile.EntityName));
        }

        if (File.Exists(addRequestFilePath))
        {
            File.Delete(addRequestFilePath);
        }

        var text = File.ReadAllText(addRequestTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(addRequestFilePath, text);
    }

    private void CreateEditRequest()
    {
        var editRequestFilePath = Path.Combine(_profile.RequestsPath, _profile.EntityName, $"Edit{_profile.EntityName}Request.cs");
        var editRequestTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EditRequestTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.RequestsPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.RequestsPath, _profile.EntityName));
        }

        if (File.Exists(editRequestFilePath))
        {
            File.Delete(editRequestFilePath);
        }

        var text = File.ReadAllText(editRequestTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(editRequestFilePath, text);
    }

    private void CreateDeleteRequest()
    {
        var deleteRequestFilePath = Path.Combine(_profile.RequestsPath, _profile.EntityName, $"Delete{_profile.EntityName}Request.cs");
        var deleteRequestTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "DeleteRequestTemplate.txt");

        if (!Directory.Exists(Path.Combine(_profile.RequestsPath, _profile.EntityName)))
        {
            Directory.CreateDirectory(Path.Combine(_profile.RequestsPath, _profile.EntityName));
        }

        if (File.Exists(deleteRequestFilePath))
        {
            File.Delete(deleteRequestFilePath);
        }

        var text = File.ReadAllText(deleteRequestTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(deleteRequestFilePath, text);
    }

    private void CreateResponse()
    {
        var responseFilePath = Path.Combine(_profile.ResponsesPath, $"{_profile.EntityName}Response.cs");
        var responseTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ResponseTemplate.txt");

        if (!Directory.Exists(_profile.ResponsesPath))
        {
            Directory.CreateDirectory(_profile.ResponsesPath);
        }

        if (File.Exists(responseFilePath))
        {
            File.Delete(responseFilePath);
        }

        var text = File.ReadAllText(responseTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(responseFilePath, text);
    }

    private void CreateSchemaDefinition()
    {
        var schemaDefinitionFilePath = Path.Combine(_profile.SchemaDefinitionsPath, $"{_profile.EntityName}SchemaDefinition.cs");
        var schemaDefinitionTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "SchemeTemplate.txt");

        if (!Directory.Exists(_profile.SchemaDefinitionsPath))
        {
            Directory.CreateDirectory(_profile.SchemaDefinitionsPath);
        }

        if (File.Exists(schemaDefinitionFilePath))
        {
            File.Delete(schemaDefinitionFilePath);
        }

        var text = File.ReadAllText(schemaDefinitionTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(schemaDefinitionFilePath, text);
    }

    private void CreateController()
    {
        var controllerFilePath = Path.Combine(_profile.ControllersPath, $"{_profile.EntityName}Controller.cs");
        var controllerTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "ControllerTemplate.txt");

        if (!Directory.Exists(_profile.ControllersPath))
        {
            Directory.CreateDirectory(_profile.ControllersPath);
        }

        if (File.Exists(controllerFilePath))
        {
            File.Delete(controllerFilePath);
        }

        var text = File.ReadAllText(controllerTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(controllerFilePath, text);
    }

    private void CreateEntity()
    {
        var entityFilePath = Path.Combine(_profile.EntitiesPath, $"{_profile.EntityName}.cs");
        var entityTemplateFilePath = Path.Combine(Directory.GetCurrentDirectory(), "Templates", "EntityTemplate.txt");

        if (!Directory.Exists(_profile.EntitiesPath))
        {
            Directory.CreateDirectory(_profile.EntitiesPath);
        }

        if (File.Exists(entityFilePath))
        {
            File.Delete(entityFilePath);
        }

        var text = File.ReadAllText(entityTemplateFilePath);

        text = text.Replace("SOLUTIONNAME", _profile.SolutionName);
        text = text.Replace("UPPERNAME", _profile.EntityName);
        text = text.Replace("LOWERNAME", _profile.EntityNameLower);

        File.WriteAllText(entityFilePath, text);
    }
}