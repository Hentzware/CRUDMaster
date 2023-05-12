using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xaml;
using System.Xml;
using CRUDMaster.Entities;
using CRUDMaster.Interfaces;

namespace CRUDMaster.Services
{
    public class ProfileService : IProfileService
    {
        public void SaveProfile(Profile profile)
        {
            var profilesPath = Path.Combine(Directory.GetCurrentDirectory(), "Profiles");
            var filePath = Path.Combine(profilesPath, profile.Name);
            var xmlWriter = new XmlTextWriter(filePath, null);

            xmlWriter.WriteStartDocument();

            xmlWriter.WriteStartElement("Name");
            xmlWriter.WriteString(profile.Name);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SolutionPath");
            xmlWriter.WriteString(profile.SolutionPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ProjectApiPath");
            xmlWriter.WriteString(profile.ProjectApiPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ProjectDomainPath");
            xmlWriter.WriteString(profile.ProjectDomainPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ProjectInfrastructurePath");
            xmlWriter.WriteString(profile.ProjectInfrastructurePath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ControllerPath");
            xmlWriter.WriteString(profile.ControllerPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ExtensionPath");
            xmlWriter.WriteString(profile.ExtensionPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("InterfacePath");
            xmlWriter.WriteString(profile.InterfacePath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ProfilePath");
            xmlWriter.WriteString(profile.ProfilePath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("RequestPath");
            xmlWriter.WriteString(profile.RequestPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("ResponsePath");
            xmlWriter.WriteString(profile.ResponsePath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("SchemaPath");
            xmlWriter.WriteString(profile.SchemaPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("RepositoryPath");
            xmlWriter.WriteString(profile.RepositoryPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteStartElement("EntityPath");
            xmlWriter.WriteString(profile.EntityPath);
            xmlWriter.WriteEndElement();

            xmlWriter.WriteEndDocument();
            xmlWriter.Close();
        }

        public Profile LoadProfile()
        {
            return new Profile();
        }
    }
}
