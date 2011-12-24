using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace FlashInterfaceViewer
{
    public partial class JsonPanel : Component
    {
        public JsonPanel()
        {
            InitializeComponent();
        }

        public JsonPanel(IContainer container)
        {
            container.Add(this);

            InitializeComponent();
        }
    }
}
