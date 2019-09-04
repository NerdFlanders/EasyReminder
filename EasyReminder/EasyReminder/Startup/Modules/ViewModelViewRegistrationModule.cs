using Autofac;
using EasyReminder.View;
using EasyReminder.ViewModel;

namespace EasyReminder.Startup.Modules
{
    public class ViewModelViewRegistrationModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<MainPageView>().SingleInstance();
            builder.RegisterType<MainPageViewModel>().SingleInstance();

            builder.RegisterType<ReminderListView>();
            builder.RegisterType<ReminderListViewModel>();
        }
    }
}
