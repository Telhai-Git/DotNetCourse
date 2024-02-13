using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Telahi.DotNet.OOP.Models
{
	public interface ICSVWriter
	{
		void Write(string path);

		string ToCsvString();
	}
}
