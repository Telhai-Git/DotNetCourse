namespace Telahi.DotNet.OOP
{
    /// <summary>
    /// Class Point
    /// </summary>
	public class Point
	{

		#region --fields--
		private int x;
		private int y;
		#endregion

		#region --Constractors--
		/// <summary>
		/// Empty Ctor
		/// </summary>
		public Point()
        {
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
			   if (value>=0)	
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



		#endregion

		#region --Methods--

		#endregion


		public override string ToString()
		{
			return $"x:{x}, y:{y}";
		}


	}
}
