using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public class AdminUser : User
	{

		public List<string> AccessIps { get; set; }

		public AdminUser()
		{
			AccessIps = new List<string>();
		}

		public AdminUser(string username) : base(username)
		{
			AccessIps = new List<string>();
		}
		protected override string GeneratePrefix()
		{
			return "Admin_";
		}

		public override void Test()
		{
			//base.Test();
		}

	}
}
