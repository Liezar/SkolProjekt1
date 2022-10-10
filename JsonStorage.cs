using Inlämmningsuppgift;
using System;
using System.Security.AccessControl;
using System.Text.Json;

namespace SkolProjekt1
{
    public class JsonStorage<T> where T : class
    {
        private readonly string filePath;

        public JsonStorage(string fileName)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }
     
        public void Save(List<T> obj) 
        {
            var objects = Load();
            objects.AddRange(obj);
            string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);
            objects.Clear();
            obj.Clear();
        }

        public List<T> Load()
        {
            string dataFile = "";

            if (File.Exists(filePath))
            {
                dataFile = File.ReadAllText(filePath);
            }

            if (dataFile == "" || !File.Exists(filePath))
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(dataFile) ?? new List<T>();
        }
    }
}
