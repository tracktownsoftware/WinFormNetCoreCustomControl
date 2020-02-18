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

namespace WpfControlNetCore
{
    public class ButtonWithDesignTime : Button
    {
        public static readonly DependencyProperty DesignTimeTriggerActionProperty = DependencyProperty.Register(
  "DesignTimeTriggerAction", typeof(string), typeof(ButtonWithDesignTime), new PropertyMetadata(""));

        static ButtonWithDesignTime()
        {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(ButtonWithDesignTime), new FrameworkPropertyMetadata(typeof(ButtonWithDesignTime)));
        }

        public string DesignTimeTriggerAction
        {
            get 
            {
                return (string)this.GetValue(DesignTimeTriggerActionProperty);
            }
            set 
            {
                if (value == "messagebox")
                {
                    this.SetValue(DesignTimeTriggerActionProperty, value);
                    // Hopefully show Visual Studio design-time UI using .Net Core.
                    MessageBox.Show(value, "Design-time");
                }
            }
        }
    }
}
