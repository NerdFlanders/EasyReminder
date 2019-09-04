using EasyReminder.ViewModel;
using System.Threading.Tasks;

namespace EasyReminder.Services.Navigation
{
    public interface INavigator
    {
        Task PopAsync();
        Task PopToRootAsync();
        Task PushAsync<TViewModel>() where TViewModel : class, IViewModelBase;
        Task PushModalAsync<TViewModel>() where TViewModel : class, IViewModelBase;
    }
}
