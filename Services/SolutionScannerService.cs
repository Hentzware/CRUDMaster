using System.Collections.Generic;
using System.IO;
using System.Linq;
using CRUDMaster.Entities;
using CRUDMaster.Interfaces;

namespace CRUDMaster.Services;


public class SolutionScannerService : ISolutionScannerService
{
    public Profile ScanSolution(Profile profile)
    {
        profile.SolutionName = profile.SolutionPath.Split("\\")[^1];
        profile.DomainPath = Path.Combine(profile.SolutionPath, profile.SolutionName + ".Domain");
        profile.APIPath = Path.Combine(profile.SolutionPath, profile.SolutionName + ".API");
        profile.InfrastructurePath = Path.Combine(profile.SolutionPath, profile.SolutionName + ".Infrastructure");
        profile.ControllersPath = Path.Combine(profile.APIPath, "Controllers");
        profile.ExtensionsPath = Path.Combine(profile.APIPath, "Extensions");
        profile.ServicesPath = Path.Combine(profile.DomainPath, "Services");
        profile.InterfacesPath = Path.Combine(profile.DomainPath, "Interfaces");
        profile.ProfilesPath = Path.Combine(profile.DomainPath, "Profiles");
        profile.EntitiesPath = Path.Combine(profile.DomainPath, "Entities");
        profile.BaseEntityFilePath = Path.Combine(profile.DomainPath, "Entities", "BaseEntity.cs");
        profile.RequestsPath = Path.Combine(profile.DomainPath, "Requests");
        profile.ResponsesPath = Path.Combine(profile.DomainPath, "Responses");
        profile.RepositoriesPath = Path.Combine(profile.InfrastructurePath, "Repositories");
        profile.SchemaDefinitionsPath = Path.Combine(profile.InfrastructurePath, "SchemaDefinitions");

        return profile;
    }

    public IEnumerable<string> ScanEndpoints(Profile profile)
    {
        var endpoints = new List<string>();

        foreach (var file in Directory.EnumerateFiles(profile.EntitiesPath))
        {
            var endpoint = file.Split("\\")[^1];

            endpoint = endpoint.Substring(0, endpoint.Length - 3);

            if (endpoint == "BaseEntity")
            {
                continue;
            }

            endpoints.Add(endpoint);
        }

        return endpoints;
    }
}