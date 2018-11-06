using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tain.AntSim4
{
    public class SimObject
    {
        #region Fields
        protected int simObjectId;
        protected int objectXPos;
        protected int objectYPos;
        protected string type;
        protected int quantity;
        #endregion

        #region Properties
        public int SimObjectId
        {
            get { return simObjectId; }
        }

        public string Type
        {
            get { return type; }
        }

        public int ObjectXPos
        {
            get { return objectXPos; }
        }

        public int ObjectYPos
        {
            get { return objectYPos; }
        }
        #endregion

        #region Constructors
        public SimObject(int objectXPos, int objectYPos)
        {
            this.simObjectId = Simulation.NextSimObjectIndex;
            Simulation.SimField.SetValue(simObjectId, objectXPos, objectYPos);
        }
        #endregion
    }
}
