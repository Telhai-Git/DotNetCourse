using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public class User : BaseModel
	{

		public string UserName { get; set; }
		public string PassWord { get; set; }

		public RoleAccessEmum AccessType { get; set; }


	public User() { }

		public User(string username):base()//Empty Constractor Of Base
		{
			UserName = username;
		}

		protected override string GeneratePrefix()
		{
			return "User_";
		}

		/// <summary>
		/// Arrow Function
		/// </summary>
		/// <returns></returns>
		public override string ToString() => $"{Id}:{UserName}";



		public override void Test()
		{
			
		}


	}

  public enum RoleAccessEmum {

	 NoNetworkAccess = 0,
	 FileAccess = 1,
	 AdmiFolderAccess  = 2,
    

}



}
