﻿using System.Collections.Generic;
using System.Media;
using Game.Library.Enums;

namespace Game.Library
{
    public class Personnages
    {
        //Characteristiques
        public Race Race { get; set; }
        public Classe Classe { get; set; }
        public string Nom { get; set; }

        //Experience
        public int Niveau { get; set; }
        public double ValeurPtsExperiences { get; set; }
        public double PtsExperience { get; set; }
        public double SeuilExperience { get; set; }

        //Stats
        public int PtsVieActuel { get; set; }
        public int PtsVieMax { get; set; }

        public int PointsMagieMax { get; set; }
        public int PointsMagieActuel { get; set; }

        public double PtsAttaque { get; set; }
        public double PuissanceMagique { get; set; }
        public double PtsDefense { get; set; }
        public double PtsVitesse { get; set; }

        //Options d'attaque
        public List<Sort> ListeSorts { get; set; }
        public Objet ObjectTenu { get; set; }

        //inventaire
        public List<Objet> Inventaire { get; set; }


        public Personnages(Race race, Classe classe, string nom, int ptsVieMax, int pointsMagieMax, int ptsAttaque,
            int puissanceMagique, int ptsDefense, int ptsVitesse)
        {
            //Characteristiques
            Race = race;
            Nom = nom;
            Classe = classe;

            //Experience
            Niveau = 0;
            PtsExperience = 0;
            //SeuilExperience;
            ValeurPtsExperiences = PtsExperience / 3;

            //Stats
            PtsVieActuel = ptsVieMax;
            PtsVieMax = ptsVieMax;

            PointsMagieMax = pointsMagieMax;
            PointsMagieActuel = pointsMagieMax;

            PtsAttaque = ptsAttaque;
            PuissanceMagique = puissanceMagique;
            PtsDefense = ptsDefense;
            PtsVitesse = ptsVitesse;


            //Equipement
            ListeSorts = new List<Sort>();
            ObjectTenu = null;
        }

        // Constructeur Vide
        public Personnages()
        {
            ListeSorts = new List<Sort>();
        }

        public void CheckLevelPlayer()
        {
            if (PtsExperience >= SeuilExperience)
            {
                PtsExperience -= SeuilExperience;
                SeuilExperience = SeuilExperience * 1.5;
                ++Niveau;
                StatsOnLevel();
                
                // spell add
            }
        }

        public void StatsOnLevel()
        {
            PuissanceMagique = PuissanceMagique * 1.1616;
            PtsAttaque = PtsAttaque * 1.1616;
            PtsVieMax = (int) (PtsVieMax * 1.1616);
            //ajoute les pts gagne en bonus health
            PtsVieActuel += (int)(PtsVieMax * 0.1616);
            PointsMagieMax = (int) (PointsMagieMax * 1.1616);
            PointsMagieActuel += (int)(PointsMagieMax * 0.1616);
            PtsDefense = PtsDefense * 1.1616;
            PtsVitesse = PtsVitesse * 1.1616;
        }

    }
}