using CloudNote.Domain.Entities;
using CloudNote.Domain.Entities.Areas;
using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Service.NoteApp.Dtos
{
    public class UserDto : BaseEntity
    {
        public string UserName { get; set; }
        public string NickName { get; set; }
        public string PassWord { get; set; }
        public string Sex { get; set; }
        public string Ethnicity { get; set; }
        public string Age { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string PersonalSignature { get; set; }
        public List<RoleEntity> Roles { get; set; }
        public List<AuthorityEntity> Authoritys { get; set; }
    }
}
