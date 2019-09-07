using System;

namespace EasyReminder.Services
{
    public interface ITimeService
    {
        DateTime GetDate { get; }
        TimeSpan GetTime { get; }
    }
}