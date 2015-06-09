using System;
using System.Collections.Generic;
using System.Diagnostics;
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

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Process myProcess = new Process();

        public MainWindow()
        {
            InitializeComponent();
            myProcess.StartInfo.FileName = "calc.exe";
        }

        private void Button_Open(object sender, RoutedEventArgs e)
        {
            myProcess.Start();
            //     myProcess.EnableRaisingEvents = true;
            //     myProcess.Exited += new EventHandler(myProcess_Exited);
        }

        private void Button_Close(object sender, RoutedEventArgs e)
        {
            try
            {
                myProcess.CloseMainWindow();
                myProcess.Close();
            }
            catch (Exception) { }
        }
        private void Button_Check(object sender, RoutedEventArgs e)
        {
            try
            {
                if (!myProcess.HasExited)
                    MessageBox.Show("Open");
            }
            catch (Exception)
            {
                MessageBox.Show("Close");
            }

        }

        private void myProcess_Exited(object sender, System.EventArgs e)
        {
            MessageBox.Show("Close");
        }

        private void Button_CloseAll(object sender, RoutedEventArgs e)
        {
            Process[] AllProcess = Process.GetProcesses();
            for (int i = 0; i < AllProcess.Length; i++)
                if (AllProcess[i] != Process.GetCurrentProcess())
                {
                    AllProcess[i].CloseMainWindow();
                    AllProcess[i].Close();
                }
        }
    }
}
