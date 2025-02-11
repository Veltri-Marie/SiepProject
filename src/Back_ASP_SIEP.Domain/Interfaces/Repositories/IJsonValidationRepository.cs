namespace Interfaces.Repositories
{
    public interface IJsonValidationRepository
    {
        Task<string> VerifyResultAsync(string result);
    }
}