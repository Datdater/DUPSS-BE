using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Abtractions
{
    public interface IClaimService
    {
        string GetCurrentUser { get; }
    }
}
