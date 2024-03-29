﻿using EasyReminder.Model;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace EasyReminder.Infrastructure
{
    public interface ISaveInteractor
    {
        void SaveReminder(Reminder reminder);
        Task<ObservableCollection<Reminder>> GetReminder();
    }
}