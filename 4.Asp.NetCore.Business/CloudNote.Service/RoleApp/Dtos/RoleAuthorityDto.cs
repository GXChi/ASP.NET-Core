using CloudNote.Domain;

namespace CloudNote.Service.RoleApp.Dtos
{
    public class RoleAuthorityDto : BaseEntity
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public string AuthorityId { get; set; }
        public string AuthorityName { get; set; }
    }
}
