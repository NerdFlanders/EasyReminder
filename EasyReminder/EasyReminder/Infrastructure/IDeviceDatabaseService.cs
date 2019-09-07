using EasyReminder.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EasyReminder.Infrastructure
{
    interface ISaveToDevice
    {
        Task<bool> SaveReminderToDevice(Reminder reminder);
        Task<ObservableCollection<Reminder>> GetReminder();
    }
}