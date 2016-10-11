using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay.ButtonPlay
{
    public class FakeButton
    {
        private string _title;

        public event EventHandler Click;

        public FakeButton(string title)
        {
            this._title = title;
        }

        private void UtentePremeIlBottone() {
            if(Click != null)
            {
                Click(this, new EventArgs());
            }
        }

    }
}
