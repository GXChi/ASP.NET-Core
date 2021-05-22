using CloudNote.Domain;
using CloudNote.Domain.Entities.Areas;
using System.Collections.Generic;

namespace CloudNote.Service.RoleApp.Dtos
{
    public class RoleDto : BaseEntity
    {
        public string RoleName { get; set; }
        public string RoleCode { get; set; }
        public string RoleType { get; set; }
        public string Description { get; set; }

        public List<RoleAuthorityEntity> RoleAuthoritys { get; set; }
    }
}
