using EasyReminder.Model;
using SQLite;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace EasyReminder.Infrastructure
{
    class SaveToDevice : ISaveToDevice
    {
        private readonly SQLiteAsyncConnection _dbcon;

        public SaveToDevice()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "reminders.db3");

            _dbcon = new SQLiteAsyncConnection(dbPath);
            _dbcon.CreateTableAsync<Reminder>().Wait();
        }

        public async Task<bool> SaveReminderToDevice(Reminder reminder)
        {            
            int returnval = await _dbcon.InsertAsync(reminder);
            return returnval == 1;
        }

        public async Task<ObservableCollection<Reminder>> GetReminder()
        {
            var table = await _dbcon.Table<Reminder>().ToListAsync();
            ObservableCollection<Reminder> reminders = new ObservableCollection<Reminder>();

            if (table.Count == 0)
            {
                return reminders;
            }

            foreach (var item in table)
            {
                reminders.Add(item);
            }

            return reminders;
        }

        public async Task<bool> DeleteReminder(int id)
        {
            int rowCount = await _dbcon.DeleteAsync<Reminder>(id);
            return rowCount == 1 ? true : false;
        }

        public void SeedSamples()
        {
            ObservableCollection<Reminder> ReminderList = new ObservableCollection<Reminder>
            {
                new Reminder { Id = 0, Text = "Create First Todo", Active = true},
                new Reminder { Id = 1, Text = "Run a Marathon"},
                new Reminder { Id = 2, Text = "Create TodoXamarinForms blog post"},
            };

            foreach(var item in ReminderList)
            {
                _dbcon.InsertAsync(item);
            }
        }
    }
}
