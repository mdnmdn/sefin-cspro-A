using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public class DocumentManager<T> where T:Documento
    {
        public int TotalSize { get; protected set; }

        Dictionary<string, T> _container = 
                            new Dictionary<string, T>();

        public void Add(T doc) {
            TotalSize += doc.Size;
            _container[doc.Id] = doc;
        }

        public void Remove(string id)
        {
            T doc = Get(id);
            //.. recupero doc
            TotalSize -= doc.Size;
        }

        public T Get(string id) {

            return _container[id]; 
        }
    }

    public class ExtendedDocumentManager<T> : DocumentManager<T> where T : Documento
    {

    }

    public class FatturaDocumentManager : DocumentManager<Fattura>
    {

    }
}
