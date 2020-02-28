using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FiratObs.CourseRegistrationChecker
{
    class TimerManager
    {

        private Timer _timer;
        private AutoResetEvent _autoResetEvent;
        private Action _action;

     

        public TimerManager(Action action)
        {
            _action = action;
            _autoResetEvent = new AutoResetEvent(true);
            _timer = new Timer(Execute, _autoResetEvent,1000 ,70000);
    
        }

     
        public void Execute(object stateInfo)
        {
            _action();

        }
    }
}
