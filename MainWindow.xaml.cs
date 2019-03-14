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

namespace LaboratoryWork3
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime dt;
        TimeSpan ts;
        System.Windows.Threading.DispatcherTimer Timer;

        public Dictionary<string, DateTime> list = new Dictionary<string, DateTime>();

        public MainWindow()
        {
            InitializeComponent();
            Timer = new System.Windows.Threading.DispatcherTimer();
            Timer.Tick += new EventHandler(dispatcherTimer_Tick);
            Timer.Interval = new TimeSpan(0, 0, 1);
        }

        private void dispatcherTimer_Tick(object sender, EventArgs e)
        {


        }

            private void listBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            AddTimerWnd add_timer = new AddTimerWnd();
            if (add_timer.ShowDialog() == true)
            {
                dt = new DateTime(add_timer.clnd.SelectedDate.Value.Year, add_timer.clnd.SelectedDate.Value.Month, add_timer.clnd.SelectedDate.Value.Day, int.Parse(add_timer.tb_hour.Text), int.Parse(add_timer.tb_min.Text), int.Parse(add_timer.tb_sec.Text));
                listBox.Items.Add(add_timer.timerName.Text);
                list.Add(add_timer.timerName.Text, new DateTime(add_timer.clnd.SelectedDate.Value.Year, add_timer.clnd.SelectedDate.Value.Month, add_timer.clnd.SelectedDate.Value.Day, int.Parse(add_timer.tb_hour.Text), int.Parse(add_timer.tb_min.Text), int.Parse(add_timer.tb_sec.Text)));
            }
            else
            {

            }
        }

        private void bt_look_Click(object sender, RoutedEventArgs e)
        {
            string str = listBox.SelectedValue as string;
            ts = list[str] - DateTime.Now;
            MessageBox.Show("Дни:" + ts.Days + " Время: " + ts.Hours + ":" + ts.Minutes + ":" + ts.Seconds);
        }

        private void M1open_Click(object sender, RoutedEventArgs e)
        {
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();
            dlg.FileName = "Document";
            //  dlg.DefaultExt = ".txt"; 
            // dlg.Filter = "Text documents (.txt)|*.txt"; 
            dlg.ShowDialog();
            listBox.Items.Clear();

            string line;
            try
            {
                System.IO.StreamReader file = new System.IO.StreamReader(dlg.FileName);
                list.Clear();
                while ((line = file.ReadLine()) != null)
                {
                    string name = line;
                    line = file.ReadLine();

                    DateTime dt = DateTime.Parse(line);

                    list.Add(name, dt);
                    listBox.Items.Add(name);
                }
                file.Close();
                
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран :(");
            }
        }

        private void M1Save_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
                dlg.FileName = "Document";
                dlg.DefaultExt = ".txt";
                dlg.Filter = "Text documents (.txt)|*.txt";
                dlg.ShowDialog();

                using (System.IO.StreamWriter outputFile = new System.IO.StreamWriter(dlg.FileName))
                {
                    foreach (string line in listBox.Items)
                    {
                        outputFile.WriteLine(line.ToString());
                        DateTime d = list[line];
                        outputFile.WriteLine(d.ToString());


                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Не выбран :(");
            }
        }
    }
}
