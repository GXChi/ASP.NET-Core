using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class NoteDto : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
