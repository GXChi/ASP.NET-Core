﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities.Areas
{
    public class PermissionEntity : BaseEntity
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Code { get; set; }
    }
}
