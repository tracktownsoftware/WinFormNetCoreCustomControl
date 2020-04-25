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

namespace WpfNetCoreAppTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void myButton_Click(object sender, RoutedEventArgs e)
        {
            // This is a runtime test, not a test for VS2019 design-time extensibility

            //ProcessStartInfo start = new ProcessStartInfo();
            //start.UseShellExecute = false;
            //start.CreateNoWindow = true;
            //start.FileName = @"C:\Users\chris.000\source\repos\CustomControlDesignerTests\NetCore\bin\Release\netcoreapp3.1\WPFControlNetCore.ConsoleApp.exe";
            ////start.EnvironmentVariables["MyButtonText"] = item.Properties["Content"].Value.GetCurrentValue() as string;
            //start.EnvironmentVariables["MyButtonText"] = myButton.Content as string;

            //start.RedirectStandardOutput = true;

            //using (Process process = Process.Start(start))
            //{
            //    // Read in all the text from the process with the StreamReader.
            //    using (System.IO.StreamReader reader = process.StandardOutput)
            //    {
            //        string result = reader.ReadToEnd().TrimEnd('\r', '\n');
            //        myButton.Content = result;
            //    }
            //}

            //ProcessStartInfo start = new ProcessStartInfo();
            //start.UseShellExecute = false;
            //start.CreateNoWindow = false;
            //string exeFile = System.Reflection.Assembly.GetAssembly(this.GetType()).Location;
            //exeFile = new System.IO.DirectoryInfo(exeFile).Parent.FullName + @"\WPFControlNetCore.ConsoleApp.exe";
            //start.FileName = exeFile;

            //start.EnvironmentVariables["MyButtonText"] = this.myButton.Content as string;
            //start.RedirectStandardOutput = true; // set to true to read console app StandardOutput below

            //using (Process process = Process.Start(start))
            //{
            //    // Read resulting text from the NetCore console app process with the StreamReader
            //    using (System.IO.StreamReader reader = process.StandardOutput)
            //    {
            //        string result = reader.ReadToEnd().TrimEnd('\r', '\n');
            //        this.myButton.Content = result;
            //    }
            //}

            //ProcessStartInfo start = new ProcessStartInfo();
            //start.UseShellExecute = false;
            //start.CreateNoWindow = false;
            //start.FileName = @"C:\Windows\System32\cmd.exe";
            //Process.Start(start).WaitForExit();

            // Attempt #3 - Just try to launch browser window
            string url = @"https://www.cnn.com";
            //Process.Start(url); This doesn't work in .Net Core
            Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
        }
    }
}
