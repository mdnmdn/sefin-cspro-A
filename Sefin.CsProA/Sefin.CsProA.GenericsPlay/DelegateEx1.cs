using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay
{
    class DelegateEx1
    {
        //TODO:
        delegate int Op(int val);

        public void Test()
        {
            int[] nums = { 1, 3, 56 };

            // TODO: 
            Op[] operazioni = {
        //        Doppio, Quadrato, Togli5
            };

         //   int[] results = ApplicaTrasformazioni(nums, operazioni);
        }

        int[] ApplicaTrasfomazoni(int[] vals, Op[] operations)
        {
            return vals;
        }

        int Doppio(int val) => val * 2;
    }
}
