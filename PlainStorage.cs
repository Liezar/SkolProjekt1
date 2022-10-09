using Inlämmningsuppgift;
using SkolProjekt1;

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

        public void SaveShirt(List<Shirt> obj)
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
        public void SaveMug(List<Mug> obj)
        {
            foreach (var Mug in obj)
            {
                Mug.Motive += "#";
                Mug.Type += "#";
                Mug.Price += "#";
                Mug.Rating += "#";

                string text = Mug.Motive + Mug.Type + Mug.Price + Mug.Rating;

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

        public List<Shirt> ShirtLoad()
        {
            var rows = File.ReadAllLines(filePath);
            var shirts = new List<Shirt>();
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

                    shirts.Add(shirt);
                }

                shirtStorage.AddRange(shirts);
            }
            return shirts;
        }

        public List<Mug> MugLoad()
        {
            var rows = File.ReadAllLines(filePath);
            var mugs = new List<Mug>();
            var mugStorage = new List<Mug>();

            if (File.ReadAllText(filePath) != "")
            {
                foreach (var row in rows)
                {
                    var mug = new Mug();
                    var dataSplitter = row.Split("#");

                    mug.Motive = dataSplitter[0];
                    mug.Type = dataSplitter[1];
                    mug.Price = dataSplitter[2];
                    mug.Rating = dataSplitter[3];

                    mugs.Add(mug);
                }

                mugStorage.AddRange(mugs);
            }
            return mugs;
        }
    }
}
