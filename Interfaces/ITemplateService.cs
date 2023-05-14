using CRUDMaster.Entities;

namespace CRUDMaster.Interfaces;

public interface ITemplateService
{
    void CreateEndpoint(Profile profile);

    void DeleteEndpoint(Profile profile);
}