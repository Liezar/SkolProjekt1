using System.Text.Json;

namespace SkolProjekt1
{
    public class JsonStorage<T> where T : class
    {
        private readonly string _filePath;

        public JsonStorage(string fileName)
        {
            var file = new CreateFile();
            _filePath = file.Create(fileName);
        }


        public void Save(List<T> obj)
        {
            int count = 1;
            var objects = Load();
            objects.AddRange(obj);
            string json = JsonSerializer.Serialize(objects, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(_filePath, json);

            for (int i = 0; i < obj.Count; i++)
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

            if (File.Exists(_filePath))
            {
                dataFile = File.ReadAllText(_filePath);
            }

            if (dataFile == "" || !File.Exists(_filePath))
            {
                return new List<T>();
            }

            return JsonSerializer.Deserialize<List<T>>(dataFile) ?? new List<T>();
        }
    }
}
