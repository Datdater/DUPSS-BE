//using System;
//using System.Collections.Generic;
//using System.ComponentModel.DataAnnotations;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace DUPSS.Domain.Exceptions
//{
//    public class BadRequestException : System.Exception
//    {
//        public BadRequestException(string message) : base(message)
//        {

//        }
//        public BadRequestException(string message, ValidationResult validationResult) : base(message)
//        {
//            ValidationErrors = validationResult.ToDictionary();
//        }

//        public IDictionary<string, string[]> ValidationErrors { get; set; }

//    }
//}
