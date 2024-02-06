using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Auth
{
	public class User
	{

		public int Id { get; set; }
		public string UserName { get; set; }
		public string PassWord { get; set; }


		public User() { }

		public User(string username)
		{
			UserName = username;
		}

		/// <summary>
		/// Arrow Function
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"{Id}:{UserName}";
		
		
	}
}
