using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public  class BaseModel
	{
        private static int _id = 0;

        public BaseModel()
        {
			BaseModel._id++;
			Id = GeneratePrefix()+_id.ToString();
		}

		protected virtual string GeneratePrefix()
		{
			return "";
		}

        public string Id { get; protected set; }

		public override string ToString()
		{
			return Id;
		}

	}
}
