using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace EasyReminder.Model
{
    [Table("Reminders")]
    public class Reminder : BaseFodyObservable
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime AlertTime { get; set; }
        public bool Active { get; set; }
    }
}
