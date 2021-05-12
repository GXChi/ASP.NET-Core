using System;
using CloudNote.Domain;

namespace CloudNote.Service.UserApp.Dtos
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
        public string Address { get; set; }
        public string PersonalSignature { get; set; }
        public DateTime LastLoginTime { get; set; }
        public int LoginTimes { get; set; }
        public bool IsDelete { get; set; }
        public bool IsEnable { get; set; }
    }
}
