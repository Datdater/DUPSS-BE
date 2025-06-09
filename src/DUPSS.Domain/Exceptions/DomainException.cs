using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public abstract class DomainException(string title, string message) : Exception(message)
    {
        public string Title { get; } = title;
    }
}
