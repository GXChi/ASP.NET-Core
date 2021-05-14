using System.Collections.Generic;

namespace CloudNote.Domain.Entities.Areas
{
    public class RoleEntity : BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string RoleType { get; set; }
        public string Description { get; set; }
        public List<RoleAuthorityEntity> UserRoles { get; set; }
    }
}
