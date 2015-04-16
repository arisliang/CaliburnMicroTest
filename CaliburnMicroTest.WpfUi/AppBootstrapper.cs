using Caliburn.Micro;
using CaliburnMicroTest.WpfUi.ViewModels;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CaliburnMicroTest.WpfUi
{
    public class AppBootstrapper : BootstrapperBase
    {
        #region fields and properties
        private IKernel _Kernel = null;

        #endregion

        #region constructor
        public AppBootstrapper()
        {
            Initialize();
        }

        #endregion

        #region overrides
        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            base.OnStartup(sender, e);

            DisplayRootViewFor<AppViewModel>();
        }

        protected override void Configure()
        {
            _Kernel = new StandardKernel();

            _Kernel.Bind<IWindowManager>().To<CustomWindowManager>().InSingletonScope();
            _Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
        }

        protected override void OnExit(object sender, EventArgs e)
        {
            _Kernel.Dispose();
            base.OnExit(sender, e);
        }

        protected override object GetInstance(Type service, string key)
        {
            if (service == null) throw new ArgumentNullException("service type cannot be null");

            return _Kernel.Get(service);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            if (service == null) throw new ArgumentNullException("service type cannot be null");

            return _Kernel.GetAll(service);
        }

        protected override void BuildUp(object instance)
        {
            _Kernel.Inject(instance);
        }

        #endregion
    }
}
