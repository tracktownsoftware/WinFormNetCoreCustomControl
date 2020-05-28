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
        private MenuAction menuAction_ShowDesignTimeUI_v4;

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

            menuAction_ShowDesignTimeUI_v4 = new MenuAction("Show UI from XAML DependencyProperty - New Thread");
            menuAction_ShowDesignTimeUI_v4.Execute +=
                new EventHandler<MenuActionEventArgs>(Show_ShowDesignTimeUI_v4_Execute);

            // Set up the MenuGroup
            MenuGroup myMenuGroup = new MenuGroup("MyMenuGroup", "Custom background");
            myMenuGroup.HasDropDown = false;
            myMenuGroup.Items.Add(menuAction_ShowDesignTimeUI_v4);
            myMenuGroup.Items.Add(redBackgroundMenuAction);
            myMenuGroup.Items.Add(whiteBackgroundMenuAction);
            myMenuGroup.Items.Add(blueBackgroundMenuAction);
            this.Items.Add(myMenuGroup);
        }

        private void Show_ShowDesignTimeUI_v4_Execute(object sender, MenuActionEventArgs e)
        {
            var item = e.Selection.PrimarySelection;
            item.Properties["DependencyPropertyTrigger"].SetValue("Test New Thread");
            item.Properties["DependencyPropertyTrigger"].ClearValue();
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
