using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Text.Json;
using Newtonsoft.Json.Schema;
using System.Xml;
using Inlämmningsuppgift;

namespace SkolProjekt1
{
    public class JsonStorage
    {
        public string FilePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/ShirtJson.json");

        public void Save(List<Shirt> obj)
        {
            dynamic json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            File.AppendAllText(FilePath, json);
        }

        public List<Shirt> Load()
        {
            var shirtDataFile = File.ReadAllText(FilePath);

            return JsonSerializer.Deserialize<List<Shirt>>(shirtDataFile);
        }
    }
}
