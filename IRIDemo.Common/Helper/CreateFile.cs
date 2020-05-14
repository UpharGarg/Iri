using System.IO; 
namespace IRIDemo.Common.Helper
{
    public static class Helper
    {
        public static string CreateDirectoryandFile()
        {
            //ToDo : this should be ideally taken as an input from user
            // Done this way to save some time, creating a folder on C Drive to save output 
            string folderName = Constants.Constants.DirectoryPath;
            Directory.CreateDirectory(folderName);
            return Path.Combine(folderName, Constants.Constants.FileName);
        }
    }
}
