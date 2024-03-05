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
using System.Text.Json;
using System.IO;
using Microsoft.Win32;
using System.Reflection;
using System.Security.Policy;


//Task Add Image TODO:
// 1) Add XAML PLaceHolder <IMAGE>
// 2) Add Propery To User Path
// 3) When Adding new User to Window Put default image path
//Format: {Imge Origanal Name}_{Id}.png
// 4) User Selected in List Box Show Its Image
// 5) Edit ....
      


namespace Telahi.WPF
{
	/// <summary>
	/// Interaction logic for UsersWindow.xaml
	/// </summary>
	public partial class UsersWindow : Window
	{
		public List<User> Users { get; set; }
		

		public UsersWindow(string title) : this()
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
			if (Users.Count == 0)
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

			this.lstUsers.ItemsSource = null;
			this.lstUsers.ItemsSource = Users;

			/////Other Options Adding to ListBox
			//--Clear ListBox
			//this.lstUsers.Items.Clear();

			//--Add Items to ListBox menually
			//foreach (User itemUser in Users)
			//{
			//	this.lstUsers.Items.Add($"{itemUser.Name} : {itemUser.Email}");
			//}

			if (this.lstUsers.Items.Count > 0)
			{
				btnDel.IsEnabled = true;
				btnUpdate.IsEnabled = true;
				this.lstUsers.SelectedIndex = 0;
			}
			else
			{
				btnDel.IsEnabled = false;
				btnUpdate.IsEnabled = false;
				ClearUserTextBoxes();
			}


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

				//string currentAssemblyPath = System.IO.Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
				//string currentAssemblyParentPath = System.IO.Path.GetDirectoryName(currentAssemblyPath);


				//Update Image
				BitmapImage bitmap = new BitmapImage();
				bitmap.BeginInit();
				var assemblyFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				string appDirPath = System.IO.Path.GetDirectoryName(assemblyFilePath);
			    
				var imageFullpath = System.IO.Path.Combine(appDirPath, user.ImgPath);

				bitmap.UriSource = new Uri(imageFullpath);
				//bitmap.DecodePixelWidth = 100; // Resize width to 200 pixels
				bitmap.EndInit();
				imgUser.Source = bitmap;



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

			if (lstUsers.Items.Count > 0)
			{
				int selectedIndex = this.lstUsers.SelectedIndex;
				this.Users.RemoveAt(selectedIndex);
				InitList();
				if (lstUsers.Items.Count==0)
				{
					ClearUserTextBoxes();
				}
			}
		
		}

		private void ClearUserTextBoxes()
		{
			txtName.Text = string.Empty;
			txtEmail.Text = string.Empty;
			txtId.Text = string.Empty;
		}


		private void btnAdd_Click(object sender, RoutedEventArgs e)
		{
				User user = new User { Name = "No User", Email = "No Email" };
				this.Users.Add(user);
				InitList();
				this.lstUsers.SelectedIndex = this.Users.Count - 1;
		}





		private void Button_Click(object sender, RoutedEventArgs e)
		{
			//TODO Dialog For Write

			JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
			string usersJsonText = JsonSerializer.Serialize<List<User>>(this.Users, options);
			File.WriteAllText("users.json", usersJsonText);

			//Save List as JSON File

			//Serialization:   OBject/List<> --------> (string./File)users.Json
			//Desirialization: users.Json(String/File) -------> Memory Object(List)
		}



		private void btnLoad_Click(object sender, RoutedEventArgs e)
		{
			OpenFileDialog openFileDialog = new OpenFileDialog();
			openFileDialog.Filter = "[JSON files] (*.JSON)|*.txt|All files (*.*)|*.*";
			
			string fileName = "";
			if (openFileDialog.ShowDialog() == true)
			{
				fileName = openFileDialog.FileName;
				using FileStream openStream = File.OpenRead(fileName);
				
				object listObj = JsonSerializer.Deserialize<List<User>>(openStream);
				if (listObj is List<User> list)
				{
					this.Users = list;
					InitList();
				}



			}
			//Open File Dialog

			

		}


		
		/// <summary>
		/// 
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void imgUser_MouseUp(object sender, MouseButtonEventArgs e)
		{
			OpenFileDialog dlg = new OpenFileDialog();
			//dlg.InitialDirectory = "D://";
			dlg.Filter = "Image files (*.jpg)|*.jpg|All Files (*.*)|*.*";
			dlg.RestoreDirectory = true;

			if (dlg.ShowDialog() == true)
			{

				//--User Image Parts
			    var userImageSourcePath = dlg.FileName;
				string userFileName = System.IO.Path.GetFileNameWithoutExtension(userImageSourcePath);
				string userFileExt = System.IO.Path.GetExtension(userImageSourcePath);
				string newFileName = $"{userFileName}_{txtId.Text}{userFileExt}";

				var assemblyFilePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
				string appDirPath = System.IO.Path.GetDirectoryName(assemblyFilePath);

		
				//IMages Path For All Images
				string imagesDir = System.IO.Path.Combine(appDirPath,"images");
				string destDirPath = System.IO.Path.Combine(imagesDir, newFileName);

				if (!Directory.Exists(imagesDir)) 
				{
					Directory.CreateDirectory(imagesDir);
				}

				File.Copy(userImageSourcePath, destDirPath);

				//*User Update Property
				UpdateUserImage(txtId.Text, destDirPath);

			}




		}

		private void UpdateUserImage(string userId ,string destDirPath)
		{
			 //Update Model
			 User found = Users.SingleOrDefault(u => u.Id == userId);
			 found.ImgPath = destDirPath;//*Dont Save All 

			//UpdateDisplay Image in Window
			BitmapImage bitmap = new BitmapImage();
			bitmap.BeginInit();
		
			bitmap.UriSource = new Uri(destDirPath);
			//bitmap.DecodePixelWidth = 100; // Resize width to 200 pixels
			bitmap.EndInit();
			imgUser.Source = bitmap;



		}
	}
}
