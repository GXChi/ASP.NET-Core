using CloudNote.Domain;

namespace CloudNote.Service.AuthorityApp.Dtos
{
    public class AuthorityDto : BaseEntity
    {
        public string AuthorityName { get; set; }
        public string AuthorityCode { get; set; }
        public string AuthorityType { get; set; }
        public string AuthorityDescription { get; set; }
    }
}
