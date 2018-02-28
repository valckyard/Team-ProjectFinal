﻿using System;
using System.Collections.Generic;
using Game.Library.Enums;
using Game.Library.Methodes;
using Game.Library.Objets;

namespace Game.Library.TypePersonnage
{
    public partial class Personnages
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
        public ArmeObject Arme { get; set; }
        public ArmureObject Armure { get; set; }

        //inventaire
        public List<ObjectInventaire> Inventaire { get; set; }


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
            Arme = null;
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
            PtsVieMax = (int)(PtsVieMax * 1.1616);
           
            //ajoute les pts gagne en bonus health
            PtsVieActuel += (int)(PtsVieMax * 0.1616);
            PointsMagieMax = (int)(PointsMagieMax * 1.1616);
            PointsMagieActuel += (int)(PointsMagieMax * 0.1616);
            PtsDefense = PtsDefense * 1.1616;
            PtsVitesse = PtsVitesse * 1.1616;
        }

        private Sort ChoixSort()
        {
            var sortchoisi = new Sort();
            var spellbook = new Dictionary<int, Sort>();
            int x = 1;
            foreach (var s in ListeSorts)
            {
                spellbook.Add(x, s);
                Console.WriteLine($"{x} -- {s.NomSort}, Cout : {s.CoutMp} , Puissance : {s.Puissance}, Element : {s.TypeElementType}");
                x++;
            }

            Console.WriteLine("Quel sort voulez vous utiliser ?");
            int spellreponse; // en read
            while (int.TryParse(Console.ReadLine(), out spellreponse) == false)
            {
            }

            if (spellreponse > 4 & spellreponse < 1)
                ChoixSort();

            foreach (var sort in spellbook)
            {
                if (spellreponse == sort.Key)
                {
                    sortchoisi = sort.Value;
                }
            }
            return sortchoisi;
        }


        




    }
}