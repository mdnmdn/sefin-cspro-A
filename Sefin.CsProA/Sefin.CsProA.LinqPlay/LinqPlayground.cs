using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;

namespace Sefin.CsProA.LinqPlay
{
    [Category("test")]
    public class LinqPlayground
    {
        public void Intro() {

            var strings = new String[] {
                "uno","due","tre","quattro"
            };

            Trace.WriteLine("Originali");
            LogValues(strings);


            var res1 = strings.Select(s => s);
            LogValues(res1);

            var res2 = strings.Select(s => s.Length);
            LogValues(res2);

            var res3 = strings.Select(s => s.ToUpper());
            LogValues(res3);

            var res4 = strings.Select(s => s.ToUpper())
                              .Select(s => "@" + s);
            LogValues(res4);

            var numbers = new int[] {
                10,7,1,2,3,4,5
            };

            Trace.WriteLine("Originali");
            LogValues(numbers);

            var power2 = numbers.Select(i => i * i);
            LogValues(power2);

            var dates = numbers.Select(i => new DateTime(2016, 10, i));
            LogValues(dates);

            var formattedDates = numbers.Select(i => new DateTime(2016, 10, i))
                                        .Select(d => d.ToString("dd/MM/yyyy"));

            //numbers.Select(i => {
            //    var date = new DateTime(2016, 10, i);
            //    var txt = date.ToString("dd/MM/yyyy");
            //    return txt;
            //});

            LogValues(formattedDates);


            // WHERE 
            var res5 = strings
                .Where(t => t.Length <= 3)
                .Select(s => s.ToUpper());
            LogValues(res5);

            var res6 = strings
               .Where(t => t.Length <= 3)
               .Where(t => t.Contains("e"));

            strings
               .Where(t => t.Length <= 3 && t.Contains("e"));

            LogValues(res6);

            var res7 = strings
               .Where(t => t.Length <= 3)
               .Where(t => t.Contains("e"))
               .Select(t => t.ToUpper())
               .OrderByDescending(t => t);

            LogValues(res7);


        }

        public void LinqSyntax()
        {
            var strings = new String[] {
                "uno","due","tre","quattro"
            };



            var res = from s in strings
                      where s.Length <= 3 && s.Contains("e")
                      select s.ToUpper();

            //var res7 = strings
            //   .Where(t => t.Length <= 3 && t.Contains("e"))
            //   .Select(t => t.ToUpper());
            LogValues(res);

            var res2 = from s in res
                       select "@" + s;

            LogValues(res2);

            var res3 = from s in strings
                       where s.Length <= 3 && s.Contains("e")
                       orderby s
                       select s.ToUpper();
            LogValues(res3);


            var res4 = from s in strings
                       where s.Length <= 3 && s.Contains("e")
                       orderby s descending
                       select s.ToUpper();
            LogValues(res4);
        }

        public void LinqSelectPlay()
        {
            var strings = new String[] {
                "uno","due","tre","quattro"
            };


            var res1 = strings.Select(s => new { Text = s, Length = s.Length });
            LogValues(res1);

            var v = new
            {
                A = 1,
                P = "pippo",
                C = res1
            };

            var num = v.P.Length;

            var res2 = strings
                        .Select(s => new {
                            Text = s,
                            Length = s.Length,
                            Upper = s.ToUpper()
                        })
                        .Where(t => t.Upper.Contains("E"))
                        .Where(t => t.Length > 3);
            LogValues(res1);

            var res3 = from s in strings
                       where s.ToUpper().Contains("E")
                       select new
                       {
                           Text = s,
                           s.Length,
                           Upper = s.ToUpper()
                       };

            //var res4 = from t in (from s in strings
            //                      where s.ToUpper().Contains("E")
            //                      select new
            //                      {
            //                          Text = s,
            //                          s.Length,
            //                          Upper = s.ToUpper()
            //                      })
            //           where t.Length > 5
            //           select t.Text;

            ;


            Trace.WriteLine("test esecuzione");

            var res4 = (from s in strings
                       where Log(s,"where").ToUpper().Contains("E") 
                       select new
                       {
                           Text = s,
                           Length = Log(s.Length,"select"),
                           Upper = s.ToUpper()
                       }).ToList();
            LogValues(res4);
            LogValues(res4);
            LogValues(res4);
            LogValues(res4);



        }
        static void LogValues<T>(IEnumerable<T> data) {

            Trace.WriteLine("[" + String.Join(", ", data) + "]");
        }

        static T Log<T>(T dato, string txt){
            Trace.WriteLine($"  {txt}> {dato}  ");
            return dato;
        }

    }
}
