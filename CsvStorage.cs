using SkolProjekt1;
using System.Text;

namespace CSV
{
    public class CsvStorage<T> where T : class, new()
    {
        private readonly string _filePath;
        public CsvStorage(string fileName)
        {
            var file = new CreateFile();
            _filePath = file.Create(fileName);
        }

        public void Save(List<T> obj)
        {
            var sb = new StringBuilder();
            var properties = obj[0].GetType().GetProperties();

            sb.Append(File.ReadAllText(_filePath));
            int count = 1;

            foreach (var o in obj)
            {
                var row = "";
                foreach (var property in properties)
                {
                    row += property.GetValue(o) + "#";
                }

                row = row.TrimEnd('#') + Environment.NewLine;

                sb.Append(row);

                Console.SetCursorPosition(0, 2);
                Console.CursorVisible = false;
                Console.WriteLine($"Created {count++}/{obj.Count} products");
            }

            obj.Clear();

            Console.CursorVisible = true;
            Console.WriteLine();
            File.WriteAllText(_filePath, sb.ToString());
        }

        public List<T> Load()
        {
            var products = new List<T>();
            var rows = File.ReadAllLines(_filePath);
            var p = new T();
            var properties = p.GetType().GetProperties();

            foreach (var row in rows)
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
