using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolProjekt1
{
    public class FilePath
    {
        private string? filePath;

        public void CreateFile(string fileName)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
    }
}
