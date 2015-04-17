using Caliburn.Micro;
using CaliburnMicroTest.WpfUi.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace CaliburnMicroTest.WpfUi.ViewModels
{
    public class AppViewModel : Conductor<object>, IHandle<ColorEvent>
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

        #region dependencies
        private readonly IWindowManager _windowManager = null;

        #endregion

        #region constructor
        [ImportingConstructor]
        public AppViewModel(ColorViewModel cvm, IEventAggregator events, IWindowManager wm)
        {
            ColorVM = cvm;
            events.Subscribe(this);
            _windowManager = wm;
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

        public void OpenWindow()
        {
            dynamic settings = new ExpandoObject();
            settings.WindowStartupLocation = WindowStartupLocation.Manual;

            var vm = IoC.Get<AppViewModel>();
            _windowManager.ShowWindow(vm, null, settings);
        }

        public void ShowRedScreen()
        {
            var window = IoC.Get<RedViewModel>();
            ActivateItem(window);
        }

        public void ShowGreenScreen()
        {
            var window = IoC.Get<GreenViewModel>();
            ActivateItem(window);
        }

        public void ShowBlueScreen()
        {
            var window = IoC.Get<BlueViewModel>();
            ActivateItem(window);
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
