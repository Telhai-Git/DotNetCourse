using System.Net.Http.Headers;
using System.Runtime.CompilerServices;

namespace Telahi.DotNet.OOP
{
	/// <summary>
	/// Class Point
	/// </summary>
	public class Point
	{

		#region --private fields--
		private int x;
		private int y;
		private string id;
		private static int max_x;
		private static int max_y;

		#endregion

		#region --Constractors--
		/// <summary>
		/// Empty Ctor
		/// </summary>
		public Point()
		{
			Name = "";
			IsHidden = false;
			x = 0;
			y = 0;
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="x">x val</param>
		/// <param name="y">y val</param>
		public Point(int x, int y)
		{
			this.x = x;
			this.y = y;
		}

		public Point(int val)
		{
			this.x = val;
			this.y = val;
		}

		#endregion

		#region --Properties--

		public int X
		{
			get { return x; }
			set {
				if (value >= 0)
					x = value;
			}
		}
		/// <summary>
		/// 
		/// </summary>
		public int Y
		{
			get { return y; }
			set
			{
				if (value >= 0)
					y = value;
			}
		}

		/// <summary>
		/// Auto Prop Data
		/// </summary>
		public bool IsHidden { get; set; }
		public string Name { get; set; } = "";


		//public string ID
		//{
		//	get { return id; }
		//	set { id = value; } }
		//   }

		//Only get
		public string Id { get => id; }

		public static int MaxX { 
			get { 
				  //refernce only static fields/function
				  return max_x;

			}
			set
			{
				if (Validate(value))
				{
					max_x = value;
				}
			}
		}

		/// <summary>
		/// 
		/// </summary>
		/// <param name="value"></param>
		/// <returns></returns>
		private static bool Validate(int value)
		{

			return (value > 0); 
		}


		#endregion

		#region --Methods--

		#endregion

		/// <summary>
		/// Test Representation of the Object
		/// </summary>
		/// <returns></returns>
		public override string ToString()
		{
			return $"x:{x}, y:{y}";
		
		}

		public static Point SpecialPoint()
		{
		    Point point_0 = new Point(0,0);
			return point_0;
		}

		public virtual int sumAllPoints()
		{
			return x + y;
		}




	}
}
