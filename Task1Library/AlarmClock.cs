using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Task1Library
{
    public sealed class AlarmClockEventArgs : EventArgs
    {
        private readonly TimeSpan duration;

        public AlarmClockEventArgs(long timeInMilliseconds)
        {
            if (timeInMilliseconds < 0)
                throw new ArgumentOutOfRangeException("Time value should be positive");
            duration = TimeSpan.FromSeconds(timeInMilliseconds);
        }
        public TimeSpan Duration { get { return duration; } }
    }

    public class AlarmClockMenager
    {
        public event EventHandler<AlarmClockEventArgs> Alarm;

        protected virtual void OnAlarm(AlarmClockEventArgs eventArgs)
        {
            EventHandler<AlarmClockEventArgs> temp = Alarm;

            if (temp != null)
            {
                temp(this, eventArgs);
            }
        }

        public async void SetAlarmClock(int milliseconds)
        {
            await Task.Factory.StartNew(() => Thread.Sleep(milliseconds));
            OnAlarm(new AlarmClockEventArgs(milliseconds));
        }
    }

    public sealed class OnePeople
    {

        public void Register(AlarmClockMenager clockMenager)
        {
            clockMenager.Alarm += Msg;
        }
        public void Unregister(AlarmClockMenager clockMenager)
        {
            clockMenager.Alarm -= Msg;
        }

        private void Msg(Object sender, AlarmClockEventArgs eventArgs)
        {
            Console.WriteLine("Alarm clock rang for one people:");
            Console.WriteLine("Setted time is {0}", eventArgs.Duration.TotalMilliseconds/1000);
        }
    }

    public sealed class AnotherPeople
    {

        public void Register(AlarmClockMenager clockMenager)
        {
            clockMenager.Alarm += Msg;
        }

        public void Unregister(AlarmClockMenager clockMenager)
        {
            clockMenager.Alarm -= Msg;
        }

        private void Msg(Object sender, AlarmClockEventArgs eventArgs)
        {
            Console.WriteLine("Alarm clock rang for another people:");
            Console.WriteLine("Setted time is {0}", eventArgs.Duration.TotalMilliseconds/1000);
        }
    }
}
