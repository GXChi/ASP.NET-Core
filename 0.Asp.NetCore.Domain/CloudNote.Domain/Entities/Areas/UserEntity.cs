using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class UserEntity : BaseEntity
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
    }
}
