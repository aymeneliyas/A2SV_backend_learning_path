using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task31.Domain;
using task31.Domain.Common;

namespace task31.Domain
{
    public class Post : BaseEntity
    {
    
        public string Title { get; set; } = "";
        public string Content { get; set; } = "";
      
        public virtual ICollection<Comment> comments { get; set; }
    }
}
