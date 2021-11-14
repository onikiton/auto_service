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
    /// Логика взаимодействия для ClientEdit.xaml
    /// </summary>
    public partial class ClientEdit : Window
    {
        public ClientEdit(Client selectedItem)
        {
            SelectedItem = selectedItem;
            InitializeComponent();
            addFirstName.Text = SelectedItem.FirstName;
            addLastName.Text = SelectedItem.LastName;
            addPatronymic.Text = SelectedItem.Patronymic;
            addGenderCode.Text = SelectedItem.GenderCode;
            addBirthday.SelectedDate = SelectedItem.Birthday;
            addRegistrationDate.SelectedDate = SelectedItem.RegistrationDate;
            addEmail.Text = SelectedItem.Email;
            addPhone.Text = SelectedItem.Phone;
        }

        public Client SelectedItem { get; set; }

        private void btnSaveClient_Click(object sender, RoutedEventArgs e)
        {
            using (auto_serviceContext db = new auto_serviceContext())
            {
                try
                {
                    SelectedItem.FirstName = addFirstName.Text;
                    SelectedItem.LastName = addLastName.Text;
                    SelectedItem.Patronymic = addPatronymic.Text;
                    SelectedItem.GenderCode = addGenderCode.Text;
                    SelectedItem.Birthday = (DateTime)addBirthday.SelectedDate;
                    SelectedItem.RegistrationDate = (DateTime)addRegistrationDate.SelectedDate;
                    SelectedItem.Email = addEmail.Text;
                    SelectedItem.Phone = addPhone.Text;
                    db.Clients.Update(SelectedItem);
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
