using CloudNote.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class PermissionDto : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}
