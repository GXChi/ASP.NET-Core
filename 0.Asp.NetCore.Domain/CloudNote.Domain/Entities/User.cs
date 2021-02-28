using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities
{
    public class User
    {
        public Guid ID { get; set; }
        public string UserName { get; set; }
        public string PassWord { get; set; }
    }
}
