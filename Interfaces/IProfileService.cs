using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CRUDMaster.Entities;

namespace CRUDMaster.Interfaces
{
    public interface IProfileService
    {
        void SaveProfile(Profile profile);

        Profile LoadProfile();
    }
}
