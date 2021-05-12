using System;
using CloudNote.Domain;

namespace CloudNote.Service.FolderApp.Dtos
{
    public class FolderDto : BaseEntity
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
