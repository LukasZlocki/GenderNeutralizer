using GenderNeutralizer.App.Models;

namespace GenderNeutralizer.App.Services
{
    public interface ILocalDriveService
    {
        public string UploadCV(FileCV file);
    }
}
