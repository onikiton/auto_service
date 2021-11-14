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
    /// Логика взаимодействия для auntefication.xaml
    /// </summary>
    public partial class auntefication : Window
    {
        public auntefication()
        {
            InitializeComponent();
        }

        private void btnAuntOK_Click(object sender, RoutedEventArgs e)
        {

            this.DialogResult = true;
        }

        public string Password
        {
            get { return password.Text; }
        }

    }
}
