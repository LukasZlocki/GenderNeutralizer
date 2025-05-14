namespace GenderNeutralizer.App.Services
{
    public interface ILocalDriveService
    {
        public Task<bool> UploadCV(IFormFile file);
    }
}
