using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using task31.Domain;

namespace task31.Application.Persistence.Contracts
{
    public interface IPostRepository : IGenericRepository<Post>
    {
    }
}
