using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WinFormsControlNetFramework;

namespace WinFormsControlNetFramework
{
    [Designer("WinFormsControlNetFramework.Design.MyButtonDesigner, WinFormsControlNetFramework.Design.dll")]
    public class MyButton : System.Windows.Forms.Button
    {
        public MyButton()
        {
        }
    }
}
