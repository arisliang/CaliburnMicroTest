using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.WpfUi
{
    public class CustomWindowManager : WindowManager
    {
        protected override System.Windows.Window EnsureWindow(object model, object view, bool isDialog)
        {
            var window = base.EnsureWindow(model, view, isDialog);
            window.SizeToContent = System.Windows.SizeToContent.Manual;

            return window;
        }
    }
}
