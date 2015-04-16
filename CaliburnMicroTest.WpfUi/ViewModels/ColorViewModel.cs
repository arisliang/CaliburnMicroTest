using Caliburn.Micro;
using CaliburnMicroTest.WpfUi.Events;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.WpfUi.ViewModels
{
    public class ColorViewModel : PropertyChangedBase
    {
        private readonly IEventAggregator _events = null;

        [ImportingConstructor]
        public ColorViewModel(IEventAggregator events)
        {
            _events = events;
        }

        #region public methods
        public void Red()
        {
            _events.PublishOnUIThread(new ColorEvent(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Red)));
        }

        public void Green()
        {
            _events.PublishOnUIThread(new ColorEvent(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Green)));
        }

        public void Blue()
        {
            _events.PublishOnUIThread(new ColorEvent(new System.Windows.Media.SolidColorBrush(System.Windows.Media.Colors.Blue)));
        }

        #endregion
    }
}
