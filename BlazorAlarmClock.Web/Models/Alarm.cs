﻿namespace BlazorAlarmClock.Web.Models
{
    public class Alarm
    {
        public Alarm(int hour, int minute, int second)
        {
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
        }

        public bool IsActive
        {
            get; set;
        }

        public bool Enabled
        {
            get; set;
        }

        public Guid Id { get; private set; } = Guid.NewGuid();

        public DateTime Time
        {
            get; private set;
        }

    }
}