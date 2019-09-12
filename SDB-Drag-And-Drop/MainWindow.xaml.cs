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
using System.Diagnostics;

namespace SDB_Drag_And_Drop
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string sdbFile = "";

        public MainWindow()
        {

            InitializeComponent();
            if (App.Args == null || App.Args.Length == 0)
            {
                string[] files = System.IO.Directory.GetFiles(System.IO.Directory.GetCurrentDirectory());
                sdbFile = files.FirstOrDefault(x => x.ToLower().EndsWith(".sdb"));
                if(sdbFile == null)
                {
                    MessageBox.Show("You need to drag and drop an SDB file onto exe to use it or have it in directory with exe!", "Notification", MessageBoxButton.OK, MessageBoxImage.Information);
                    Environment.Exit(0);
                }
            }
            else
                sdbFile = string.Join(" ", App.Args);
        }

        private void B_Install_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = System.IO.Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "system32", "sdbinst.exe");
            proc.StartInfo.Arguments = "-q \"" + sdbFile + "\"";
            proc.StartInfo.RedirectStandardOutput = true;
            string output = "";
            proc.OutputDataReceived += (send, arg) =>
            {
                output += string.Join("\n", arg.Data) + "\n";
            };

            proc.StartInfo.UseShellExecute = false;
            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            MessageBox.Show(output, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }

        private void B_Uninstall_Click(object sender, RoutedEventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = System.IO.Path.Combine(Environment.GetEnvironmentVariable("SystemRoot"), "system32", "sdbinst.exe");
            proc.StartInfo.Arguments = "-q -u \"" + sdbFile + "\"";
            proc.StartInfo.RedirectStandardOutput = true;
            string output = "";
            proc.OutputDataReceived += (send, arg) =>
            {
                output += string.Join("\n", arg.Data) + "\n";
            };

            proc.StartInfo.UseShellExecute = false;

            proc.Start();
            proc.BeginOutputReadLine();
            proc.WaitForExit();
            MessageBox.Show(output, "Result", MessageBoxButton.OK, MessageBoxImage.Information);
            Environment.Exit(0);
        }
    }
}
