﻿using Sefin.CsProA.EFPlay.NW;
using Sefin.CsProA.GenericsPlay;
using Sefin.CsProA.LinqPlay;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sefin.ApiTester
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            //HibernatingRhinos.Profiler.Appender.EntityFramework.EntityFrameworkProfiler.Initialize();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ApiTesterApp());
        }

        static void Init() {
            new Esercizio();
            new LinqPlayground();
            new NorthwindContext();
        }
    }
}
