using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.LinqPlay
{
    [Category("test")]
    public class ExceptionPlay
    {
        public void Exception1() {

            try
            {
                MetodoCheFaCose();

                //throw new Exception("sdfasfsadf");

            }
            catch (Exception ex) {
                // LOG -> 

                throw;

                throw new Exception("errore in exception1",ex);

                Console.WriteLine(ex.Message);


                Console.WriteLine(ex.ToString());
            }


            try
            {
                MetodoCheFaCose();
            }
            catch 
            {
                // LOG -> 
                //throw;
            }

        }

        private void MetodoCheFaCose()
        {
            if (!File.Exists("ss")) {
                throw new Exception("errore lettura file: dddd");
            }
            throw new NotImplementedException();
        }

        /// <summary>
        /// ritorna 0 se la lettura va a buon fine 1 se c'è un errore
        /// </summary>
        /// <returns></returns>
        public int LeggiFile() {
            return 0;

            throw new SefinBaseException("asefasdfas");
        }





        public class SefinBaseException:Exception{

            public Guid UniqueId { get; protected set; }

            public SefinBaseException(string message, Exception innerException = null) :
                    base(message, innerException)
            {
                var sefinInner = innerException as SefinBaseException;
                if (sefinInner != null)
                    UniqueId = sefinInner.UniqueId;
                else
                    UniqueId = Guid.NewGuid();

            }


            public override string ToString()
            {
                return $"Exception: {UniqueId}" + base.ToString();
            }

        }


        public class SefinPublicException: SefinBaseException{

            public string PublicMessage { get; private set; }

            public SefinPublicException(string message, string publicMessage, Exception innerException):
                    base(message,innerException) {

                PublicMessage = publicMessage;
            }

        }

    }
}
