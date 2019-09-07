using Autofac;
using EasyReminder.Infrastructure;
using EasyReminder.Services;
using EasyReminder.Services.Navigation;
using Xamarin.Forms;

namespace EasyReminder.Startup.Modules
{
    class DependencyRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<SaveInteractor>().As<ISaveInteractor>();
            builder.RegisterType<SaveToCloud>().As<ISaveToCloud>();
            builder.RegisterType<DeviceDatabaseService>().As<IDeviceDatabaseService>();
            builder.RegisterType<ViewFactory>().As<IViewFactory>().SingleInstance();
            builder.RegisterType<Navigator>().As<INavigator>().SingleInstance();
            builder.RegisterType<TimeService>().As<ITimeService>().SingleInstance();
            builder.Register<INavigation>(context => Application.Current.MainPage.Navigation).SingleInstance();
        }
    }
}
