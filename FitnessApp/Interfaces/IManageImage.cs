namespace FitnessApp.Interfaces
{
    public interface IManageImage
    {
        Task<string> UploadFile(IFormFile _File, Guid userId);
        Task<(byte[], string, string)> DownloadFile(string FileName);
    }
}
