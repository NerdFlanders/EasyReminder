using Autofac;
using EasyReminder.Startup;
using Xamarin.Forms;

namespace EasyReminder
{
    public partial class App : Application
    {
        public static IContainer Container;

        public App()
        {
            InitializeComponent();
            LoadTypes();
        }

        private void LoadTypes()
        {
            var bootstrapper = new Bootstrap(this);
            bootstrapper.Run();
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
