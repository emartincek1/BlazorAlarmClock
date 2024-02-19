using System.Text.Json.Serialization;

namespace BlazorAlarmClock.Web.Models
{
    public class Alarm
    {
        public Alarm(int hour, int minute, int second)
        {
            Time = new DateTime(DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, hour, minute, second);
            Enabled = true;
        }

        [JsonConstructor]
        public Alarm() {}

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
            get; set;
        }
        public void ReEnable()
        {
            Enabled = true;
            Time = Time.AddDays(1);
        }

    }
}
