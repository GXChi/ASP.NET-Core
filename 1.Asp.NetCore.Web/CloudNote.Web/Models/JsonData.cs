using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CloudNote.Web.Models
{
    public class JsonData<T>
    {
        public JsonData()
        {
            Code = 0;
            Count = 1;
        }
        public int Code { get; set; }
        public string MSG { get; set; }
        public int Count { get; set; }
        public List<T> Data { get; set; }

    }
}
