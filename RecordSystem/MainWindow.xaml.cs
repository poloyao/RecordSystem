using RecordSystem.Models;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace RecordSystem
{
	/// <summary>
	/// MainWindow.xaml 的交互逻辑
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			using (var db = new DB.NewsDBContext())
			{
				var item = db.Set<NewsLog>().ToList();
				this.dataGrid.ItemsSource = item;

				var userItems = db.Set<User>().ToList();
				this.comboBox.ItemsSource = userItems;
				this.comboBox.DisplayMemberPath = "Name";

			}
			this.button.Click += (s, e) =>
			{
				using (var db = new DB.NewsDBContext())
				{
					var userItems = db.Set<User>().ToList();
					var user = userItems.SingleOrDefault(x => x.Id == ((User)this.comboBox.SelectedItem).Id);
					if (user == null)
						return;

					db.Set<NewsLog>().Add(new NewsLog { UserID = user, NewsID = new News() { NewsTitle = this.textBox.Text }, UDP = DateTime.Now });
					db.SaveChanges();
					var item = db.Set<NewsLog>().ToList();
					this.dataGrid.ItemsSource = item;
				}
			};



		}
	}
}
