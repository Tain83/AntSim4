namespace Tain.AntSim4
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    /// <summary>
    /// Beschreibt eine Spezies
    /// </summary>
    public class Species 
    {
        #region Fields
        private int speciesId;
        private string name;
        private int[] capabilities;     // [int speed, int rotationSpeed, int sigthDistance, int loadCapacity]
        #endregion

        #region Properties
        public string Name
        {
            get { return name; }
        }

        public int SpeciesId
        {
            get { return speciesId; }
        }
        /// <summary>
        /// Gibt die Fähigkeiten einer Tierart wider. (int speed, int rotationSpeed, int sigthDistance, int loadCapacity)
        /// </summary>
        public int[] Capabilities
        {
            get { return capabilities; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Instanziiert eine Tierart
        /// </summary>
        public Species(string name, int[] capabilities)
        {
            this.name = name;
            this.capabilities = capabilities;
            this.speciesId = Simulation.NextSpeciesIndex;
        }
        #endregion
    }
}
