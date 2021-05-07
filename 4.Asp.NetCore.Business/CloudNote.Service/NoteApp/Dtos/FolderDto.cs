using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class FolderDto : BaseEntity
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
