using GenderNeutralizer.App.Models;
using Microsoft.AspNetCore.Mvc;

namespace GenderNeutralizer.App.Services
{
    public class LocalDriveService : ILocalDriveService
    {
        public async Task<bool> UploadCV(FileCV file)
        {
            if (file == null || file.Content.Length == 0)
                return false;

            var directoryPath = @"C:\VirtualServer\GenderNeutralizer";

            // Ensure the directory exists
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Combine directory path and file name
            string fullPath = Path.Combine(directoryPath, file.FileName);

            // Write the file to disk
            File.WriteAllBytes(fullPath, file.Content);
            return true;
        }
    }
}
