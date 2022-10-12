using Inlämmningsuppgift;
using SkolProjekt1;
using System.Text;

namespace PlainStorage
{
    public class PlainStorage<T> where T : class, new()
    {
        private readonly string filePath;
        private PrintProductGeneration PrintProductGeneration = new();
        public PlainStorage(string fileName)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
        }

        public void Save(List<T> obj)
        {
            var sb = new StringBuilder();
            var properties = obj[0].GetType().GetProperties();

            sb.Append(File.ReadAllText(filePath));
            int count = 1;

            foreach (var o in obj)
            {
                var row = "";
                foreach(var property in properties)
                {
                    row += property.GetValue(o) + "#";
                }

                row = row.TrimEnd('#') + Environment.NewLine;

                sb.Append(row);

                Console.SetCursorPosition(0, 2);
                Console.CursorVisible = false;
                Console.WriteLine($"Created {count++}/{obj.Count} products");
            }

            Console.CursorVisible = true;
            Console.WriteLine();
            File.WriteAllText(filePath, sb.ToString());
        }

        public List<T> Load()
        {
            var products = new List<T>();
            var rows = File.ReadAllLines(filePath);
            var p = new T();
            var properties = p.GetType().GetProperties();

            foreach(var row in rows)
            {
                var product = new T();
                var columns = row.Split('#');
                var columnIndex = 0;

                foreach (var property in properties)
                {
                    product.GetType().GetProperty(property.Name).SetValue(product, columns[columnIndex++]);
                }

                products.Add(product);
            }

            return products;
        }
    }
}
