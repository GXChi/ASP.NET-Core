using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class RoleDto : BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string RoleType { get; set; }
        public List<AuthorityEntity> Authoritys { get; set; }
    }
}
