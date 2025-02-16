namespace GenderNeutralizer.Api.Services
{
    public interface ITransformService
    {
        public Task<List<string>> TransformAsync();
    }
}
