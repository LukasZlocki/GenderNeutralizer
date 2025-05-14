using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public interface ILocalDriveService
    {
        public Task<bool> UploadCV(FileCV file);
    }
}
