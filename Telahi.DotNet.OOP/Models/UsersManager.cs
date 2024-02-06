using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public class UsersManager : IUserManager
	{
		private List<User> users;
		private static UsersManager usermanger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerType"></param>
		/// <returns></returns>
		/// <example> UsersManager mngUsers = UsersManager.Instance("MemoryBase") </example>
		public static UsersManager GetInstance(string managerType)
		{
			if (usermanger != null)
				usermanger = new UsersManager(managerType);
		
			return usermanger;	

		}
		/// <summary>
		/// 
		/// </summary>
		public static UsersManager Instance
		{
			get
			{
				if (usermanger != null)
					usermanger = new UsersManager();

				return usermanger;
			}

		} 
		public UsersManager()
		{
			users = new List<User>();
		}

		public UsersManager(string managerType)
		{
			users = new List<User>();
		}

		public void AddUser(User user)
		{
			users.Add(user);
		}

		public void RemoveUser(string id)
		{
			User userFound = users.Find(x => x.Id == id);	
			if (userFound != null) {
				users.Remove(userFound);
			}
			
		}

		public void UpdateUser(string id, User userToUpdate)
		{
			User userFound = users.Find(x => x.Id == id);
			if (userFound != null)
			{
				if ((userFound is AdminUser) && (userToUpdate is AdminUser))
				{
					((AdminUser)userFound).AccessIps = ((AdminUser)userToUpdate).AccessIps;
				}


			}
		}
	}
}
