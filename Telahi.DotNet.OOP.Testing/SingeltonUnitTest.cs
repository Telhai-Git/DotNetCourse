namespace Telahi.DotNet.OOP.Testing
{
	[TestClass]
	public class SingeltonUnitTest
	{
		[TestMethod]
		public void Test1()
		{
			Singelton.Instance.Name = "test";
			Singelton.Instance.Id = 1;

			Singelton s1 = Singelton.Instance;
			Assert.AreEqual("test", s1.Name);


			Singelton s2 = Singelton.Instance;
			s2.Name = "s2";
			Assert.AreEqual(s1.Name, "s2");

		}

		[TestMethod]
		public void Test2()
		{
			Singelton s1 = Singelton.Instance;
			Assert.IsNotNull(s1);
		}

		public void TestPoint()
		{
			//--Standart Constractor
			Point p1 = new Point(2, 5);
			p1.Name = "p1";

			//--Initializer 
			Point p2 = new Point { X = 2, Y = 5, Name = "P1" };

			//p1 and p2 have the same values
			//but reference different address heap memory (pointers to heap)
			//therefoere when comparing it compare address not values

			//To Diffrent Pointers 
			Assert.IsFalse(p1 == p2);

		}
	}
}