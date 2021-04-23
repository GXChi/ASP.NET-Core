using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities
{
    public class NoteEntity : BaseEntity
    {
        public string Title { get; set; }
        public string Label { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
    }
}
