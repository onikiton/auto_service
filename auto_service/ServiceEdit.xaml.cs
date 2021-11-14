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
    /// Логика взаимодействия для ServiceEdit.xaml
    /// </summary>
    public partial class ServiceEdit : Window
    {

        public ServiceEdit(Service service)
        {
            Service = service;
            InitializeComponent();
            addTitle.Text = Service.Title;
            addDurationInSeconds.Text = TimeSpan.FromSeconds(Service.DurationInSeconds).Hours.ToString() + ":" + TimeSpan.FromSeconds(Service.DurationInSeconds).Minutes.ToString();
            addCost.Text = Service.Cost.ToString();
            addDiscount.Text = (Service.Discount * 100).ToString();
            addDescription.Text = Service.Description;
            serviceImage.Source = new BitmapImage(new Uri(Service.MainImagePath));
        }

        public Service Service { get; set; }

        public void btnSaveService_Click(object sender, RoutedEventArgs e)
        {
            if (filepath == null) { filepath = serviceImage.Source.ToString(); }
            using (auto_serviceContext db = new auto_serviceContext())
            {
                try
                {
                    Service.Title = addTitle.Text;
                    Service.DurationInSeconds = (int)TimeSpan.Parse(addDurationInSeconds.Text).TotalSeconds;
                    Service.Cost = decimal.Parse(addCost.Text);
                    Service.Discount = double.Parse(addDiscount.Text) / 100;
                    Service.Description = addDescription.Text;
                    Service.MainImagePath = filepath;
                    db.Services.Update(Service);
                    db.SaveChanges();
                }

                catch
                {
                    MessageBox.Show("Поля заполнены неверно");
                }
            }
            Manager.MainFrame.Navigate(new admin_page());
        }

        private void btnEditImage_Click(object sender, RoutedEventArgs e)
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
