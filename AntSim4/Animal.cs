using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tain.AntSim4
{
    /// <summary>  
    ///  Animals sind alle beweglichen Elemente
    /// </summary>  
    public class Animal
    {
        #region Fields
        /// <summary>  
        ///  Definiert die aktuelle Position in X-Richtung eines Tieres
        /// </summary> 
        protected int xPos;

        /// <summary>  
        ///  Definiert die aktuelle Position in Y-Richtung eines Tieres
        /// </summary> 
        protected int yPos;

        /// <summary>  
        ///  Definiert die aktuelle Bewegungsrichtung eines Tieres
        /// </summary> 
        protected int direction;

        /// <summary>  
        ///  Definiert die maximale Geschwindigkeit eines Tieres
        /// </summary> 
        protected int speed;

        /// <summary>  
        ///  Definiert die maximale Drehgeschwindigkeit eines Tieres
        /// </summary> 
        protected int rotationSpeed;

        /// <summary>  
        ///  Definiert die maximale Sichtentfernung eines Tieres
        /// </summary> 
        protected int sightDistance;

        /// <summary>  
        ///  Definiert die maximale Beladungsmenge eines Tieres
        /// </summary> 
        protected int loadCapacity;

        /// <summary>  
        ///  Definiert die noch zur Verfügung stehenden Energiereserven bis zum Tod
        /// </summary> 
        protected int energy;
        #endregion

        #region Constructors
        /// <summary>  
        ///  Instanziiert Tiere über eine Position 
        /// </summary> 
        public Animal(int xPos, int yPos)
        {
            this.xPos = xPos;
            this.yPos = yPos;
        }
        /// <summary>  
        ///  Instanziiert Tiere über eine HeimatBasis
        /// </summary> 
        public Animal(Base homeBase)
        {

        }
        #endregion

        #region Properties

        /// <summary>  
        ///  Zeigt die aktuelle Position in X-Richtung eines Tieres
        /// </summary> 
        public int XPos
        {
            get { return xPos; }
        }

        /// <summary>  
        ///  Zeigt die aktuelle Position in Y-Richtung eines Tieres
        /// </summary> 
        public int YPos
        {
            get { return yPos; }
        }

        /// <summary>  
        ///  Zeigt die aktuelle Bewegungsrichtung eines Tieres
        /// </summary> 
        public int Direction
        {
            get { return direction; }
        }
        #endregion

        #region Methods

        /// <summary>  
        ///  Animal bewegt sich um "distance" bzw. "speed" in Richtung "orientation"
        /// </summary>
        public void Walk(int distance)
        {

            int fieldLength = Simulation.FieldLength;

            // Am Feldrand muss gedreht werden
            if ((xPos == 0 && direction >= 90 && direction < 180) ||
                    (xPos == fieldLength && direction >= 270) ||
                    (yPos == 0 && direction <= 90) ||
                    (yPos == fieldLength && direction >= 180 && direction < 270))
            {
                Turn(120);
            }
            else if ((xPos == 0 && direction < 90) ||
                    (xPos == fieldLength && direction > 180 && direction < 270) ||
                    (yPos == 0 && direction > 270) ||
                    (yPos == fieldLength && direction > 90 && direction < 180))
            {
                Turn(-120);
            }

            else
            {
                // Nur Vorwärtsbewegung erlaubt
                if (distance < 0)
                {
                    distance = -distance;
                }

                // Translatorische Bewegung berechnen
                if (distance > speed)
                {
                    xPos = Convert.ToInt32(xPos - (Math.Sin(Math.PI * direction / 180) * speed));
                    yPos = Convert.ToInt32(yPos - (Math.Cos(Math.PI * direction / 180) * speed));
                }
                else
                {
                    xPos = Convert.ToInt32(xPos - (Math.Sin(Math.PI * direction / 180) * distance));
                    yPos = Convert.ToInt32(yPos - (Math.Cos(Math.PI * direction / 180) * distance));
                }

                // Bewegung am Feldrand begrenzen
                if (xPos < 0)
                { xPos = 0; }
                else if (xPos > fieldLength)
                { xPos = fieldLength; }

                if (yPos < 0)
                { yPos = 0; }
                else if (yPos > fieldLength)
                { yPos = fieldLength; }
            }
        }

        /// <summary>  
        ///  Animal dreht sich um "angle" 
        /// </summary>
        public void Turn(int angle)
        {
            if ((angle >= 0 && angle <= rotationSpeed) || (angle < 0 && angle >= -rotationSpeed))
            { direction = direction + angle; }
            else if (angle >= 0)
            { direction = direction + rotationSpeed; }
            else
            { direction = direction - rotationSpeed; }

            //Normalisierung
            if (direction < 0)
            { direction = direction + 360; }
            else if (direction > 360)
            { direction = direction - 360; }
        }

        /// <summary>  
        ///  Identifiziert alle Objekte im Sichtbereich 
        /// </summary>
        public List<int> Look()
        {
            List<int> sightedObjects = new List<int>();
            
            // Zuerst wird eine rechteckige Fläche "sightArea" um das Tier aufgespannt. 
            int sightAreaLength = 2 * sightDistance + 1;
            int[,] sightArea = new int[sightAreaLength, sightAreaLength];

            // Dann wird für jedes Feld der Fläche geprüft, ob dieses in Sichtentfernung und im Spielfeld ist.
            for (int i = 0; i < sightArea.GetLength(0); i++)
            {
                for (int k = 0; k < sightArea.GetLength(1); k++)
                {
                    int sightXpos = xPos - sightDistance + i;
                    int sightYpos = yPos - sightDistance + k;
                    double distance = Math.Sqrt(Math.Pow(sightXpos - xPos, 2) + Math.Pow(sightYpos - yPos, 2));

                    if (distance <= sightDistance && sightXpos >= 0 && sightYpos >= 0 && sightXpos <= Simulation.FieldLength && sightYpos <= Simulation.FieldLength)
                    {
                        if (Simulation.SimField.GetValue(sightXpos, sightYpos) != null)
                        {
                            sightedObjects.Add(Convert.ToInt32(Simulation.SimField.GetValue(sightXpos, sightYpos)));
                        }
                    }
                }
            }
            return sightedObjects;
        }

        //public Target[] LookFor(FixObject[] name, int fieldLength)
        //{
        //    // Identifiziert alle Ziele im Sichtbereich

        //    int sightAreaLength = 2 * sightDistance + 1;
        //    int[,,] sightArea = new int[sightAreaLength, sightAreaLength, 3];

        //    Target[] targetList = null;

        //    for (int i = 0; i < sightArea.GetLength(0); i++)
        //    {
        //        for (int k = 0; k < sightArea.GetLength(1); k++)
        //        {
        //            int sightXpos = xpos - SightDistance + i;
        //            int sightYpos = ypos - SightDistance + k;
        //            double distance = Math.Sqrt(Math.Pow(sightXpos - xpos, 2) + Math.Pow(sightYpos - ypos, 2));

        //            // prüfen ob Feld in Sichtweite und im Spielfeld liegt
        //            if (distance <= sightDistance && sightXpos >= 0 && sightYpos >= 0 && sightXpos <= fieldLength && sightYpos <= fieldLength)
        //            {
        //                for (int p = 0; p < name.Length; p++)
        //                {
        //                    // prüfen ob ein target an Pos vorhanden
        //                    if (name[p].Xpos == sightXpos && name[p].Ypos == sightYpos)
        //                    {
        //                        if (targetList == null)
        //                        {
        //                            targetList = new Target[] { new Target(sightXpos, sightYpos) };
        //                        }
        //                        else
        //                        {
        //                            Target[] targetList2 = new Target[targetList.Length + 1];
        //                            Array.Copy(targetList, targetList2, targetList.Length);
        //                            targetList2[targetList.Length] = new Target(sightXpos, sightYpos);
        //                            targetList = targetList2;
        //                        }
        //                    }
        //                }
        //            }
        //        }
        //    }
        //    return targetList;
        //}

        //private double[] WhereIs(Target target)
        //{
        //    // Bestimmte Abstand und Winkelabweichung zwischen Target und Animal
        //    if (target == null)
        //    {
        //        double[] difference = { 0, 0 };
        //        return difference;
        //    }
        //    else
        //    {
        //        double xdif;
        //        double ydif;
        //        double angle;
        //        double angleDif;
        //        double distance;

        //        // winkelabweichung bestimmen
        //        //winkel zum Ziel bestimmen
        //        xdif = xpos - target.Xpos;
        //        ydif = ypos - target.Ypos;
        //        angle = (Math.Atan2(xdif, ydif) * (180 / Math.PI));

        //        //Differenz zum eigenen Winkel bestimmen
        //        angleDif = angle - direction;

        //        if (angleDif > 180)
        //        { angleDif = angleDif - 360; }
        //        else if (angleDif < -180)
        //        { angleDif = angleDif + 360; }

        //        // Entfernung bestimmen
        //        distance = Math.Sqrt(Math.Pow(xpos - target.Xpos, 2) + Math.Pow(ypos - target.Ypos, 2));

        //        double[] difference = { distance, angleDif };
        //        return difference;
        //    }
        //}

        //public bool GoToNext(Target[] targetList, int fieldLength)
        //{
        //    // Bewegt Animal in Richtung des am schnellsten erreichbaren Targets

        //    if (targetList == null)
        //    { return false; }
        //    else
        //    {
        //        double[] difference;
        //        int[,] rounds = new int[targetList.Length, 3];
        //        int targetSelect = 0;

        //        for (int i = 0; i < targetList.Length; i++)
        //        {
        //            // Abweichung (Distanz/Winkel)bestimmen
        //            difference = WhereIs(targetList[i]);
        //            // Rundenanzahl bis Erreichen bestimmen
        //            rounds[i, 0] = Convert.ToInt32(Math.Ceiling(difference[1] / rotatingSpeed) - 1 + Math.Ceiling(difference[0] / speed));
        //            rounds[i, 1] = Convert.ToInt32(difference[1]);
        //            rounds[i, 2] = Convert.ToInt32(difference[0]);

        //            // Ziel mit niedrigster Rundenanzahl bestimmen und zurückgeben
        //            if (rounds[i, 0] < rounds[targetSelect, 0])
        //            { targetSelect = i; }
        //        }

        //        if (xpos == targetList[targetSelect].Xpos && ypos == targetList[targetSelect].Ypos)
        //        { return true; }
        //        else
        //        {
        //            // Bewegen in Richtung Ziel
        //            Turn(rounds[targetSelect, 1]);

        //            if (rounds[targetSelect, 1] < rotatingSpeed)
        //            { Walk(rounds[targetSelect, 2], fieldLength); }

        //            return false;
        //        }
        //    }
        //}

        //public bool GoTo(int targetXpos, int targetYpos, int fieldLength)
        //{
        //    // Bewegt Animal in Richtung eines bestimmten Targets
        //    if (xpos == targetXpos && ypos == targetYpos)
        //    { return true; }
        //    else
        //    {
        //        // Abweichung (Distanz/Winkel)bestimmen
        //        double[] difference;
        //        difference = WhereIs(new Target(targetXpos, targetYpos));

        //        // Bewegen in Richtung Ziel
        //        Turn(Convert.ToInt32(difference[1]));

        //        if (Convert.ToInt32(difference[1]) < rotatingSpeed)
        //        { Walk(Convert.ToInt32(difference[0]), fieldLength); }

        //        return false;
        //    }
        //}

        #endregion
    }
}
