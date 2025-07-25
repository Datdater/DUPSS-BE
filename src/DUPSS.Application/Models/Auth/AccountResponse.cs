﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Application.Models.Account
{
	public class AccountResponse
	{
		public Guid Id { get; set; }
		public string? Username { get; set; }
		public string? Email { get; set; }
		public string? Name { get; set; }
		public string? Role { get; set; }
	}
}
