using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.ApiTester
{
    class AppTraceListener : System.Diagnostics.TraceListener
    {
        DateTime _lastTimeStamp = DateTime.Now;

        bool _needTimestamp = true;

        public Action<string> Logger { get; set; }

        public override void Write(string message)
        {
            if (Logger == null) return;

            if (_needTimestamp)
            {
                var delta = DateTime.Now.Subtract(_lastTimeStamp);
                Logger(String.Format("{0:0.00}] ", delta.TotalMilliseconds / 1000));
            }
             Logger(message);

            _needTimestamp = false;
        }

        public override void WriteLine(string message)
        {
            Write(message + Environment.NewLine);

            _needTimestamp = true;
        }


        
    }
}
