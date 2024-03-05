using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.WPF.Models
{
    public class User
    {
        static string defaultImagePath = @"No_image.jpeg";

        public string Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
		public string ImgPath { get; set; }

		public User()
        {
            Id = Guid.NewGuid().ToString();
            ImgPath = defaultImagePath;

		}

        public override string ToString()
		{
			return $"{this.Id.Substring(0,8)}:{Name}:{Email}";
		}

	}
}
