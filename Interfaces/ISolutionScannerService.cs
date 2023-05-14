using System.Collections.Generic;
using CRUDMaster.Entities;

namespace CRUDMaster.Interfaces;

public interface ISolutionScannerService
{
    Profile ScanSolution(Profile profile);

    IEnumerable<string> ScanEndpoints(Profile profile);
}