using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Mapper
{
    public class StepProfile : AutoMapper.Profile
    {
        public StepProfile()
        {
            CreateMap<
                DUPSS.Domain.Entities.Step,
                DUPSS.Application.Models.Steps.GetDetailTrackingResponse
            >();
        }
    }
}
