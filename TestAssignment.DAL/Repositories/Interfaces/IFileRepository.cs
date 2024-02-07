namespace TestAssignment.DAL.Repositories.Interfaces
{
    public interface IFileRepository
    {
        Task FileBulkInsertAsync(string filepath);
        Task<(long, double)> GetSumAndMedianAsync();
    }
}
