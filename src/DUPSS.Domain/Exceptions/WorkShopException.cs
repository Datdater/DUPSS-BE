using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public class WorkShopException
    {
        public class WorkShopNotFoundException : NotFoundException
        {
            public WorkShopNotFoundException(string workshopId)
                : base($"Blog with ID '{workshopId}' not found.")
            {
            }
        }
    }
}
