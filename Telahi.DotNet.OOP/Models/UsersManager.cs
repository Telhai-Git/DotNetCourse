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

		public UsersManager()
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
