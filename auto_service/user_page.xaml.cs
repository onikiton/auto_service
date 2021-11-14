using System;
using System.Collections.Generic;
using System.Globalization;
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

namespace auto_service
{
    /// <summary>
    /// Логика взаимодействия для user_page.xaml
    /// </summary>
    public partial class user_page : Page
    {
        public user_page()
        {
            InitializeComponent();
            auto_serviceContext db = new auto_serviceContext();
            ServicesGrid.ItemsSource = db.Services.ToList();
            Sorting.SelectedIndex = 0;
            Filter.SelectedIndex = 0;
        }
        public Service Service { get; set; }

        private void btnAunt_Click(object sender, RoutedEventArgs e)
        {
            auntefication auntefication = new auntefication();
            if (auntefication.ShowDialog() == true)
            {
                if (auntefication.Password == "0000")
                    Manager.MainFrame.Navigate(new admin_page());
                else
                    MessageBox.Show("Неверный пароль");
            }         
        }

        private void discount1_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void discount2_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void discount3_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.30).ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.30).OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.30).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void discount4_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void discount5_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void All_Selected(object sender, RoutedEventArgs e)
        {
            int sortingImdex = Sorting.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (sortingImdex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.ToList();
            }
            if (sortingImdex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.OrderBy(c => c.Cost).ToList();
            }
            if (sortingImdex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void SortUp_Selected(object sender, RoutedEventArgs e)
        {
            int FilterIndex = Filter.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (FilterIndex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.OrderBy(c => c.Cost).ToList();
            }
            if (FilterIndex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).OrderBy(c => c.Cost).ToList();
            }
            if (FilterIndex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).OrderBy(c => c.Cost).ToList();
            }
            if (FilterIndex == 3)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.3).OrderBy(c => c.Cost).ToList();
            }
            if (FilterIndex == 4)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).OrderBy(c => c.Cost).ToList();
            }
            if (FilterIndex == 5)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).OrderBy(c => c.Cost).ToList();
            }
        }

        private void SortDown_Selected(object sender, RoutedEventArgs e)
        {
            int FilterIndex = Filter.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (FilterIndex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 3)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.3).OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 4)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 5)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).OrderByDescending(c => c.Cost).ToList();
            }
        }

        private void noSort_Selected(object sender, RoutedEventArgs e)
        {
            int FilterIndex = Filter.SelectedIndex;
            auto_serviceContext db = new auto_serviceContext();
            if (FilterIndex <= 0)
            {
                ServicesGrid.ItemsSource = db.Services.OrderByDescending(c => c.Cost).ToList();
            }
            if (FilterIndex == 1)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0).Where(s => s.Discount < 0.05).ToList();
            }
            if (FilterIndex == 2)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.05).Where(s => s.Discount < 0.15).ToList();
            }
            if (FilterIndex == 3)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.15).Where(s => s.Discount < 0.3).ToList();
            }
            if (FilterIndex == 4)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.3).Where(s => s.Discount < 0.7).ToList();
            }
            if (FilterIndex == 5)
            {
                ServicesGrid.ItemsSource = db.Services.Where(s => s.Discount >= 0.7).Where(s => s.Discount < 1).ToList();
            }
        }
    }

}