using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public delegate void FunzioneSenzaParametri();

    public delegate int Operazione(int val1, int val2);


    public delegate int TrasformazioneInt(int val);
    public delegate double TrasformazioneDouble(double val);
    public delegate string TrasformazioneString(string val);

    public delegate T Trasformazione<T>(T val);

    class DelegatePlayGround
    {
        public void Intro() {

            Operazione[] ops = new Operazione[3];

            ops[0] = Somma;
            ops[1] = Sottrai;
            ops[2] = Moltiplica;

            var result = ops[2](50, 3);

            // -- dictionary ----

            Dictionary<TipoOperazione, Operazione> operazioni 
                    = new Dictionary<TipoOperazione, Operazione>();

            operazioni[TipoOperazione.Piu] = Somma;
            operazioni[TipoOperazione.Meno] = Sottrai;
            operazioni[TipoOperazione.Per] = Moltiplica;

            var res = operazioni[TipoOperazione.Meno](20, 5);

            int[] values = { 1, 2, 43, 6, 88, 2, 11 };

            var res2 = ApplicaOperazioni(values, Moltiplica);


            Trasformazione<string>[] trasformazioniStringhe = {
                Maiuscole, Minuscole, AggiungiChiocciola
            };

            Trasformazione<int>[] trasformazioniNumeriche = {
                Raddoppia, Quadrato
            };

            var resultNum = ApplicaTrasformazioni(5, trasformazioniNumeriche);

            // Esercizio =>
            //int[] risultati = ApplicaTrasformazioniSuArray(values, trasformazioniNumeriche);

        }

        T ApplicaTrasformazioni<T>(T valoreIniziale, Trasformazione<T>[] trasformazioni) {

            T result = valoreIniziale;
            foreach (var trasf in trasformazioni) {
                result = trasf(result);
            }
            return result;
        }

        


        public int Raddoppia(int val) => val * 2;
        public int Quadrato(int val) => val * val;


        public double Raddoppia(double val) => val * 2;

        public string Maiuscole(string txt) => txt.ToUpper();
        public string Minuscole(string txt) => txt.ToLower();

        public string AggiungiChiocciola(string txt) => "@" + txt;



        public int ApplicaOperazioni(int[] valori, Operazione op) {
            return 0;
        }



        int Somma(int a, int b) {
            return a + b;
        }

        int Sottrai(int val1, int val2)
        {
            return val1 - val2;
        }

        static int Moltiplica(int val1, int val2) => val1 * val2;

    }

    enum TipoOperazione {
        Piu,
        Meno,
        Per
    }
}
