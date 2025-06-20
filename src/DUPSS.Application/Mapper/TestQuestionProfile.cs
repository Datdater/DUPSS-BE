using AutoMapper;
using DUPSS.Application.Features.TestQuestions.Commands.Create;
using DUPSS.Application.Models.TestQuestions;
using DUPSS.Domain.Entities;

namespace DUPSS.Application.Mapper
{
    public class TestQuestionProfile : Profile
    {
        public TestQuestionProfile()
        {
            CreateMap<TestQuestionRequest, TestQuestion>();
            CreateMap<QuestionOptionRequest, QuestionOption>();

            CreateMap<TestQuestion, GetTestQuestionWithOptionsResponse>();

            CreateMap<QuestionOption, QuestionOptionResponse>();

        }
    }
}
