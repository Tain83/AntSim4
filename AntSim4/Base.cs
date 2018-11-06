using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tain.AntSim4
{
    public class Base : SimObject
    {
        #region Fields
        Nation ownNation;
        #endregion

        #region Properties
        public Nation OwnNation
        {
            get { return ownNation; }
        }
        #endregion

        #region Constructors
        public Base(Nation ownNation, int objectXPos, int objectYPos)
          : base(objectXPos, objectYPos)
        {
            this.ownNation = ownNation;
            this.objectXPos = objectXPos;
            this.objectYPos = objectYPos;
            this.type = "Base";
            this.quantity = 0;
        }
        #endregion
    }
}
