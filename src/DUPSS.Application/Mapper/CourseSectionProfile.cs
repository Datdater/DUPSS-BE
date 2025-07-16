using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DUPSS.Application.Models.Steps;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper
{
    public class CourseSectionProfile : AutoMapper.Profile
    {
        public CourseSectionProfile()
        {
            CreateMap<Step, GetStepPreviewResponse>();
            CreateMap<
                Domain.Entities.CourseSection,
                Models.CourseSections.GetCourseSectionResponse
            >();
        }
    }
}
