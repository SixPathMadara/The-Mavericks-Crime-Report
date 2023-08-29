using CrimeReportApp.Models;
namespace CrimeReportApp.Services
{
    public interface IAttachmentService
    {
        Task<Attachment> GetAttachmentById(int attachmentId);
        Task AddAttachment(Attachment attachment);
        Task DeleteAttachment(int attachmentId);
    }
}
