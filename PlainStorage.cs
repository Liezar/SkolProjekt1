using Inlämmningsuppgift;
using SkolProjekt1;

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
            var rows = "";

            foreach (var row in File.ReadAllLines(filePath))
            {
                rows += row + Environment.NewLine;
            }

            if(rows == "")
            {
                var headers = "";

                foreach (var property in obj[0].GetType().GetProperties())
                {
                    headers += property.Name + "#";
                }

                headers = headers.TrimEnd('#');

                rows = headers + Environment.NewLine;
            }

            foreach (var o in obj)
            {
                foreach(var property in o.GetType().GetProperties())
                {
                    rows += property.GetValue(o) + "#";
                }

                rows = rows.TrimEnd('#');
                rows += Environment.NewLine;
            }

            File.WriteAllText(filePath, rows);
        }

        public List<T> Load()
        {
            var products = new List<T>();
            var rows = File.ReadAllLines(filePath);
            var p = new T();
            var properties = p.GetType().GetProperties();
            var rowIndex = 0;

            foreach(var row in rows)
            {
                if (rowIndex++ == 0) continue;

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
