using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.ApiTester
{
    public class AppContext
    {

        #region singleton
        private static AppContext _instance;

        public static AppContext Instance {
            get {
                return _instance ?? (_instance = new AppContext());
            }
        }
        #endregion


        internal AppTraceListener TraceListener { get; private set; }
        internal RunnerManager Runner { get; private set; }

        protected AppContext() {
            TraceListener = new AppTraceListener();
            Runner = new RunnerManager();
        }
    }
}
