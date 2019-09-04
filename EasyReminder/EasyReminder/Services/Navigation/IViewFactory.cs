using EasyReminder.ViewModel;
using Xamarin.Forms;

namespace EasyReminder.Services.Navigation
{
    public interface IViewFactory
    {
        void Register<TViewModel, TView>() where TViewModel : class, IViewModelBase where TView : Page;
        Page Resolve<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}
