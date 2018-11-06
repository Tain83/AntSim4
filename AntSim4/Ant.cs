namespace Tain.AntSim4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Beschreibt ein einzelnes Tier
    /// </summary>
    public class Ant : Animal
    {
        #region Fields
        Base homeBase;
        Nation ownNation;
        Species ownSpecies;
        int antID;
        #endregion

        #region Properties
        public int AntID
        {
            get { return antID; }
        }

        public Species OwnSpecies
        {
            get { return ownSpecies; }
        }

        public Nation OwnNation
        {
            get { return ownNation; }
        }
        #endregion

        #region Constructors     
        /// <summary>
        /// Instanziiert eine Ameise
        /// </summary>
        public Ant(Base homeBase) : base (homeBase)
        {
            this.homeBase = homeBase;
            ownNation = homeBase.OwnNation;
            ownSpecies = homeBase.OwnNation.OwnSpecies;
            
            this.xPos = homeBase.ObjectXPos;
            this.yPos = homeBase.ObjectYPos;
            antID = Simulation.NextAntIndex;

            Random random = new Random(Simulation.Ants.Count);
            direction = random.Next(0, 360);
            speed = ownSpecies.Capabilities[0];
            rotationSpeed = ownSpecies.Capabilities[1];
            sightDistance = ownSpecies.Capabilities[2];
        }
        #endregion
    }
}
