using EasyReminder.Infrastructure;
using EasyReminder.Model;
using EasyReminder.ViewModel.Styles;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace EasyReminder.ViewModel
{
    public class ReminderListViewModel : BaseFodyObservable, IViewModelBase
    {
        private readonly ISaveInteractor _saveInteractor;

        public event PropertyChangedEventHandler PropertyChanged;
        public string BACKGROUND_COLOR => GlobalStyles.BACKGROUND_COLOR;
        public string PRIMARY_COLOR => GlobalStyles.PRIMARY_COLOR;
        public string TEXT_COLOR => GlobalStyles.TEXT_COLOR;

        public ReminderListViewModel(ISaveInteractor saveInteractor)
        {
            _saveInteractor = saveInteractor;
        }

        public string Title => "Reminders";
        
        public ObservableCollection<Reminder> ReminderList 
        {
            get
            {
                return _saveInteractor.GetReminder();
            }
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
