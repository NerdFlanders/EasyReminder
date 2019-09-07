using EasyReminder.Model;
using SQLite;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;

namespace EasyReminder.Infrastructure
{
    class SaveToDevice : ISaveToDevice
    {
        private readonly SQLiteConnection _dbcon;

        public SaveToDevice()
        {
            string dbPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "reminders.db3");

            _dbcon = new SQLiteConnection(dbPath);
            _dbcon.CreateTable<Reminder>();
        }

        public bool SaveReminderToDevice(Reminder reminder)
        {            
            _dbcon.Insert(reminder);
            return true;
        }

        public ObservableCollection<Reminder> GetReminder()
        {
            var table = _dbcon.Table<Reminder>().ToList();
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

        public bool DeleteReminder(int id)
        {
            int rowCount = _dbcon.Delete<Reminder>(id);
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
                _dbcon.Insert(item);
            }
        }
    }
}
