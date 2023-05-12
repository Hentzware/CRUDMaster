using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDMaster.Services
{
    public class FileService
    {
        public void CreateFile(string path, string filename)
        {
            if (!Directory.Exists(path))
            {
                Directory.CreateDirectory(path);
            }

            if (File.Exists(Path.Combine(path, filename)))
            {
                File.Delete(Path.Combine(path, filename));
            }

            File.Create(Path.Combine(path, filename));
        }
    }
}
