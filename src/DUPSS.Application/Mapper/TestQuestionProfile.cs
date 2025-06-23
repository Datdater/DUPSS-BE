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

            CreateMap<TestResult, GetAllTestResultResponse>()
                .ForMember(dest => dest.FullName,
                    opt => opt.MapFrom(src => $"{src.User.FirstName} {src.User.LastName}"))
                .ForMember(dest => dest.TestName,
                    opt => opt.MapFrom(src => src.Test.Name))
                .ForMember(dest => dest.SurveyType,
                    opt => opt.MapFrom(src => src.Test.SurveyType))
                .ForMember(dest => dest.Category,
                    opt => opt.MapFrom(src => src.Test.Category));

            CreateMap<QuestionOptionTestResult, QuestionOptionTestResultResponse>()
                .ForMember(dest => dest.QuestionId,
                    opt => opt.MapFrom(src => src.SelectedOption.QuestionId))
                .ForMember(dest => dest.QuestionContent,
                    opt => opt.MapFrom(src => src.SelectedOption.Question.Content))
                .ForMember(dest => dest.SelectedOptionContent,
                    opt => opt.MapFrom(src => src.SelectedOption.Content))
                .ForMember(dest => dest.SelectedOptionValue,
                    opt => opt.MapFrom(src => src.SelectedOption.Value));


        }
    }
}
