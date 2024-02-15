using System;
using BlazorAlarmClock.Web.Models;

namespace BlazorAlarmClock.Test
{
    [TestClass]
    public class AlarmClockTests
    {
        [TestMethod]
        async public Task Clock_TracksTimeAndUpdates()
        {
            var clock = new AlarmClock();
            Assert.AreEqual(clock.Time.ToLongTimeString(), DateTime.Now.ToLongTimeString());
            await Task.Delay(2000);
            Assert.AreEqual(clock.Time.ToLongTimeString(), DateTime.Now.ToLongTimeString());
        }

        [TestMethod]
        public void Clock_AddAlarm()
        {
            var clock = new AlarmClock();
            Alarm alarm = clock.AddAlarm(DateTime.Now.Hour, DateTime.Now.Minute + 1, DateTime.Now.Second);
            List<Alarm> testList = new List<Alarm>();
            testList.Add(alarm);
            CollectionAssert.AreEquivalent(clock.Alarms, testList);
        }

        [TestMethod]
         async public Task Clock_ActiveAlarm()
        {
            var clock = new AlarmClock();
            Assert.AreEqual(false, clock.ActiveAlarm);
            clock.AddAlarm(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second + 1);
            await Task.Delay(2000);
            Assert.AreEqual(true, clock.ActiveAlarm);
        }

        [TestMethod]
        async public Task Clock_AcknowldgeAlarm()
        {
            var clock = new AlarmClock();
            clock.AddAlarm(DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second + 1);
            await Task.Delay(2000);
            clock.AcknowledgeAlarm();
            await Task.Delay(2000);
            Assert.AreEqual(false, clock.ActiveAlarm);
        }
    }
}