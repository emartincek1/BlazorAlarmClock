namespace BlazorAlarmClock.Web.Models
{
    public class AlarmClock
    {
        private List<Alarm> alarms = new List<Alarm>();

        private DateTime time = DateTime.Now;

        private Timer timer;

        public AlarmClock() 
        {
            timer = new System.Threading.Timer(async _ =>
            {
                Time = DateTime.Now;
                isAlarm();
            }, null, 0, 1000);
        }

        public bool ActiveAlarm => Alarms.Any(A => A.IsActive);

        public List<Alarm> Alarms 
        {
            get => alarms;
        }

        public DateTime Time
        {
            get => time;
            private set => time = value;
        }


        private void isAlarm()
        {
            foreach (var alarm in alarms) 
            {
                if (alarm.Enabled == true)
                {
                    if (DateTime.Compare(alarm.Time, Time) <= 0)
                    {
                        alarm.IsActive = true;
                        alarm.Enabled = false;
                        break;
                    }
                }
            }
        }

        public void AddAlarm(Alarm newAlarm)
        {
            alarms.Add(newAlarm);
        }

        public void AcknowledgeAlarm()
        {
            foreach (var alarm in alarms)
            {
                alarm.IsActive = false;
            }
        }

    }
}
