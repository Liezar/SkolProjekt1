using Inlämmningsuppgift;

namespace PlainStorage
{
    public class PlainStorage
    {
        private readonly string filePath;

        public PlainStorage(string fileName)
        {
            filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }
        }

        public List<Shirt> Load()
        {
            var rows = File.ReadAllLines(filePath);
            var Shirts = new List<Shirt>();
            var shirtStorage = new List<Shirt>();

            if (File.ReadAllText(filePath) != "")
            {
                foreach (var row in rows)
                {
                    var shirt = new Shirt();
                    var dataSplitter = row.Split("#");

                    shirt.Motive = dataSplitter[0];
                    shirt.Material = dataSplitter[1];
                    shirt.Size = dataSplitter[2];
                    shirt.Price = dataSplitter[3];
                    shirt.Rating = dataSplitter[4];

                    Shirts.Add(shirt);
                }

                shirtStorage.AddRange(Shirts);
            }
            return Shirts;
        }

        public void Save(List<Shirt> obj)
        {
            foreach (var shirt in obj)
            {
                shirt.Motive += "#";
                shirt.Material += "#";
                shirt.Size += "#";
                shirt.Price += "#";
                shirt.Rating += "#";

                string text = shirt.Motive + shirt.Material + shirt.Size + shirt.Price + shirt.Rating;

                if (File.ReadAllText(filePath) != "")
                {
                    File.AppendAllText(filePath, "\n" + text);
                }
                else
                {
                    File.AppendAllText(filePath, text);
                }
            }
            obj.Clear();
        }
    }
}
