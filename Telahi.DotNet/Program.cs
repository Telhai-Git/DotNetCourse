using System.Runtime.InteropServices;
using Telahi.DotNet.OOP;
namespace Telahi.DotNet
{
	internal class Program
	{
		static void Main(string[] args)
		{

			#region -- 02 Working With Class And Properties--
			Point point1 = new Point();
			int xVal = point1.X; //Get
			point1.X = 20;//Set
			point1.X = -5;//set x is still 20
			point1.Y = 4;//set 
			//--Auto Properties
			point1.Name = "P_1";
			point1.IsHidden = true;


			Console.WriteLine($"P1: x:{point1.X}, y:{point1.Y}");
			Console.WriteLine($"point1:{point1}");

			//Point point2 = new Point(10);
			//Point point3 = new Point(12,5);



			#endregion




			#region --Static--
			//Reference Static
			Point.MaxX = 10;
			//example for static method crteate an object
			Point p0 = Point.SpecialPoint();
			Console.WriteLine(p0);

			#endregion


			Console.ReadKey();









		}
	}
}
