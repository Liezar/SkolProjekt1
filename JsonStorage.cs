using System.Text.Json;

namespace SkolProjekt1
{
    public class JsonStorage<T> where T : class
    {
        private readonly string _filePath;

        public JsonStorage(string fileName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            _filePath = filePath;
        }

        public void Save(List<T> obj)
        {
            dynamic json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            File.WriteAllText(_filePath, json);
        }

        public List<T> Load()
        {
            var dataFile = File.ReadAllText(_filePath);

            if (dataFile == "")
            {
                return new List<T>();
            }
            
            return JsonSerializer.Deserialize<List<T>>(dataFile) ?? new List<T>();
        }
    }
}
