using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    public class Documento
    {
        public string Id { get; set; }

        public string Nome { get; set; }

        public int Size { get; set; }

        public DateTime Data { get; set; }
    }

    public class Bolla : Documento {
        public string Codice { get; set; }
    }

    public class Fattura : Documento
    {
        public int Anno { get; set; }
        public int Numero { get; set; }

    }

    public class FatturaInternazionale : Fattura {

    }
}
