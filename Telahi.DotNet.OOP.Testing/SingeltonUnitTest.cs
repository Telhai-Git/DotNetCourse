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
			
		}

		[TestMethod]
		public void Test2()
		{
			Singelton s1 = Singelton.Instance;
			Assert.IsNotNull(s1);
		}

	}
}