using System;

namespace EasyReminder.Services
{
    public class TimeService : ITimeService
    {
        public DateTime GetDate => DateTime.Now;
        public TimeSpan GetTime => DateTime.Now.TimeOfDay;
    }
}
