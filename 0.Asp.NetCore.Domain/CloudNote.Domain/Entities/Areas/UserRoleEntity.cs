using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class UserRoleEntity : BaseEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
