using System;
using System.Collections.Generic;

namespace CloudNote.Domain.Entities
{
    public class FolderEntity : BaseEntity
    {
        public string Name { get; set; }

        public string Describe { get; set; }

        public List<FolderEntity> NextFolder { get; set; }
    }

    
}
