
using CrimeReportApp.Data;
using CrimeReportApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CrimeReportApp.Repositories
{
    public class AttachmentRepo : IAttachmentRepo
    {
        private readonly CrimeContext _context;

        public AttachmentRepo(CrimeContext context)
        {
            _context = context;
        }
        public async Task<Attachment> GetAttachmentById(int attachmentId)
        {
            var File = await _context.Attachments.FindAsync(attachmentId);
            if (File == null) return null;
            Attachment attachment = new Attachment()
            {
                AttachmentID = File.AttachmentID,
                ReportID = File.ReportID,
                FileType = File.FileType,
                FileContent = File.FileContent
            };
            return attachment;
        }
       
        public async Task AddAttachment(Attachment attachment)
        {
            AttachmentEntity attachmentEntity = new AttachmentEntity()
            {
                AttachmentID = attachment.AttachmentID,
                ReportID = attachment.ReportID,
                FileType = attachment.FileType,
                FileContent = attachment.FileContent
            };
            _context.Attachments.Add(attachmentEntity);
            await _context.SaveChangesAsync();
            
        }
        public async Task DeleteAttachment(int attachmentId)
        {
            var attachment = await _context.Attachments.FindAsync(attachmentId);
            if (attachment != null)
            {
                _context.Attachments.Remove(attachment);
                await _context.SaveChangesAsync();
            }
        }
    }    
       
}
