using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Telahi.WPF.Models;

namespace Telahi.WPF
{
    /// <summary>
    /// Interaction logic for UsersWindow.xaml
    /// </summary>
    public partial class UsersWindow : Window
    {
       public List<User> Users {get;set;}

        public UsersWindow(string title):this()
        {
            Title = title;
        }

        public UsersWindow()
        {
            InitializeComponent();

        }


		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
            Users = new List<User>();
   //         Users.Add(new User { Id = Guid.NewGuid().ToString(), Name = "Davids", Email = "user1@outlook.com" });
			//Users.Add(new User { Id = Guid.NewGuid().ToString(), Name = "Davids", Email = "user1@outlook.com" });
            for (int i = 0; i < 10; i++)
            {
				Users.Add(new User { Id = Guid.NewGuid().ToString(), Name = "User_"+i, Email = "User_" +i+"@telhai.ac.il" });
			}


            //TaKe Users as Source Of The Control 
            InitList();


		}

        private void InitList()
        {
			//this.lstUsers.Items.Clear();
			//// this.lstUsers.ItemsSource = null;
			//this.lstUsers.ItemsSource = Users;

			this.lstUsers.Items.Clear();
			foreach (User itemUser in Users)
            {
                this.lstUsers.Items.Add( $"{itemUser.Name} : {itemUser.Email}");
			}


		}



		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{

		}

		private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
            int index = this.lstUsers.SelectedIndex;
            User user = Users[index];

            TxtBoxId.Text = user.Id;
			TxtBoxUseName.Text = user.Name;

		}
	}
}
