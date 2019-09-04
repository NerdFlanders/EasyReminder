using EasyReminder.Model;
using System.Collections.ObjectModel;

namespace EasyReminder.Infrastructure
{
    interface ISaveToDevice
    {
        bool SaveReminderToDevice(Reminder reminder);
        ObservableCollection<Reminder> GetReminder();
    }
}