namespace SkolProjekt1
{
    public class CreateFile
    {
        public string Create(string fileName)
        {
            var dirPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EdvinsProject/ProductData";
            var filePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + "/EdvinsProject" + fileName);

            if (!Directory.Exists(dirPath))
            {
                Directory.CreateDirectory(dirPath);
            }
            if (!File.Exists(filePath))
            {
                var fileStream = File.Create(filePath);
                fileStream.Close();
            }
            return filePath;
        }
    }
}
