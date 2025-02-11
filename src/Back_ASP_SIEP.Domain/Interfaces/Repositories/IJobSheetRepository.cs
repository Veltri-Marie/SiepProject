namespace Interfaces.Repositories
{
    public interface IJobSheetRepository
    {
           Task<string> GetFormatedSheetAsync(string jobName);

           Task<string> VerifyResult(string result);
    }
}