using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class RoleAuthorityEntity : BaseEntity
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string AuthorityId { get; set; }
        public string AuthorityName { get; set; }
    }
}
