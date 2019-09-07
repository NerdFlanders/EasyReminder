using System.Collections.ObjectModel;
using System.Threading.Tasks;
using EasyReminder.Model;

namespace EasyReminder.Infrastructure
{
    class SaveInteractor : ISaveInteractor
    {
        private readonly IDeviceDatabaseService _deviceDatabaseService;
        private readonly ISaveToCloud _saveToCloud;

        public SaveInteractor(IDeviceDatabaseService saveToDevice, ISaveToCloud saveToCloud)
        {
            _deviceDatabaseService = saveToDevice;
            _saveToCloud = saveToCloud;
        }

        public async Task<ObservableCollection<Reminder>> GetReminder()
        {
            return await _deviceDatabaseService.GetReminder();
        }

        public void SaveReminder(Reminder reminder)
        {
            _deviceDatabaseService.SaveReminderToDevice(reminder);
            _saveToCloud.SaveReminderToCloud();
        }
    }
}
