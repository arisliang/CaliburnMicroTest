using Caliburn.Micro;
using CaliburnMicroTest.WpfUi.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;

namespace CaliburnMicroTest.WpfUi.ViewModels
{
    public class AppViewModel : PropertyChangedBase, IHandle<ColorEvent>
    {
        #region fields and properties
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

        public bool CanIncrementCount
        {
            get
            {
                return Count < 100;
            }
        }

        public ColorViewModel ColorVM { get; private set; }

        private SolidColorBrush _ColorBrush = null;
        public SolidColorBrush ColorBrush
        {
            get
            {
                return _ColorBrush;
            }
            set
            {
                _ColorBrush = value;
                NotifyOfPropertyChange(() => ColorBrush);
            }
        }

        #endregion

        #region constructor
        [ImportingConstructor]
        public AppViewModel(ColorViewModel cvm, IEventAggregator events)
        {
            ColorVM = cvm;
            events.Subscribe(this);
        }

        #endregion

        #region public methods
        public void IncrementCount()
        {
            Count++;
        }

        public void IncrementCount(int delta)
        {
            Count += delta;
        }

        #endregion

        #region IHandle
        public void Handle(ColorEvent message)
        {
            ColorBrush = message.ColorBrush;
        }

        #endregion
    }
}
