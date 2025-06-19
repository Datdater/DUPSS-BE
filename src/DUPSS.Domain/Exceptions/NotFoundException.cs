using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Exceptions;

public abstract class NotFoundException(string message) : DomainException("Not Found", message);
