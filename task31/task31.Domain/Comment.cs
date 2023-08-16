using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using task31.Domain.Common;

namespace task31.Domain
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; } = "";
        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
    }

}
