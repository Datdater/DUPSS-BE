using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public class BlogException
    {
        public class BlogNotFoundException : NotFoundException
        {
            public BlogNotFoundException(string blogId)
                : base($"Blog with ID '{blogId}' not found.")
            {
            }
        }
    }
}
