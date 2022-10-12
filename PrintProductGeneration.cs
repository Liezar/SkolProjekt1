namespace SkolProjekt1
{
    public class PrintProductGeneration
    {
        int count = 1;
        public string CreatedProducts(int numberOfProducts)
        {
            return $"Created {count++}/{numberOfProducts} products";
        }
    }
}
