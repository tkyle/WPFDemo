namespace WPFDemo.UI {
    using System;
    using System.Collections.Generic;
    using Caliburn.Micro;
    using WPFDemo.UI.Interfaces;
    using WPFDemo.UI.ViewModels;

    public class AppBootstrapper : BootstrapperBase
    {
        SimpleContainer container;

        public AppBootstrapper()
        {
            Initialize();
        }

        protected override void Configure()
        {

            container = new SimpleContainer();

            container.Singleton<IWindowManager, WindowManager>();
            container.Singleton<IEventAggregator, EventAggregator>();
            container.Singleton<IShellView, ShellViewModel>();
            container.PerRequest<IEmployeeListView, EmployeeListViewModel>();
            container.PerRequest<IEmployeeInfoView, EmployeeInfoViewModel>();

            //container.PerRequest<IEmployeeRepository, EmployeeRepository>();        
        }

        protected override object GetInstance(Type service, string key)
        {
            return container.GetInstance(service, key);
        }

        protected override IEnumerable<object> GetAllInstances(Type service)
        {
            return container.GetAllInstances(service);
        }

        protected override void BuildUp(object instance)
        {
            container.BuildUp(instance);
        }

        protected override void OnStartup(object sender, System.Windows.StartupEventArgs e)
        {
            DisplayRootViewFor<IShellView>();
        }
    }
}