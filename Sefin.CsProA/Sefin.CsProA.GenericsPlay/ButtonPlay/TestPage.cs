using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sefin.CsProA.GenericsPlay.ButtonPlay
{
    public class TestPage
    {

        FakeButton _btn;

        void InitControls() {
            _btn = new FakeButton("Clicca qui");

            _btn.Click += Button_Click;

            _btn.Click += new EventHandler(Button_Click);

            //Controls.Add(_btn);


        }

        void Button_Click(object sender, EventArgs e) {
            // Fai cose alla pressione
        }

    }
}
