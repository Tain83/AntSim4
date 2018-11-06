using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace Tain.AntSim4
{
    /// <summary>
    /// Verwaltet die Simulation.
    /// </summary>
    public class Simulation
    {
        #region Fields
        private static Simulation instance;
        private static int fieldLength;
        private static int baseXPos;
        private static int baseYPos;

        private static int[,] simField;
        private static int simObjectIndex = 0;
        private static List<SimObject> simObjects = new List<SimObject>();
        private static int speciesIndex = 0;
        private static List<Species> species = new List<Species>();
        private static int nationIndex = 0;
        private static List<Nation> nations = new List<Nation>();
        private static int antIndex = 0;
        private static List<Ant> ants = new List<Ant>();


        private static int roundNumber = 1;
        private static string message;

        /// <summary>
        /// Delegate für SimRundenEnde (SimRoundEnded)
        /// </summary>
        public delegate void RoundEndedEventHandler(Object SimulationRun, RoundEventArgs e);

        /// <summary>
        /// Dieser Event wird ausgelöst, wenn eine Simulationsrunde beendet ist.
        /// </summary>
        public event RoundEndedEventHandler SimRoundEnded;
        #endregion

        #region Constructors
        /// <summary>
        /// Instanziiert eine Simulation
        /// </summary>
        public Simulation(int[] simValues)
        {
            fieldLength = simValues[0];
            baseXPos = simValues[1];
            baseYPos = simValues[2];

            simField = new int[fieldLength, fieldLength];

            int[] tainsAntsCapabilities = new int[] { 4, 150, 8, 50 }; //HACK

            Species.Add(new Species("Tains Ants", tainsAntsCapabilities));
            Nations.Add(new Nation("First Nation", Species.Find(x => x.Name == "Tains Ants"), baseXPos, baseYPos));
            Nations.Add(new Nation("Second Nation", Species.Find(x => x.Name == "Tains Ants"), baseXPos+10, baseYPos+10));


            // Protokollausgabe der erzeugten Arten
            string speciesText = null;
            foreach (Species currentSpecies in Species)
            {
                speciesText = speciesText + $"{currentSpecies.SpeciesId}. {currentSpecies.Name};  ";
            }
            message = $"Species: {Species.Count}: {speciesText}" + System.Environment.NewLine;

            // Protokollausgabe der erzeugten Völker
            string nationsText = null;
            foreach (Nation currentNation in Nations)
            {
                nationsText = nationsText + $"{currentNation.NationId}. {currentNation.Name};  ";
            }
            message = message + $"Nations: {Nations.Count}: {nationsText}" + System.Environment.NewLine;

            // Protokollausgabe der erzeugten Objekte
            string simObjectText = null;
            foreach (SimObject currentObject in SimObjects)
            {
                simObjectText = simObjectText + $"{currentObject.SimObjectId}. {currentObject.Type}, {currentObject.ObjectXPos}, {currentObject.ObjectYPos};  ";
            }
            message = message + $"Bases:   {SimObjects.Count}: {simObjectText}" + System.Environment.NewLine;

            using (StreamWriter InitialProtocol = new StreamWriter("simProtocol.txt"))
            {
                InitialProtocol.Write(message);
            }
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gibt Spielfeldlänge wider.
        /// </summary>
        public static int FieldLength
        {
            get
            {
                if (fieldLength == 0)
                {
                    int[] randomSimValues = new int[] { 100, 50, 50 };
                    instance = new Simulation(randomSimValues);
                }
                return fieldLength;
            }
        }

        /// <summary>
        /// Gibt die nächste unbenutzte SpeciesID zur Tierart-Erzeugung wider.
        /// </summary>
        public static int NextSpeciesIndex
        {
            get
            {
                speciesIndex++;
                return speciesIndex;
            }
        }

        /// <summary>
        /// Gibt die Liste aktuell gültigen Tierarten wider.
        /// </summary>
        public static List<Species> Species
        {
            get
            {
                return species;
            }
        }

        /// <summary>
        /// Gibt die nächste unbenutzte NationID zur Volk-Erzeugung wider.
        /// </summary>
        public static int NextNationIndex
        {
            get
            {
                nationIndex++;
                return nationIndex;
            }
        }

        /// <summary>
        /// Gibt die Liste aktuell gültigen Völker wider.
        /// </summary>
        public static List<Nation> Nations
        {
            get
            {
                return nations;
            }
        }

        /// <summary>
        /// Gibt die nächste unbenutzte SimObjectID zur Objekterzeugung wider.
        /// </summary>
        public static int NextSimObjectIndex
        {
            get
            {
                simObjectIndex++;
                return simObjectIndex;
            }
        }

        /// <summary>
        /// Gibt die Liste aktuell gültigen SimObjekte wider.
        /// </summary>
        public static List<SimObject> SimObjects
        {
            get
            {
                return simObjects;
            }
        }

        /// <summary>
        /// Gibt oder setzt die Objekte des Spielfeldes
        /// </summary>
        public static int[,] SimField
        {
            get { return simField; }
            set { simField = value; }
        }

        /// <summary>
        /// Gibt die nächste unbenutzte AntID zur Ameisenerzeugung wider.
        /// </summary>
        public static int NextAntIndex
        {
            get
            {
                antIndex++;
                return antIndex;
            }
        }

        /// <summary>
        /// Gibt die Liste aktuell gültigen Ameisen wider.
        /// </summary>
        public static List<Ant> Ants
        {
            get
            {
                return ants;
            }
        }

        public static string Message
            {
                get
                {
                    return message;
                }
            }

        #endregion

        #region Methods
        public void RunSimulation()
        {

            foreach (Base antBase in simObjects)
            {
                    CreateAnt(antBase, 50);
            }

            for (int i = roundNumber; i < 200; i++)
            {
                // Protokollausgabe, Teil 1
                message = $"*********************" + System.Environment.NewLine + $" Round, {i}:" + System.Environment.NewLine;
                if (nations != null)
                {
                    nations.ForEach(x => message = message + $"{x.Name}:");
                }
                message = message + System.Environment.NewLine;

                // Ameisen agieren
                if (ants != null)
                {
                    foreach (Ant singleAnt in ants)
                    {
                        singleAnt.Walk(20);
                        message = message + $"{singleAnt.OwnSpecies.Name}, {singleAnt.OwnNation.Name}, {singleAnt.AntID}: {singleAnt.XPos}, {singleAnt.YPos}, {singleAnt.Direction}" + System.Environment.NewLine;
                    }
                }

                // Protokollausgabe, Teil 2
                using (StreamWriter RoundProtocol = new StreamWriter("simProtocol.txt", true))
                {
                    RoundProtocol.Write(message);
                }

                // Rundenende
                roundNumber = i;

                if (SimRoundEnded != null)
                {
                    SimRoundEnded(this, new RoundEventArgs(roundNumber));
                }
            }
        }

        private static void CreateAnt(Base homeBase)
        {
            ants.Add(new Ant(homeBase));
        }

        private static void CreateAnt(Base homeBase, int anzahl)
        {
            for (int i = 0; i < anzahl; i++)
            {
                ants.Add(new Ant(homeBase));
            }
        }


        #endregion
    }
    //    {

    //        // Initialisierung

    //        // Spielfeld und Base
    //        int[,,] field = new int[fieldLength, fieldLength, 2];
    //        Base Base1 = new Base(fieldLength / 2, fieldLength / 2);
    //        Console.Out.WriteLine("Position of Base1: {0}, {1}", Base1.Xpos, Base1.Ypos);

    //        // Zucker
    //        int[] sourcePos = new int[nmbrSugar * 2];
    //        for (int i = 0; i < sourcePos.Length; i++)
    //        {
    //            if (i == 0)
    //            {
    //                Random value = new Random(i);
    //                sourcePos[i] = value.Next(fieldLength);
    //            }
    //            else
    //            {
    //                Random value = new Random(sourcePos[i - 1]);
    //                sourcePos[i] = value.Next(fieldLength);
    //            }
    //        }
    //        TargetSugar[] Sugar = new TargetSugar[nmbrSugar];
    //        for (int i = 0; i < nmbrSugar; i++)
    //        {
    //            Sugar[i] = new TargetSugar(sourcePos[2 * i], sourcePos[2 * i + 1]);
    //            Console.Out.WriteLine("Position of Sugar: {0}, {1}", Sugar[i].Xpos, Sugar[i].Ypos);
    //        }

    //        // Start
    //        Console.Out.WriteLine("Simulation start:");
    //        Ant Ant1 = new Ant(Base1);
    //        Console.Out.WriteLine("Position of Ant1: {0}, {1}, {2}", Ant1.Xpos, Ant1.Ypos, Ant1.Direction);

    //        bool target = false;
    //        int walkCount = 0;

    //        for (int i = 1; i <= roundMax; i++)
    //        {
    //            if (Ant1.Load != 0)
    //            // wenn beladen
    //            {
    //                if (target == false)
    //                // und noch nicht am Ziel (Base)
    //                {
    //                    target = Ant1.GoTo(Base1.Xpos, Base1.Ypos, fieldLength);
    //                    if (target == true)
    //                    { Console.Out.WriteLine("Arrived at Base!"); }
    //                }
    //                else
    //                // und bereits am Ziel (Base)
    //                {
    //                    Base1.Sugar = Base1.Sugar + Ant1.Load;
    //                    Ant1.Load = 0;
    //                    target = false;
    //                }
    //            }
    //            else
    //            // wenn nicht beladen
    //            {
    //                if (target == false)
    //                // und noch nicht am Ziel (Zucker)  
    //                {
    //                    // suche nach Zucker
    //                    Target[] SugarTargets = Ant1.LookFor(Sugar, Config.FieldLength);

    //                    if (SugarTargets != null)
    //                    {
    //                        target = Ant1.GoToNext(SugarTargets, Config.FieldLength);
    //                        if (target == true)
    //                        { Console.Out.WriteLine("Arrived at Sugar!"); }
    //                        walkCount = 0;
    //                    }
    //                    else if (walkCount < 3)
    //                    {
    //                        Ant1.Walk(fieldLength, fieldLength);
    //                        walkCount++;
    //                    }
    //                    else
    //                    {
    //                        // Randomturn
    //                        Random random1 = new Random(i);
    //                        int angle = random1.Next(180);
    //                        Random random2 = new Random(angle);
    //                        int direction = random2.Next(2);
    //                        if (direction == 1)
    //                        { angle = -angle; }

    //                        Ant1.Turn(angle);
    //                        walkCount = 0;
    //                    }
    //                }
    //                else
    //                {
    //                    for (int s = 0; s < Sugar.Length; s++)
    //                    {
    //                        if (Sugar[s].Xpos == Ant1.Xpos && Sugar[s].Ypos == Ant1.Ypos)
    //                        { Sugar[s].Sugar = Sugar[s].Sugar - Ant1.CarryCapacity; }
    //                    }
    //                    Ant1.Load = Ant1.CarryCapacity;
    //                    target = false;
    //                }
    //            }
    //            Console.Out.WriteLine("Position of Ant1: {0}, {1}, {2}", Ant1.Xpos, Ant1.Ypos, Ant1.Direction);
    //        } // End of Round

    //        Console.Out.WriteLine("Sugar at Base: {0}", Base1.Sugar);

    //        for (int i = 0; i < Sugar.Length; i++)
    //        {
    //            Console.Out.WriteLine("Sugar at Sugar Source: {0}", Sugar[i].Sugar);
    //        }

    //        Console.Write("\nPress any key to exit...");
    //        Console.ReadKey(true);
    //    }
    //}
}
