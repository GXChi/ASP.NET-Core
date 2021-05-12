using System;
using CloudNote.Domain;

namespace CloudNote.Service.UserApp.Dtos
{
    public class UserRoleDto : BaseEntity
    {
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string RoleId { get; set; }
        public string RoleName { get; set; }
    }
}
