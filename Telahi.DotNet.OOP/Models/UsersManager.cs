using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	/// <summary>
	/// UserManager Based On Memory List implementing IUserManager
	/// </summary>
	public class UsersManager : IUserManager
	{
		//--Private Memory Array 
		private List<User> users;
		private static UsersManager usermanger;

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerType"></param>
		/// <returns></returns>
		/// <example> IUserManager mngUsers = UsersManager.Instance("MemoryBase") </example>
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
	
		/// <summary>
		/// 
		/// </summary>
		public UsersManager()
		{
			users = new List<User>();
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="managerType"></param>
		public UsersManager(string managerType)
		{
			users = new List<User>();
		}
		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="user"></param>
		public void AddUser(User user)
		{
			users.Add(user);
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		public void RemoveUser(string id)
		{
			User userFound = users.Find(x => x.Id == id);	
			if (userFound != null) {
				users.Remove(userFound);
			}
			
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="id"></param>
		/// <param name="userToUpdate"></param>
		public void UpdateUser(string id, User userToUpdate)
		{
			User userFound = users.Find(x => x.Id == id);
			userFound.AccessType = userToUpdate.AccessType;

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
