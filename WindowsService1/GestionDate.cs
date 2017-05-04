﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsService1
{
    public class GestionDate
    {
        private int moisCourant;
        private int jourCourant;

        /// <summary>
        /// Retourne le mois courant
        /// </summary>
        /// <returns>int</returns>

        public int getMoisCourant()
        {
            DateTime now = DateTime.Now;
            moisCourant = now.Month;
            return moisCourant;
        }

        /// <summary>
        /// Retourne le jour courant
        /// </summary>
        /// <returns>jourCourtant</returns>
        public int getJourCourant()
        {
            DateTime now = DateTime.Now;
            jourCourant = now.Day;
            return jourCourant;

        }

        public string getMoisFiche(string date)
        {
            return date.Substring(4, 2);
        }

        /// <summary>
        /// Retourne le mois précédent
        /// </summary>
        /// <returns>moisPrecedent</returns>
        public DateTime getMoisPrecedent()
        {
            DateTime today = DateTime.Today;
            DateTime datePrecedente = today.AddMonths(-1);

            return datePrecedente;

        }

        /// <summary>
        /// Retourne l'année et le mois précédent concatenés en string
        /// </summary>
        /// <returns>AnneeMois</returns>
        public string getAnneeMoisPrecedent()
        {
            DateTime today = DateTime.Today;
            DateTime datePrecedente = today.AddMonths(-1);
            string anneePrecedente = datePrecedente.Year.ToString();
            string moisPrecedent = datePrecedente.Month.ToString().PadLeft(2, '0');
            string AnneeMois = anneePrecedente + "" + moisPrecedent;
            return AnneeMois;
        }

    }
}

