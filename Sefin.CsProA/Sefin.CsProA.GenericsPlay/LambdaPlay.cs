using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public delegate int Calcola(int a, int b);
    delegate void FaiCose();
    delegate void FaiCoseConArgomento(string val);

    public delegate string NumberConverter(int num);

    public delegate TResult MdnFunc<TResult>();
    public delegate TResult MdnFunc<TArg1, TResult>(TArg1 arg1);
    public delegate TResult MdnFunc<TArg1,TArg2, TResult>(TArg1 arg1, TArg2 arg2);

    [Category("test")]
    public class LambdaPlay
    {

        public void Intro()
        {
            Calcola f = Somma;
            var result = f(2, 3);

            Calcola f1 = (a, b) => a + b;

            // Errore
            //Calcola f2 = (a, b) => (a + b).ToString();

            result = f1(5, 8);

            Trace.WriteLine("Somma: " + result);

            Func<int, int> Raddoppia = num => num * 2;

            FaiCose fc = () => Trace.WriteLine("faccio cose");


            var anno = 2016;

            Func<int,int,DateTime>  calcolaData = 
                    (mese, giorno) => new DateTime(anno, mese, giorno);


            fc = () =>
            {
                var now = DateTime.Now;
                var text = now.ToLongDateString();
                Trace.WriteLine($"sono le: {text}");
            };

            fc();

            Calcola calcoloComplesso = (val1, val2) =>
            {
                if (val2 != 0) return val1 / val2;
                return 0;
            };


            FaiCoseConArgomento stampa = a => Trace.WriteLine("> " + a);


            Func<int, string> c = num => num.ToString();

            NumberConverter nc = num => num.ToString();
        }


        public void Sort()
        {
            List<Documento> docs = new List<Documento> {
                new Documento { Id = "123", Nome = "Fattura 234" },
                new Documento { Id = "789", Nome = "Bolla xxxx" },
                new Documento { Id = "345", Nome = "Fattura 10" }
            };

            Trace.WriteLine("Originale");
            Trace.WriteLine(String.Join(", ", docs));


            docs.Sort(OrdinaDocPerId);

            Trace.WriteLine("Ordino per id");
            Trace.WriteLine(String.Join(", ", docs));

            docs.Sort(OrdinaDocPerNome);

            Trace.WriteLine("Ordino per nome");
            Trace.WriteLine(String.Join(", ", docs));

            Comparison<Documento> comparatorePerNome =
                        (doc1, doc2) => doc2.Nome.CompareTo(doc1.Nome);
            
            docs.Sort(comparatorePerNome);


            docs.Sort((doc1, doc2) => doc2.Nome.CompareTo(doc1.Nome));

            Trace.WriteLine("Ordino per nome inverso con lamda");
            Trace.WriteLine(String.Join(", ", docs));
        }


        public void ActionPlay() {

            Action actionSenzaParametri = () => Trace.WriteLine("Action Senza param");
            Action<int,string,bool> actionDa3 =
                (num, text, boolVal) => Trace.WriteLine($"3 params: {num},{text}, {boolVal}");

            actionDa3(34, "wow!", false);
            actionDa3 = FunzioneCon3Parametri;

            //EventHandler ev = (o, e) => "".ToString();
            //Action<object, EventArgs> ev2 = (o, e) => "".ToString();
        }

        void FunzioneCon3Parametri(int num, string val, bool altroVal) { }


        public void FunctionPlay()
        {
            Func<bool> sempreVero = () => true;
            Func<int, int, bool> controllaNumeriUguali =
                    (val1, val2) => val1 == val2;

            Func<int, int, bool> verificaSeDoppio =
                    (val1, val2) => val1 == (val2 * 2);

        }

        public void ClosurePlay() {

            int val = 5;

            Action processor = () => Trace.WriteLine("Stampo val: " + val);

            processor();

            Action[] actions = new Action[10];

            for (val = 0; val < 10; val++) {
                actions[val] = processor;
            }

            foreach (Action proc in actions) {
                proc();
            }

            // ---------------------

            for (val = 0; val < 10; val++)
            {
                var valore = val;
                actions[valore] = () => Trace.WriteLine("Stampo valore: " + valore);
            }

            foreach (Action proc in actions)
            {
                proc();
            }
        }

        int OrdinaDocPerId(Documento d1, Documento d2) {
            return d1.Id.CompareTo(d2.Id);
        }

        int OrdinaDocPerNome(Documento d1, Documento d2)
        {
            return d1.Nome.CompareTo(d2.Nome);
        }


        int Somma(int a, int b) {
            return a + b;
        }

        
    }
}
