using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    [Category("test")]
    public class ThreadPlay
    {
        public void Thread1() {

            //var thread = new Thread(...)

            Trace.WriteLine("--- start ----");

            for (int i = 1; i < 100; i++)
            {
                var num = i;
                ThreadPool.QueueUserWorkItem(_ =>
                {
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    Trace.WriteLine($"  {num}. Ciao sono partito {threadId}");
                    Thread.Sleep(1000);
                    Trace.WriteLine($"  {num}. ora ho finito {threadId}");
                });
            }

            

            Trace.WriteLine("--- end ----");
        }


        public void Thread2()
        {

            //var thread = new Thread(...)

            Trace.WriteLine("--- start ----");

            bool risorsaLibera = true;

            var lockObject = new object();
            var lockObject2 = new object();

            ThreadPool.QueueUserWorkItem(_ =>
            {
                var threadId = Thread.CurrentThread.ManagedThreadId;

                lock (lockObject)
                {
                    Trace.WriteLine($"  Ciao io faccio il calcolo sul db {threadId}");
                    Thread.Sleep(new Random().Next(1000) + 400);
                    Trace.WriteLine($"  calcolco su db finito {threadId}");

                }
                
            });

            ThreadPool.QueueUserWorkItem(_ =>
            {
                lock (lockObject)
                {
                    var threadId = Thread.CurrentThread.ManagedThreadId;
                    Trace.WriteLine($"  Ciao io chiamo il ws per i dati {threadId}");
                    Thread.Sleep(new Random().Next(1000) + 400);
                    Trace.WriteLine($"  ws su finito {threadId}");
                }
            });


            Thread.Sleep(200);

            Trace.WriteLine("--- end ----");
        }

        public void Task1() {


        }
    }
}
