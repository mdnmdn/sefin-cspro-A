using Sefin.CsPro.Commons.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using System.Reflection;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Sefin.CsPro.Commons
{
    internal class DataFactory
    {
        public void Serialize<T>(string file, T data)
        {
            using (var fs = new FileStream(file, FileMode.Create))
            {
                var formatter = new BinaryFormatter();
                formatter.Serialize(fs, data);
            }
        }

        public T Deserialize<T>(string file)
        {
            using (var fs = new FileStream(file, FileMode.Open))
            {
                return Deserialize<T>(fs);
            }
        }

        public T Deserialize<T>(Stream stream)
        {
            var formatter = new BinaryFormatter();
            return (T)formatter.Deserialize(stream);
        }

        public NortwindData LoadNortwhind() {
            using (var stream = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + ".Assets.northwind.dat"))
                return Deserialize<NortwindData>(stream);
        }
    }
}
