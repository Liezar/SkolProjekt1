using System.Text.Json;

namespace SkolProjekt1
{
    public class JsonStorage<T> : IStorage<T> where T : class
    {
        private readonly string _filePath;

        public JsonStorage(string fileName)
        {
            if (!File.Exists(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName)))
            {
                File.Create(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName));
            }

            _filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);
        }

        public void Save(List<T> obj)
        {
            string json = JsonSerializer.Serialize(obj, new JsonSerializerOptions { WriteIndented = true });

            File.AppendAllText(_filePath, json);
        }

        public List<T> Load()
        {
            var dataFile = File.ReadAllText(_filePath);

            return JsonSerializer.Deserialize<List<T>>(dataFile) ?? new List<T>();
        }
    }
}
