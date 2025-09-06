namespace PustokApp.Extentions
{
    public static class FileManager
    {
        public static string SaveFile(this IFormFile file,string FolderPath)
        {
            var fileName = Guid.NewGuid().ToString() + Path.GetExtension(file.FileName);
            var path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets", fileName);
            using var stream = new FileStream(path, FileMode.Create);
            file.CopyTo(stream);
            return fileName;
        }
        public static bool CheckFileSize(this IFormFile file,int mb)
        {
            return file.Length < mb * 1024 * 1024;
        }
        public static bool CheckContentType(this IFormFile file,string contentType)
        {
           return file.ContentType.Contains(contentType);
        }
        public static void DeleteFile(string FolderPath, string fileName)
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/assets",FolderPath,fileName);
        }
    }
}
           
          
