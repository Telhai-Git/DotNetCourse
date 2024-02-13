using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Xml.Linq;
using Telahi.DotNet.OOP;
using Telahi.DotNet.OOP.Models;
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
			////-Reference Static
			//Point.MaxX = 10;
			////-example for static method crteate an object
			//Point p0 = Point.SpecialPoint();
			//string name = p0.Name;
			//Console.WriteLine(p0);


			////Singelton s1 = new Singelton();
			////Singelton s2 = new Singelton();
			//Singelton s1 =  Singelton.Instance;
			//s1.Id = 1;
			//s1.Name = "myName";
			//Singelton.Instance.Name = "2";
			//Singelton s2 = Singelton.Instance;
			//s2.Name = "S2";
			//Console.WriteLine(s2.MethodA());

			////--Same Pointer
			//Singelton s3 = s2;

			//Point s5 = new(2,5);
			//Point s6 = new(2, 5);




			#endregion

			#region --Inheritance--

			//--Create 5 of Point3D inherit from Point
			Point3D p3d_1 = new Point3D();
			Point3D p3d_2 = new Point3D(5);
			Point3D p3d_3 = new Point3D(1,7,3);
			var p3d_4 = new Point3D(x:1,y:7,z:3);	
			var p3d_5 =  new Point3D { X = 10, Y = 20, Z = 3 };
			//--Use Initializer or Constractor Instead
			//var p3d_5 = new Point3D();
			//p3d_6.X = 10;
			//p3d_6.Y = 20;
			//p3d_6.Z = 3;

			//--p3d_5 Can access all Public members of base classes
			//--IsHidden in Point Class and all base classes
			p3d_5.IsHidden = true;

			//--sumAllPoints of Point3D triggered
			Console.WriteLine(p3d_3.sumAllPoints());

		
			//-------------Polimorphism------------
			
			//Point is actually Point3D 
			//When Virtaul Override is enabled 
			//base class(Point) types can invoke functions of derived class(Point3D)
			Point p_3d = new Point3D(1,3,5);
			int res = p_3d.sumAllPoints();

			//--Cant Call Test from p_3d even if its actually point to Point3D
			//p_3d.Test()

			//Inorder to become the real type Point3D make casting
			var p3d = (Point3D)p_3d;//p3d == p_3d
			p3d.Test();

			//if (p_3d is Point3D)
			//{
			//	 p3d = (Point3D)p_3d;
			//}
			
			//--Safe Cast
			if (p_3d is Point3D my3dPoint)
			{
				my3dPoint.Test();
			}
			//Array Of Point with Point3d Values 
			 var points = new Point[]{ p3d_3,p3d_4,p3d_5 };

			int sum = 0;
			foreach ( Point point in points )
			{
				//sumAllPoints of Point3d
				Console.WriteLine(point.sumAllPoints());
				
				//Sum all 3 Points
				sum += point.sumAllPoints();
			}
			Console.WriteLine(sum);

			#endregion


			#region
			AdminUser admin1 = new AdminUser("user1") ;
			User admin2 = new User("user2");
			AdminUser admin3 = new AdminUser("user3");
			admin3.AccessType = RoleAccessEmum.AdmiFolderAccess;

		


			List<User> users = new List<User>();
			users.Add(admin1);
			users.Add(admin2);
			users.Add(admin3);

			for (int i = 0; i < users.Count; i++)
			{
			   User user = users[i];
			   Console.WriteLine(user);
			}


			IUserManager mng =  UsersManager.GetInstance();
			HandleUsers(mng);
			if (mng is ICSVWriter writer)
			{
				writer.Write("users.csv");
			}

			#endregion




			Console.ReadKey();









		}


        public static void HandleUsers(IUserManager manger)
		{
			manger.AddUser(new AdminUser("stefca"));
			manger.AddUser(new AdminUser("labronj"));
			manger.AddUser(new AdminUser("avdiaa"));

		}


	}
}
