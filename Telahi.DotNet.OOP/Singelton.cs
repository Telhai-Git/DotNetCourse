using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP
{
	public class Singelton
	{
		//02) Static instance of the same class type
		private static Singelton _instance = null;

		//03) Create Property to Iniilize the object if not exsit
		public static Singelton Instance
		{
			get { 
			      
				//Not Exsist Yet
			   if (_instance == null)
					_instance = new Singelton();

			   //already exsist
				return _instance;
			}
		}

		/// <summary>
		/// 1) Lock Constractor from outsite world
		///    Set Private
		/// </summary>
		private Singelton()
        {    
        }


        public int Id { get; set; }
		public int Name { get; set; }

		public string MethodA()
		{
			return Id + "_" + Name;
	    }
	}
}
