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

namespace auto_service
{
    /// <summary>
    /// Логика взаимодействия для admin_page.xaml
    /// </summary>
    public partial class admin_page : Page
    {
        public admin_page()
        {
            InitializeComponent();
            auto_serviceContext db = new auto_serviceContext();
            ServicesGrid.ItemsSource = db.Services.ToList();
            ClientGrid.ItemsSource = db.Clients.ToList();
            ClientServiceGrid.ItemsSource = db.ClientServices.ToList();
            nextClientServiceGrid.ItemsSource = db.ClientServices.Where(c => c.StartTime <= DateTime.Now.AddDays(2)).Where(c => c.StartTime >= DateTime.Now).OrderBy(c => c.StartTime).ToList();
        }

        private void btnUser_Click(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new user_page());
        }

        private void btnAddService_Click(object sender, RoutedEventArgs e)
        {
            AddService AddService = new AddService();
            AddService.Show();
        }

        private void BtnServiceDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить услугу?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                using (auto_serviceContext db = new auto_serviceContext())
                {
                    try
                    {
                        db.Services.Remove((sender as Button).DataContext as Service);
                        db.SaveChanges();
                        ServicesGrid.ItemsSource = db.Services.ToList();
                    }

                    catch
                    {
                        MessageBox.Show("Ошибка удаления", "", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }     
        }

        private void BtnServiceEdit_Click(object sender, RoutedEventArgs e)
        {
           
            ServiceEdit ServiceEdit = new ServiceEdit((sender as Button).DataContext as Service);
            ServiceEdit.Show();
            
        }

        private void btnClientAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClient AddClient = new AddClient();
            AddClient.Show();
        }

        private void btnClientDel_Click(object sender, RoutedEventArgs e)
        {
            using (auto_serviceContext db = new auto_serviceContext())
            {
                if (ClientGrid.SelectedItem == null)
                {
                    MessageBox.Show("Для удаления выдилите клиента", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    if (MessageBox.Show("Удалить клиента?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
                    {
                        try
                        {
                            db.Clients.Remove((Client)ClientGrid.SelectedItem);
                            db.SaveChanges();
                            ClientGrid.ItemsSource = db.Clients.ToList();
                        }

                        catch
                        {
                            MessageBox.Show("Ошибка удаления", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }

        private void btnClientEdit_Click(object sender, RoutedEventArgs e)
        {
            ClientEdit ClientEdit = new ClientEdit((Client)ClientGrid.SelectedItem);
            ClientEdit.Show();

        }

        private void btnClientServiceAdd_Click(object sender, RoutedEventArgs e)
        {
            AddClientService AddClientService = new AddClientService();
            AddClientService.Show();
        }

        private void btnClientServiceDel_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Удалить запись?", "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {
                if (ClientServiceGrid.SelectedItem == null)
                {
                    MessageBox.Show("Для удаления выдилите запись", "", MessageBoxButton.OK, MessageBoxImage.Exclamation);
                }
                else
                {
                    using (auto_serviceContext db = new auto_serviceContext())
                    {
                        try
                        {
                            db.ClientServices.Remove((ClientService)ClientServiceGrid.SelectedItem);
                            db.SaveChanges();
                            ClientServiceGrid.ItemsSource = db.ClientServices.ToList();
                        }
                        catch
                        {
                            MessageBox.Show("Ошибка удаления", "", MessageBoxButton.OK, MessageBoxImage.Error);
                        }
                    }
                }
            }
        }
    }
}


