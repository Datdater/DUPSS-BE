using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public class TestException
    {
        public class TestNotFoundException : NotFoundException
        {
            public TestNotFoundException(string id)
                : base($"Test with ID '{id}' was not found.") { }
        }
    }
}
