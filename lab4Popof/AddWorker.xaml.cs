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

namespace lab4Popof
{
    /// <summary>
    /// Логика взаимодействия для AddWorker.xaml
    /// </summary>
    public partial class AddWorker : Window
    {
        public AddWorker()
        {
            InitializeComponent();
        }
        public int ID
        {
            get
            {
                return int.Parse(tbID.Text);
            }
            set
            {
                tbID.Text = value.ToString();
            }
        }
        public string? Name
        {
            get
            {
                return tbName.Text;
            }
            set
            {
                tbName.Text = value;
            }
        }
        public int YearOfEmployment
        {
            get
            {
                return int.Parse(tbYear.Text);
            }
            set
            {
                tbYear.Text = value.ToString();
            }
        }
        public int Position
        {
            get
            {
                return int.Parse(tbPosition.Text);
            }
            set
            {
                tbPosition.Text = value.ToString();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}

