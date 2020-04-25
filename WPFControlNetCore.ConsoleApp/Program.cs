using System;
using System.Threading;
using System.Windows;
using WpfControlNetCore;

namespace WPFControlNetCore.ConsoleApp
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            Application app = new Application();
            var netCoreWPFWindow = new NetCoreWPFWindow();
            netCoreWPFWindow.MyButtonText = System.Environment.GetEnvironmentVariable("MyButtonText");
            app.Run(netCoreWPFWindow);
            Console.WriteLine(netCoreWPFWindow.MyButtonText);
        }
    }
}
