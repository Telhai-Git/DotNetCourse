using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Telahi.DotNet.OOP
{
	public class Point3D : Point //1) Inheritance
	{

		/// <summary>
		/// Z Point
		/// </summary>
		public int Z { get; set; }

		public Point3D() : this(0,0,0)
        {
                
        }

		public Point3D(int xyz) : this(xyz,xyz,xyz)
		{

		}

		public Point3D(int x,int y ,int z):base(x,y) //02 base(...)
		{
			this.Z = z;
		}

		public override int sumAllPoints()
		{
			return  base.sumAllPoints() + Z;
		}

		public override string ToString()
		{
			return base.ToString() + ", z:"+Z;
		}

		public void Test()
		{

		}

	}
}
