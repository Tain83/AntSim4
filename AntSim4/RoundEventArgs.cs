using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tain.AntSim4
{
    /// <summary>
    /// Liefert Rundennummer als EventArgs für Event SimRoundEnded
    /// </summary>
    public class RoundEventArgs : EventArgs
    {
        #region Fields
        int roundNumber;
        #endregion

        #region Properties
        /// <summary>
        /// Gibt die aktuelle Rundenummer wider
        /// </summary>
        public int RoundNumber
        {
            get { return roundNumber; }
        }

        #endregion

        #region Constructors
        /// <summary>
        /// Instanziiert RoundEventArgs mit int 
        /// </summary>
        public RoundEventArgs(int roundNumber)
        {
            this.roundNumber = roundNumber;
        }
        #endregion

    }
}
