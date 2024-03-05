using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.WPF.Models
{
    public class User
    {
        static string defaultImagePath = @"images/noimage.jpg";

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
		public string imgPath { get; set; }

		public User()
        {
            Id = Guid.NewGuid().ToString();
            imgPath = defaultImagePath;

		}

        public override string ToString()
		{
			return $"{this.Id.Substring(0,8)}:{Name}:{Email}";
		}

	}
}
