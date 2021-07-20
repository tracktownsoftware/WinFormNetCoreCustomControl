using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.DesignTools.Extensibility;
using Microsoft.VisualStudio.DesignTools.Extensibility.Features;
using Microsoft.VisualStudio.DesignTools.Extensibility.Metadata;

// The ProvideMetadata assembly-level attribute indicates to designers
// that this assembly contains a class that provides an attribute table. 
[assembly: ProvideMetadata(typeof(WinFormsControlNetCore.DesignTools.RegisterMetaData))]

namespace WinFormsControlNetCore.DesignTools
{
    public class RegisterMetaData : IProvideAttributeTable
    {
        public AttributeTable AttributeTable
        {
            get
            {
                AttributeTableBuilder builder = new AttributeTableBuilder();

                // Show control in toolbox
                builder.AddCustomAttributes("WinFormsControlNetCore.MyButton", new ToolboxBrowsableAttribute(true));

                // Add the menu provider to the design-time metadata.
                builder.AddCustomAttributes(
                    "WinFormsControlNetCore.MyButton",
                    new FeatureAttribute(typeof(CustomContextMenuProvider)));

                return builder.CreateTable();
            }
        }
    }
}
