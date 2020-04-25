using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.DesignTools.Extensibility;
using Microsoft.VisualStudio.DesignTools.Extensibility.Interaction;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;
using Microsoft.VisualStudio.DesignTools.Extensibility.Model;

namespace WpfControlNetCore.DesignTools
{
    class CustomContextMenuProvider : PrimarySelectionContextMenuProvider
    {
        private MenuAction redBackgroundMenuAction;
        private MenuAction whiteBackgroundMenuAction;
        private MenuAction blueBackgroundMenuAction;
        private MenuAction dependencyPropertyTriggerMenuAction;
        private MenuAction messageBoxSUCCESSMenuAction;

        public CustomContextMenuProvider()
        {
            // Set up the MenuAction items
            redBackgroundMenuAction = new MenuAction("Red Background");
            redBackgroundMenuAction.Execute +=
                new EventHandler<MenuActionEventArgs>(RedBackground_Execute);

            whiteBackgroundMenuAction = new MenuAction("White Background");
            whiteBackgroundMenuAction.Execute +=
                new EventHandler<MenuActionEventArgs>(WhiteBackground_Execute);

            blueBackgroundMenuAction = new MenuAction("Blue Background");
            blueBackgroundMenuAction.Execute +=
                new EventHandler<MenuActionEventArgs>(BlueBackground_Execute);

            dependencyPropertyTriggerMenuAction = new MenuAction("FAIL-Show NetCore MyButton UI using trigger DependencyProperty");
            dependencyPropertyTriggerMenuAction.Execute +=
                new EventHandler<MenuActionEventArgs>(ShowNetCoreUI_v1_Execute);

            messageBoxSUCCESSMenuAction = new MenuAction("SUCCESS-Show NetCore MyButton UI using new process in designtools.dll");
            messageBoxSUCCESSMenuAction.Execute +=
                new EventHandler<MenuActionEventArgs>(ShowNetCoreUI_v2_Execute);

            // Set up the MenuGroup
            MenuGroup myMenuGroup = new MenuGroup("MyMenuGroup", "Custom background");
            myMenuGroup.HasDropDown = false;
            myMenuGroup.Items.Add(dependencyPropertyTriggerMenuAction);
            myMenuGroup.Items.Add(messageBoxSUCCESSMenuAction);
            myMenuGroup.Items.Add(redBackgroundMenuAction);
            myMenuGroup.Items.Add(whiteBackgroundMenuAction);
            myMenuGroup.Items.Add(blueBackgroundMenuAction);
            this.Items.Add(myMenuGroup);
        }

        private void ShowNetCoreUI_v1_Execute(object sender, MenuActionEventArgs e)
        {
            // FAILS - Show .Net Core UI at design-time by using a dependency property as a trigger.
            var item = e.Selection.PrimarySelection;
            item.Properties["DependencyPropertyTrigger"].SetValue("ShowNetCoreUI");
        }

        private void ShowNetCoreUI_v2_Execute(object sender, MenuActionEventArgs e)
        {
            // SUCCESS - Show .Net Core UI at design-time from a .Net Core console app launched in a 
            // new process from this .Net Framework WpfControlNetCore.DesignTools.dll assembly
            var item = e.Selection.PrimarySelection;
            ProcessStartInfo start = new ProcessStartInfo();
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            string exeFile = System.Reflection.Assembly.GetAssembly(this.GetType()).Location;
            exeFile = new System.IO.DirectoryInfo(exeFile).Parent.FullName + @"\WPFControlNetCore.ConsoleApp.exe";
            start.FileName = exeFile;

            // How to share data between processes? Using Envronment Variable here but 
            // is MemoryMappedFile better for larger data?
            start.EnvironmentVariables["MyButtonText"] = item.Properties["Content"].ComputedValue as string;
            start.RedirectStandardOutput = true; // set to true to read console app StandardOutput below

            using (Process process = Process.Start(start))
            {
                // Read resulting text from the NetCore console app process with the StreamReader
                using (System.IO.StreamReader reader = process.StandardOutput)
                {
                    string result = reader.ReadToEnd().TrimEnd('\r', '\n');
                    item.Properties["Content"].SetValue(result);
                }
            }
        }

        private void RedBackground_Execute(object sender, MenuActionEventArgs e)
        {
            var item = e.Selection.PrimarySelection;
            item.Properties["Background"].SetValue(System.Windows.Media.Brushes.Red);
        }

        private void WhiteBackground_Execute(object sender, MenuActionEventArgs e)
        {
            var item = e.Selection.PrimarySelection;
            item.Properties["Background"].SetValue(System.Windows.Media.Brushes.White);
        }

        private void BlueBackground_Execute(object sender, MenuActionEventArgs e)
        {
            var item = e.Selection.PrimarySelection;
            item.Properties["Background"].SetValue(System.Windows.Media.Brushes.Blue);
        }

    }
}
