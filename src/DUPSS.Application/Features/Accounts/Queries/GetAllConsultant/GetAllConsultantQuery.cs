using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Accounts;
using DUPSS.Domain.Abstractions.Message;

namespace DUPSS.Application.Features.Accounts.Queries.GetAllConsultant
{
    public class GetAllConsultantQuery : IQuery<List<GetAllConsultantResponse>> { }
}
