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
    /// Логика взаимодействия для AddClient.xaml
    /// </summary>
    public partial class AddClient : Window
    {
        public AddClient()
        {
            InitializeComponent();
        }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            using (auto_serviceContext db = new auto_serviceContext())
            {
                try
                {
                    Client newclient = new Client
                    {
                        FirstName = addFirstName.Text,
                        LastName = addLastName.Text,
                        Patronymic = addPatronymic.Text,
                        GenderCode = addGenderCode.Text,
                        Birthday = (DateTime)addBirthday.SelectedDate,
                        RegistrationDate = (DateTime)addRegistrationDate.SelectedDate,
                        Email = addEmail.Text,
                        Phone = addPhone.Text
                    };
                    db.Clients.Add(newclient);
                    db.SaveChanges();
                }

                catch
                {
                    MessageBox.Show("Поля заполнены неверно");
                }

            }
            Manager.MainFrame.Navigate(new admin_page());
        }
    }
}
