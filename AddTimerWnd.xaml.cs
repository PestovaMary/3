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

namespace LaboratoryWork3
{
    /// <summary>
    /// Логика взаимодействия для AddTimerWnd.xaml
    /// </summary>
    public partial class AddTimerWnd : Window
    {
        

        public AddTimerWnd()
        {
            InitializeComponent();
        }

        private void timerName_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_hour_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_min_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void tb_sec_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void bt1_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
            //try
            //{

            //}
            //catch
            //{
            //    this.DialogResult = false;
            //}
        }
    }
}
