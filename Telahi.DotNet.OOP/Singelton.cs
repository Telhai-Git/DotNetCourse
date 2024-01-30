using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP
{
	public class Singelton
	{
		private static Singelton _instance = null;

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
		/// </summary>
		private Singelton()
        {    
        }


        public int id { get; set; }
		public int Name { get; set; }
	}
}
