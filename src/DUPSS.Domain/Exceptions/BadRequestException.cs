using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions
{
    public abstract class BadRequestException(string message)
        : DomainException("Bad Request", message);
}
