using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class AuthorityEntity : BaseEntity
    {
        public string AuthorityName { get; set; }
        public string AuthorityCode { get; set; }
        public string AuthorityType { get; set; }
    }
}
