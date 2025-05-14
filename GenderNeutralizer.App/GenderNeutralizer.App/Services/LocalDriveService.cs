using Microsoft.AspNetCore.Mvc;

namespace GenderNeutralizer.App.Services
{
    public class LocalDriveService : ILocalDriveService
    {
        public async Task<bool> UploadCV(IFormFile file)
        {
            if (file == null || file.Length == 0)
                return false;

            var targetDirectory = @"C:\VirtualServer\GenderNeutralizer";

            if (!Directory.Exists(targetDirectory))
                Directory.CreateDirectory(targetDirectory);

            var filePath = Path.Combine(targetDirectory, file.FileName);

            using var stream = new FileStream(filePath, FileMode.Create);
            await file.CopyToAsync(stream);

            return true;
        }
    }
}
