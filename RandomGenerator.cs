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
        private static string FileGenerator(string fileName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/ProductData/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }
            
        public static string Splitter(string fileName)
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

        public static string Motive()
        {
            return Splitter("Motiv.txt");
        }

        public static string Material()
        {
            return Splitter("Material.txt");
        }

        public static string Size()
        {
            return Splitter("Storlekar.txt");
        }

        public static string Price()
        {
            return Splitter("Priser.txt");
        }

        public static string MugType()
        {
            return Splitter("MuggTyper.txt");
        }

        public static string Rating()
        {
            var random = new Random();

            double randomDouble = random.NextDouble();
            decimal rating = Convert.ToDecimal(randomDouble * random.Next(1, 10));
            rating = Math.Round(rating, 1);
            return rating.ToString();
        }
    }
}
