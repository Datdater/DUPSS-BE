using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DUPSS.Domain.Enums
{
	public enum Role
	{
		[EnumMember(Value = "Admin")]
		Admin,
		[EnumMember(Value = "Member")]
		Member,
		[EnumMember(Value = "Staff")]
		Staff,
		[EnumMember(Value = "Consultant")]
		Consultant,
		[EnumMember(Value = "Manager")]
		Manager,
	}
}
