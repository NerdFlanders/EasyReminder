using EasyReminder.Infrastructure;
using EasyReminder.Model;
using EasyReminder.ViewModel.Styles;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace EasyReminder.ViewModel
{
    public class ReminderListViewModel : BaseFodyObservable, IViewModelBase
    {
        private readonly ISaveInteractor _saveInteractor;
        private ObservableCollection<Reminder> _reminders;

        public event PropertyChangedEventHandler PropertyChanged;
        public string BACKGROUND_COLOR => GlobalStyles.BACKGROUND_COLOR;
        public string PRIMARY_COLOR => GlobalStyles.PRIMARY_COLOR;
        public string TEXT_COLOR => GlobalStyles.TEXT_COLOR;
        public string Title => "Reminders";
        public ILookup<string, Reminder> ReminderList { get; set; }


        public ReminderListViewModel(ISaveInteractor saveInteractor)
        {
            _saveInteractor = saveInteractor;
            GetRemindersAsync();
        }

        private ILookup<string, Reminder> OrderReminders(ObservableCollection<Reminder> reminders)
        {
            return reminders.OrderBy(r => r.Active).ToLookup(r => r.Active ? "Completed" : "Active");
        }

        private async void GetRemindersAsync()
        {
            _reminders = await _saveInteractor.GetReminder();
            ReminderList = OrderReminders(_reminders);
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
