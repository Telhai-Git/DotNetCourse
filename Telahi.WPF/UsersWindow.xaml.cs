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
			Users = new List<User>();

		}

   
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void Window_Loaded(object sender, RoutedEventArgs e)
		{
            if (Users.Count==0)
            {
				//Just For Testing
				GenerateFakeData();
            }

			//--Init 
            InitList();

		}

		/// <summary>
		/// Generate Fake Data
		/// Just for debug
		/// </summary>
		private void GenerateFakeData()
		{
			//--Create 10 Users
			for (int i = 0; i < 10; i++)
			{
				Users.Add(new User { Id = Guid.NewGuid().ToString(), Name = "User_" + i, Email = "User_" + i + "@telhai.ac.il" });
			}

		}


		/// <summary>
		/// Init ListBox from  List<User> Data Source
		/// </summary>
		private void InitList()
        {
			//--Use Binding Between lstUsers and Users

			//this.lstUsers.ItemsSource = null;
			//this.lstUsers.ItemsSource = Users;
			
			/////Other Options Adding to ListBox
			//--Clear ListBox
			this.lstUsers.Items.Clear();
			
			//--Add Items to ListBox menually
			foreach (User itemUser in Users)
            {
               this.lstUsers.Items.Add( $"{itemUser.Name} : {itemUser.Email}");
			}

	        if (this.lstUsers.Items.Count> 0)
			{
				btnDel.IsEnabled = true;
				btnUpdate.IsEnabled = true;
			}

		}



		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{

		}

		/// <summary>
		/// Selection Chaged Event of lstUsers
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void lstUsers_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			if (this.lstUsers.Items.Count > 0)
			{

				int index = this.lstUsers.SelectedIndex;
				User user = Users[index];

				txtId.Text = user.Id;
				txtName.Text = user.Name;
				txtEmail.Text = user.Email;
			}
		}


		private void btnUpdate_Click(object sender, RoutedEventArgs e)
		{
			if (this.lstUsers.Items.Count > 0)
			{
				//--Save Selection Index
				int selectedIndex = this.lstUsers.SelectedIndex;
				//--Updated TextBoxes
				this.Users[selectedIndex].Name = txtName.Text;
				this.Users[selectedIndex].Email = txtEmail.Text;

				InitList();
				this.lstUsers.Focus();
				this.lstUsers.SelectedIndex = selectedIndex;

			}
			//this.lstUsers.SelectedIndex = selectedIndex;
			//this.lstUsers.SelectedItem = this.Users[selectedIndex];
		}

		private void btnDel_Click(object sender, RoutedEventArgs e)
		{
			if (this.lstUsers.Items.Count > 0)
			{
				int selectedIndex = this.lstUsers.SelectedIndex;
				this.Users.RemoveAt(selectedIndex);
				InitList();
				ClearUserTextBoxes();

				

			}
			if (this.lstUsers.Items.Count == 0)
			{
                 btnDel.IsEnabled = false;
			     btnUpdate.IsEnabled = false;
			}
			else
			{
				this.lstUsers.SelectedIndex = 0;
			}
		}

		private void ClearUserTextBoxes()
		{
			txtName.Text = string.Empty;
			txtEmail.Text = string.Empty;
			txtId.Text = string.Empty;
		}
	}
}
