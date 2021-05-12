﻿using System;
using System.Collections.Generic;

namespace CloudNote.Domain.Entities
{
    public class FolderEntity : BaseEntity
    {
        public Guid FolderId { get; set; }
        public string Name { get; set; }
        public Guid ParentId { get; set; }
        public string ParentName { get; set; }
    }
}
