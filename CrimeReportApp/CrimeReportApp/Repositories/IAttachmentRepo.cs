using CrimeReportApp.Models;

namespace CrimeReportApp.Repositories
{
    public interface IAttachmentRepo
    {
        Task<Attachment> GetAttachmentById(int attachmentId);
        Task AddAttachment(Attachment attachment);
        
        Task DeleteAttachment(int attachmentId);
    }
}
