using Microsoft.EntityFrameworkCore;
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
    /// Логика взаимодействия для AddClientService.xaml
    /// </summary>
    public partial class AddClientService : Window
    {

        public AddClientService()
        {
            InitializeComponent();
            auto_serviceContext db = new auto_serviceContext();
            addService.ItemsSource = db.Services.ToList();
            addClient.ItemsSource = db.Clients.ToList();
        }

        private void btnSaveClientService_Click(object sender, RoutedEventArgs e)
        {
            using (auto_serviceContext db = new auto_serviceContext())
            {
                string date = addDate.SelectedDate.Value.Date.ToShortDateString();
                string time = addTime.Text;
                string datetime = date + " " + time;
                ClientService clientService = new ClientService {StartTime = DateTime.Parse(datetime), ClientId = clientid, ServiceId = serviceid };
                db.ClientServices.Add(clientService);
                db.SaveChanges();
            }
            Manager.MainFrame.Navigate(new admin_page());
        }

        private void addClient_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            clientid = ((sender as ComboBox).SelectedItem as Client).Id;
        }

        private void addService_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            serviceid = ((sender as ComboBox).SelectedItem as Service).Id;
        }
        
        public int clientid { get; set; }
        public int serviceid { get; set; }

    }
}   

      


    


           
        
    
        

      
