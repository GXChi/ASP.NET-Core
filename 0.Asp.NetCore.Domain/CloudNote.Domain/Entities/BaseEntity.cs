using System;
using System.Collections.Generic;
using System.Text;

namespace CloudNote.Domain.Entities
{
    /// <summary>
    /// 泛型实体基类
    /// </summary>
    /// <typeparam name="TPrimaryKey">主键类型</typeparam>
    public abstract class BaseEntity<TPrimaryKey>
    {
        /// <summary>
        /// 泛型实体基类
        /// </summary>
        public virtual TPrimaryKey Id { get; set; }

    }

    /// <summary>
    /// 定义默认主键类型为Guid的实体基类
    /// </summary>
    public class BaseEntity : BaseEntity<Guid>
    {    
        public string CreateName { get; set; }
        public Guid CreateID { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateName { get; set; }
        public Guid UpdateID { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
