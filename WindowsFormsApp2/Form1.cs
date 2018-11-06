using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using Tain.AntSim4;


namespace AntSim4GUI
{
    /// <summary>
    /// Oberfläche zum Start und Betrachtung der Simulation.
    /// </summary>
    public partial class Form1 : Form
    {
        private int[] simValues = new int[3];

        #region Properties

        #endregion

        #region Constructors
        /// <summary>
        /// Instanziiert Oberfläche
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }
        #endregion

        #region Events
        private void button1_Click(object sender, EventArgs e)
        {
            simValues[0] = Convert.ToInt32(numericUpDownFieldLength.Value);
            simValues[1] = Convert.ToInt32(numericUpDownBaseXPos.Value);
            simValues[2] = Convert.ToInt32(numericUpDownBaseYPos.Value);
            Simulation AntSimulation = new Simulation(simValues);

            // Abonnieren von SimRoundEnded
            AntSimulation.SimRoundEnded += (simRun, currentRoundNumber) => labelRoundNumber.Text = Convert.ToString(currentRoundNumber.RoundNumber);
            AntSimulation.SimRoundEnded += (simRun, currentRoundNumber) => labelMessageText.Text = Simulation.Message;

            AntSimulation.RunSimulation();
        }
        #endregion

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process.Start("simProtocol.txt");
        }
    }
}
