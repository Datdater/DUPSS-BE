using DUPSS.Application.Models.Auth;
using DUPSS.Domain.Abstractions.Message;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Features.Authentications.Commands.Login
{
	public class LoginCommand : ICommand<LoginResponse>
 	{
		public required string EmailOrUserName { get; set; }
		public required string Password { get; set; }
	}
}
