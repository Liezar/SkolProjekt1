namespace SkolProjekt1
{
    public class RandomGenerator
    {
        private static readonly Random _random = new();

        private static readonly string[]? _motifs;
        private static readonly string[]? _materials;
        private static readonly string[]? _sizes;
        private static readonly string[]? _prices;
        private static readonly string[]? _types;

        public static string SetProductInfo(string[] infoType, string fileName)
        {
            var file = new CreateFile();
            if (infoType == null)
            {
                infoType = File.ReadAllLines(file.Create(fileName));
            }
            if (infoType.Length == 0)
            {
                return "N/A";
            }
            return infoType[_random.Next(infoType.Length)];
        }

        private static string Generate(string fileName)
        {
            return fileName switch
            {
                "/ProductData/Motif.txt" => SetProductInfo(_motifs, fileName),
                "/ProductData/Material.txt" => SetProductInfo(_materials, fileName),
                "/ProductData/Sizes.txt" => SetProductInfo(_sizes, fileName),
                "/ProductData/Prices.txt" => SetProductInfo(_prices, fileName),
                "/ProductData/MugTypes.txt" => SetProductInfo(_types, fileName),
                _ => "N/A",
            };
        }

        public static string Motive()
        {
            return Generate("/ProductData/Motif.txt");
        }

        public static string Material()
        {
            return Generate("/ProductData/Material.txt");
        }

        public static string Size()
        {
            return Generate("/ProductData/Sizes.txt");
        }

        public static string Price()
        {
            return Generate("/ProductData/Prices.txt");
        }

        public static string MugType()
        {
            return Generate("/ProductData/MugTypes.txt");
        }

        public static string Rating()
        {
            decimal rating = (decimal)_random.Next(0, 100) / 10;
            return rating.ToString();
        }
    }
}