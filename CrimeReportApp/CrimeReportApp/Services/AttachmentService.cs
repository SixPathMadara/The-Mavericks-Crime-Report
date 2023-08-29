using CrimeReportApp.Data;
using CrimeReportApp.Models;
using CrimeReportApp.Repositories;
namespace CrimeReportApp.Services
{
    public class AttachmentService : IAttachmentService
    {
        private readonly AttachmentRepo _attachmentRepository;

        public AttachmentService(AttachmentRepo attachmentRepository)
        {
            _attachmentRepository = attachmentRepository;
        }

        public async Task AddAttachment(Attachment attachment)
        {
            

            await _attachmentRepository.AddAttachment(attachment);
        }

        public async Task<Attachment> GetAttachmentById(int attachmentId)
        {
            return await _attachmentRepository.GetAttachmentById(attachmentId);
        }
        public async Task DeleteAttachment(int attachmentId)
        {
            await _attachmentRepository.DeleteAttachment(attachmentId);
        }
    }
}
