using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AntSim4GUI
{
    class ProtocolBox : TextBox
    {
        public string Message
        {
            set { Text = value; }
        }
    }
}
