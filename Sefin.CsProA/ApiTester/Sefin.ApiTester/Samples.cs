using Sefin.ApiTester.Commons;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.ApiTester
{
    //public class SamplesNotSeen
    //{
    //    public void TestBoh() {
    //        Trace.Write("awefasd");
    //    }
    //}

    //public class SamplesViaInterface: ITestApi
    //{
    //    public void TestViaInterface()
    //    {
    //        Trace.Write("TestViaInterface");
    //    }

    //    [TestApi("Test itf with description")]
    //    public void TestViaInterfaceWithDescription()
    //    {
    //        Trace.Write("TestViaInterface");
    //    }
    //}

    [TestApi]
    public class SamplesViaAttribute
    {
        public void TestViaAttribute()
        {
            Trace.Write("TestViaInterface");
        }

        [TestApi("Test With attribute with description")]
        public void TestViaInterfaceWithDescription()
        {
            Trace.Write("TestViaInterface");
        }

        [TestApi("Exception")]
        public void ThrowException()
        {
            Trace.Write("running exception!");
            throw new Exception("Baaad!");
        }
    }
}
