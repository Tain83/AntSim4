namespace Tain.AntSim4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Beschreibt ein Volk einer Tierart
    /// </summary>
    public class Nation 
    {
        #region Fields
        int nationId;
        Species ownSpecies;
        string name;
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public int NationId
        {
            get { return nationId; }
        }

        #region Properties
        public Species OwnSpecies
        {
            get { return ownSpecies; }
        }
        #endregion

        #endregion

        #region Constructors
        /// <summary>
        /// Instanziiert ein Volk
        /// </summary>
        public Nation(string name, Species ownSpecies, int baseXPos, int baseYPos)
        {
            this.name = name;
            this.ownSpecies = ownSpecies;
            this.nationId = Simulation.NextNationIndex;

            if (Convert.ToInt32(Simulation.SimField.GetValue(baseXPos, baseYPos)) == 0)
            {
                Simulation.SimObjects.Add(new Base(this, baseXPos, baseYPos));
            }
        }
        #endregion
    }
}
