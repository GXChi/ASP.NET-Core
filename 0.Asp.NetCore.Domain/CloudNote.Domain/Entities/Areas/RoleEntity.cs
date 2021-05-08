using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class RoleEntity : BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string RoleType { get; set; }
        public List<AuthorityEntity> Authoritys { get; set; }
    }
}
