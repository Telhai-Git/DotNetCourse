using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public interface IUserManager
	{
		void AddUser(User user);
		void RemoveUser(string id);
		void UpdateUser(string id,User userToUpdate);
		User[] GetAllUsers();
		User GetUserById(string user);

	}
}
