using Autofac;
using EasyReminder.Services.Navigation;
using EasyReminder.Startup.Modules;
using EasyReminder.View;
using EasyReminder.ViewModel;
using Xamarin.Forms;

namespace EasyReminder.Startup
{
    class Bootstrap
    {
        //public static IContainer Configure()
        //{
        //    var builder = new ContainerBuilder();

        //    builder.RegisterType<SaveInteractor>().As<ISaveInteractor>();
        //    builder.RegisterType<SaveToCloud>().As<ISaveToCloud>();
        //    builder.RegisterType<SaveToDevice>().As<ISaveToDevice>();

        //    builder.RegisterType<MainPageView>().SingleInstance();
        //    builder.RegisterType<ReminderListView>().SingleInstance();

        //    builder.RegisterType<MainPageViewModel>().SingleInstance();
        //    builder.RegisterType<ReminderListViewModel>().SingleInstance();



        //    return builder.Build();
        //}

        private readonly App _app;

        public Bootstrap(App app)
        {
            _app = app;
        }

        public void Run()
        {
            var builder = new ContainerBuilder();
            ConfigureContainer(builder);

            var container = builder.Build();

            var viewFactory = container.Resolve<IViewFactory>();
            RegisterViews(viewFactory);

            ConfigureApplication(container);
        }

        private void ConfigureApplication(IContainer container)
        {
            var viewFactory = container.Resolve<IViewFactory>();

            var mainPage = viewFactory.Resolve<MainPageViewModel>();
            var navPage = new NavigationPage(mainPage);

            _app.MainPage = navPage;
        }

        private void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule<DependencyRegistrationModule>();
            builder.RegisterModule<ViewModelViewRegistrationModule>();
        }

        private void RegisterViews(IViewFactory viewFactory)
        {
            viewFactory.Register<MainPageViewModel, MainPageView>();
            viewFactory.Register<ReminderListViewModel, ReminderListView>();
        }
    }
}
