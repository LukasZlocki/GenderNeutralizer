using GenderNeutralizer.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenderNeutralizer.App.Services
{

    public class LocalDriveService : ILocalDriveService
    {
        /// <summary>
        /// Uploads a CV file to the local drive.
        /// </summary>
        /// <param name="file"></param>
        /// <returns>string with full path to file stored on local disc</returns>
        public string UploadCV(FileCV file)
        {
            string fullPathToUploadedFile = "";
            if (file == null || file.Content.Length == 0)
                return fullPathToUploadedFile;

            var directoryPath = @"C:\VirtualServer\GenderNeutralizer";

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Combine directory path and file name
            fullPathToUploadedFile = Path.Combine(directoryPath, file.FileName);

            // Write the file to disk
            File.WriteAllBytes(fullPathToUploadedFile, file.Content);

            return fullPathToUploadedFile;
        }

    }
}
