using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CaliburnMicroTest.WpfUi.Events
{
    public class ColorEvent
    {
        public SolidColorBrush ColorBrush { get; private set; }

        public ColorEvent(SolidColorBrush cb)
        {
            ColorBrush = cb;
        }
    }
}
