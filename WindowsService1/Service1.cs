using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.ServiceProcess;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using System.Timers;
namespace WindowsService1
{
    public partial class Service1 : ServiceBase
    {
        GestionDate gd = new GestionDate();
        MySqlConnection cn;
        MySqlCommand com;
        Timer timer = null;

        public Service1()
        {
            InitializeComponent();

        }

        /// <summary>
        /// Se connecte a la BDD et lance le timer
        /// </summary>
        /// <param name="args"></param>
        protected override void OnStart(string[] args)
        {
            cn = ConnexionSql.getInstance("138.231.160.7","mba","mba","fech3Oph");
           

            // Timer de 10 secondes
            timer = new Timer(10000);

            // Execute timer_elapsed toute les 10 secondes
            timer.Elapsed += new ElapsedEventHandler(timer_Elapsed);

            // Lancement du timer
            timer.Start();
        }

        /// <summary>
        /// Modifie les fiches de frais concernées 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void timer_Elapsed(object sender, EventArgs e)
        {
            cn.Open();

            string AnneeMois = gd.getAnneeMoisPrecedent();

            if (gd.getJourCourant() >= 1 && gd.getJourCourant() <= 10)
            {

                /* Récupère et affiche les fiches du mois précédents à l'état CR
                
                com = new MySqlCommand("Select * from ficheFrais where mois ='" + AnneeMois + "' AND idetat = 'CR'", cn);
                */

                /* Modifie les fiches du mois précédent de l'état CL à CR puis les affiche
                */
                com = new MySqlCommand("UPDATE fichefrais SET idetat = 'CL' WHERE mois ='" + AnneeMois + "' AND idetat = 'CR'", cn);
                com.ExecuteNonQuery();

                /*
                com = new MySqlCommand("Select * from ficheFrais where mois ='" + AnneeMois + "' AND idetat = 'CL'", cn);
                */
            }


            if (gd.getJourCourant() >= 20)
            {
                /* Récupère et affiche les fiches du mois précédents à l'état MP
                
                com = new MySqlCommand("Select * from ficheFrais where mois ='" + AnneeMois + "' AND idetat = 'MP'", cn);
                */

                /* Modifie les fiches du mois précédent de l'état MP à RB puis les affiche
                */
                com = new MySqlCommand("UPDATE fichefrais SET idetat = 'RB' WHERE mois ='" + AnneeMois + "' AND idetat = 'MP'", cn);
                com.ExecuteNonQuery();

                /*
                com = new MySqlCommand("Select * from ficheFrais where mois ='" + AnneeMois + "' AND idetat = 'RB'", cn);
                */
            }

            cn.Close();
        }

        protected override void OnStop()
        {

        }

      
    }
}
