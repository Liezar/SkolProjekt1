using System.Text.Json;

namespace SkolProjekt1
{
    public class JsonStorage<T> where T : class
    {
        private readonly string _filePath;

        public JsonStorage(string fileName)
        {
            _filePath = File.ReadAllText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName));
        }

        public void Save(List<T> obj)
        {
            dynamic json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            File.AppendAllText(_filePath, json);
        }

        public List<T> Load()
        {
            if (!File.Exists(_filePath))
            {
                File.Create(_filePath);
            }
         
            var dataFile = File.ReadAllText(_filePath);
            
            return JsonSerializer.Deserialize<List<T>>(dataFile) ?? new List<T>();
        }
    }
}
