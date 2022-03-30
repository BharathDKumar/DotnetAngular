namespace DotnetAngular.Utilities
{
    public class FileUtility
    {
        public static Stream GetStream(string fileUrl)
        {
            return File.Open(fileUrl, FileMode.Open, FileAccess.Read, FileShare.Read);
        } 
    }
}
