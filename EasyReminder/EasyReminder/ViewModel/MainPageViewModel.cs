using Autofac;
using EasyReminder.Infrastructure;
using EasyReminder.Model;
using EasyReminder.Services.Navigation;
using EasyReminder.View;
using System;
using System.ComponentModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace EasyReminder.ViewModel
{
    public class MainPageViewModel : BaseViewModel
    {
        #region Private Properties
        private readonly ISaveInteractor _saveInteractor;
        private string _reminderText;
        private DateTime _date;
        private TimeSpan _time;
        private readonly INavigator _navigator;
        #endregion

        #region Public Properties
        public event PropertyChangedEventHandler PropertyChanged;
        public string PageTitle => "Create Reminder";
        public ICommand SaveReminder { get; set; }
        public ICommand NavigateToReminderList { get; set; }
        #endregion

        public MainPageViewModel(ISaveInteractor saveInteractor, INavigator navigator)
        {
            _navigator = navigator;
            _saveInteractor = saveInteractor;
            SaveReminder = new Command(OnSaveReminder);
            NavigateToReminderList = new Command(OnNavigateToReminderList);
        }

        public string ReminderText
        {
            set
            {
                if (_reminderText != value && value != "")
                {
                    _reminderText = value;
                    OnPropertyChanged(nameof(ReminderText));
                }
            }
            get
            {
                return _reminderText;
            }
        }

        public DateTime Date
        {
            set
            {
                if (_date != value)
                {
                    _date = value;
                }
            }
            get
            {
                return _date;
            }
        }

        public TimeSpan Time
        {
            set
            {
                if (_time != value)
                {
                    _time = value;
                }
            }
            get
            {
                return _time;
            }
        }

        private void OnSaveReminder(object parameter)
        {
            Reminder reminder = new Reminder
            {
                Text = ReminderText,
                AlertTime = Date + Time
            };
            _saveInteractor.SaveReminder(reminder);
        }

        public void OnNavigateToReminderList(object parameter)
        {
            _navigator.PushAsync<ReminderListViewModel>();
        }

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
