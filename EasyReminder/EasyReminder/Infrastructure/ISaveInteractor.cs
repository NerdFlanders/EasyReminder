using EasyReminder.Model;
using System.Collections.ObjectModel;

namespace EasyReminder.Infrastructure
{
    public interface ISaveInteractor
    {
        void SaveReminder(Reminder reminder);
        ObservableCollection<Reminder> GetReminder();
    }
}