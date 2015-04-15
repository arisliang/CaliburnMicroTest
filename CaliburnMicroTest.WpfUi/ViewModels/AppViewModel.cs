using Caliburn.Micro;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.WpfUi.ViewModels
{
    public class AppViewModel : PropertyChangedBase
    {
        public int _count = 50;

        public int Count
        {
            get
            {
                return _count;
            }
            set
            {
                _count = value;
                NotifyOfPropertyChange(() => Count);
                NotifyOfPropertyChange(() => CanIncrementCount);
            }
        }

        public void IncrementCount()
        {
            Count++;
        }

        public void IncrementCount(int delta)
        {
            Count += delta;
        }

        public bool CanIncrementCount
        {
            get
            {
                return Count < 100;
            }
        }
    }
}
