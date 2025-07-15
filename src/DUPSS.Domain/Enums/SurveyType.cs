using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum SurveyType
    {
        None,
        PreWorkshop,
        PostWorkshop
    }

    public static class SurveyTypeExtensions
    {
        public static string ToReadableString(this SurveyType surveyType)
        {
            return surveyType switch
            {
                SurveyType.PreWorkshop => "Pre-workshop Survey",
                SurveyType.PostWorkshop => "Post-workshop Survey",
                _ => surveyType.ToString()
            };
        }
    }
}
