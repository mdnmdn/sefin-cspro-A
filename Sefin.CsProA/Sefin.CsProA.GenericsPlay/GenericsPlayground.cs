using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public class GenericsPlayground
    {
        public void Intro() {

            List<Cliente> elencoClienti = new List<Cliente>();

            //elencoClienti.Sort()

            elencoClienti.Add(new Cliente());

            var cl = elencoClienti[0];

            // arraylist

            ArrayList list = new ArrayList();
            list.Add(new Cliente());

            Cliente cl1 = (Cliente)list[0];

            // hastable
            var hashTable = new Hashtable();

            hashTable["pippo"] = new Cliente();
            hashTable[12] = new Cliente();

            hashTable[false] = 34;

            Cliente result = (Cliente) hashTable[12];

            // Dictionary
            Dictionary<string, Cliente> dict = new Dictionary<string, Cliente>();

            dict["pippo"] = new Cliente();
            dict["12"] = new Cliente();

            Cliente cl2 = dict["12"];

        }


        public void CustomListPlay() {
            var list = new CustomList<Cliente>();

            list.Add(new Cliente());

            list.Update(0, new Cliente());

            var documentList = new CustomList<TipoDocumento>();
            documentList.Add(new TipoDocumento());

            // WHERE T: Document => non si può usare int 
            //var numberList = new CustomList<int>();
            //numberList.Add(4);

        }

        public void CachePlay() {


            TipoDocumento d = CaricaDaCache<TipoDocumento>(7);

            Provincia p = CaricaDaCache<Provincia>(25);

        }

        private T CaricaDaCache<T>(int id)
        {
            throw new NotImplementedException();
        }

        //private object CaricaDaCache(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //private Provincia CaricaDaCache(int id)
        //{
        //    throw new NotImplementedException();
        //}

        //private TipoDocumento CaricaDaCache(int id)
        //{
        //    throw new NotImplementedException();
        //}


        public void DocumentManagerPlayground(){
            var manager = new DocumentManager<Fattura>();
            manager.Add(new Fattura());
            manager.Add(new FatturaInternazionale());

            var f = manager.Get("sdasdf");

        }


        public void ProcessaDocumento<T>(T doc) where T : Documento {
            var fattura = doc as Fattura;
            if (fattura != null) {
                // fai cose per la fattura
            }

            var bolla = doc as Bolla;
            if (bolla != null) {
                // fai cose per la bolla
            }
        }
    }

    //public interface IDocProcessor { }

    //public abstract class DocProcessor<T> : IDocProcessor where T : Documento { }

    //public class FatturaProcessor : DocProcessor<Fattura> { }
    //public class BollaProcessor : DocProcessor<Bolla> { }

    //public class ProcessorFactory
    //{
    //    Dictionary<Type, IDocProcessor> _processorRegistry;

    //    public DocProcessor<T> GetProcessor<T>() where T : Documento
    //    {
    //        return _processorRegistry[typeof(T)] as DocProcessor<T>;
    //    }

    //}

    public class Cliente { }
    public class TipoDocumento { }
    public class Provincia { }
}
