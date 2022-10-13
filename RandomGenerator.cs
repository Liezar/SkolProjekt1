using Inlämmningsuppgift;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace SkolProjekt1
{
    public class RandomGenerator
    {
        private static readonly Random _random = new Random();

        private static string[]? _motives;
        private static string[]? _materials;
        private static string[]? _sizes ;
        private static string[]? _prices;
        private static string[]? _types;

        private static string FileGenerator(string fileName)
        {
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.UserProfile) + "/ProductData/" + fileName);

            if (!File.Exists(filePath))
            {
                File.Create(filePath);
            }

            return filePath;
        }
            
        private static string Splitter(string fileName)
        {
            switch (fileName)
            {
                case "Motiv.txt":
                    if(_motives == null)
                    {
                        _motives = File.ReadAllLines(FileGenerator(fileName));
                    }
                    return _motives[_random.Next(_motives.Length)];
                case "Material.txt":
                    if(_materials == null)
                    {
                        _materials = File.ReadAllLines(FileGenerator(fileName));
                    }
                    return _materials[_random.Next(_materials.Length)];
                case "Storlekar.txt":
                    if(_sizes == null)
                    {
                        _sizes = File.ReadAllLines(FileGenerator(fileName));
                    }
                    return _sizes[_random.Next(_sizes.Length)];
                case "Priser.txt":
                    if(_prices == null)
                    {
                        _prices = File.ReadAllLines(FileGenerator(fileName));
                    }
                    return _prices[_random.Next(_prices.Length)];
                case "MuggTyper.txt":
                    if(_types == null)
                    {
                        _types = File.ReadAllLines(FileGenerator(fileName));
                    }
                    return _types[_random.Next(_types.Length)];
                default:
                    return "N/A";
            }
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
            decimal tal = (decimal)_random.Next(0, 100) / 10;
            return tal.ToString();
        }
    }
}
