using Inlämmningsuppgift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolProjekt1
{
    public class RandomGenerator
    {
        private string FileGenerator(string fileName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }
            
        public string Splitter(string fileName)
        {
            var items = File.ReadAllLines(FileGenerator(fileName));
            string[] splitter;
            Random random = new Random();
            splitter = new string[items.Length];

            foreach (var item in items)
            {
                splitter = item.Split("#");
            }

            return splitter[random.Next(splitter.Length)].ToString();
        }

        public string Motive()
        {
            return Splitter("Motiv.txt");
        }

        public string Material()
        {
            return Splitter("Material.txt");
        }

        public string Size()
        {
            return Splitter("Storlekar.txt");
        }

        public string Price()
        {
            return Splitter("Priser.txt");
        }

        public string MugType()
        {
            return Splitter("MuggTyper.txt");
        }

        public static string Rating()
        {
            Random random = new Random();

            double d = random.NextDouble();
            decimal d1 = Convert.ToDecimal(d * random.Next(1, 10));
            d1 = Math.Round(d1, 1);
            return d1.ToString();
        }
    }
}
