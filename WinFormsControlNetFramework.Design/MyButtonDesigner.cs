using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.ComponentModel.Design;

namespace WinFormsControlNetFramework.Design
{
    public class ButtonWithDesignTimeDesigner : System.Windows.Forms.Design.ControlDesigner
    {
        private DesignerActionListCollection _actionLists;

        public override DesignerActionListCollection ActionLists
        {
            get
            {
                if (null == _actionLists)
                {
                    _actionLists = new DesignerActionListCollection();
                    _actionLists.Add(new ButtonWithDesignTimeActionList(this.Component));
                }
                return _actionLists;
            }
        }

        public class ButtonWithDesignTimeActionList : System.ComponentModel.Design.DesignerActionList
        {
            MyButton _myButton;

            private DesignerActionUIService _designerActionUISvc = null;

            //The constructor associates the control with the smart tag list.
            public ButtonWithDesignTimeActionList(IComponent component)
                : base(component)
            {
                _myButton = component as MyButton;

                // Cache a reference to DesignerActionUIService, 
                // so the DesigneractionList can be refreshed.
                _designerActionUISvc = GetService(typeof(DesignerActionUIService))
            as DesignerActionUIService;
            }

            public override DesignerActionItemCollection GetSortedActionItems()
            {
                DesignerActionItemCollection items = new DesignerActionItemCollection();
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundRed",
                    "Red Background",
                    "BackgroundColor",
                    "",
                    true));
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundWhite",
                    "White Background",
                    "BackgroundColor",
                    "",
                    true));
                items.Add(new DesignerActionMethodItem(
                    this,
                    "SetBackgroundBlue",
                    "Blue Background",
                    "BackgroundColor",
                    "",
                    true));
                return items;
            }

            public void SetBackgroundRed()
            {
                _myButton.BackColor = System.Drawing.Color.Red;
            }

            public void SetBackgroundWhite()
            {
                _myButton.BackColor = System.Drawing.Color.White;
            }

            public void SetBackgroundBlue()
            {

                _myButton.BackColor = System.Drawing.Color.Green;
            }
        }
    }
}
