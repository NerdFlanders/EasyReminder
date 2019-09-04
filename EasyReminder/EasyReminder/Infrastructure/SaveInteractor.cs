using System.Collections.ObjectModel;
using EasyReminder.Model;

namespace EasyReminder.Infrastructure
{
    class SaveInteractor : ISaveInteractor
    {
        private readonly ISaveToDevice _saveToDevice;
        private readonly ISaveToCloud _saveToCloud;

        public SaveInteractor(ISaveToDevice saveToDevice, ISaveToCloud saveToCloud)
        {
            _saveToDevice = saveToDevice;
            _saveToCloud = saveToCloud;
        }

        public ObservableCollection<Reminder> GetReminder()
        {
            return _saveToDevice.GetReminder();
        }

        public void SaveReminder(Reminder reminder)
        {
            _saveToDevice.SaveReminderToDevice(reminder);
            _saveToCloud.SaveReminderToCloud();
        }
    }
}
