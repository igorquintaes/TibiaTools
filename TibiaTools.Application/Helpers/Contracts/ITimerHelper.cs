using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace TibiaTools.Application.Helpers.Contracts
{
    public interface ITimerHelper
    {
        event Action<Timer, object> TimerEvent;

        void Start(
            int timerInterval, 
            bool triggerAtStart = false,
            object state = null);

        void Stop(
            TimeSpan? timeout = null);

        void Dispose();
    }
}
