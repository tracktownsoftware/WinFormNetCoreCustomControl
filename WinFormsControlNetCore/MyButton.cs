using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.ComponentModel;

namespace WinFormsControlNetCore
{
#if RELEASEDESIGN
    [Designer("WinFormsControlNetCore.Design.MyButtonDesigner, WinFormsControlNetCore.Design.dll")]
#endif
    public class MyButton: Button
    {
        public MyButton()
        {
        }
    }
}
