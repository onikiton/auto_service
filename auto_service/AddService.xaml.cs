using Microsoft.Win32;
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


namespace auto_service
{
    /// <summary>
    /// Логика взаимодействия для AddService.xaml
    /// </summary>
    public partial class AddService : Window
    {
        public AddService()
        {
            InitializeComponent();
        }

        private void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            using (auto_serviceContext db = new auto_serviceContext())
            {
                try
                {
                    Service addservice = new Service { Title = addTitle.Text, DurationInSeconds = (int)TimeSpan.Parse(addDurationInSeconds.Text).TotalSeconds, Cost = decimal.Parse(addCost.Text),
                    Discount = double.Parse(addDiscount.Text) / 100, Description = addDescription.Text, MainImagePath = filepath};
                    db.Services.Add(addservice);
                    db.SaveChanges();
                }

                catch
                {
                    MessageBox.Show("Поля заполнены неверно");
                }

            }
            Manager.MainFrame.Navigate(new admin_page());
        }

        private void btnaddImage_Click(object sender, RoutedEventArgs e)
        {
            FileDialog fileDialog = new OpenFileDialog();
            fileDialog.InitialDirectory = "c:\\Услуги автосервиса\\";
            fileDialog.ShowDialog();
            filepath = fileDialog.FileName;
            serviceImage.Source = new BitmapImage(new Uri(filepath));
        }

        public string filepath { get; set; }
    }
}
