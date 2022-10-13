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
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
        }

        int count = 1;

        public void Save(List<T> obj) 
        {
            var objects = Load();
            objects.AddRange(obj);
            string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            foreach (var item in obj)
            {
                Console.SetCursorPosition(0, 2);
                Console.CursorVisible = false;
                Console.WriteLine($"Created {count++}/{obj.Count} products");
            }

            Console.WriteLine();
            objects.Clear();
            obj.Clear();
            Console.CursorVisible = true;
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
