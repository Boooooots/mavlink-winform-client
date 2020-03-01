using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mavlinkWinformClient
{
    public class Publisher
    {
        public Publisher(string str)
        {
            this.myname = str;
        }

        private string myname;

        public event myTestDelegate OnChange;

        public delegate void myTestDelegate(string str);

        public void Raise()
        {
            OnChange(this.myname);
        }

    }
}
