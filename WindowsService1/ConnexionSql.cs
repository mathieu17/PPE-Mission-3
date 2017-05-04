using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace WindowsService1
{
    class ConnexionSql
    {

        private static MySqlConnection Cn = null;

        /// <summary>
        /// Constructeur de la connexion
        /// </summary>
        /// <param name="serveur"></param>
        /// <param name="bdd"></param>
        /// <param name="user"></param>
        /// <param name="mdp"></param>
        private ConnexionSql(string serveur, string bdd, string user, string mdp)
            {
            string connectionString;
            connectionString = "SERVER=" + serveur + ";" + "DATABASE=" + bdd + ";" + "USER ID=" + user + ";" + "PASSWORD=" + mdp;

            Cn = new MySqlConnection(connectionString);
        }
        /// <summary>
        /// Retourne l'instance de la connexion
        /// </summary>
        /// <param name="serveur"></param>
        /// <param name="bdd"></param>
        /// <param name="user"></param>
        /// <param name="mdp"></param>
        /// <returns></returns>
        public static MySqlConnection getInstance(string serveur, string bdd, string user, string mdp)
        {
            if (null == Cn)
            { 
                new ConnexionSql(serveur, bdd, user, mdp);

            }
            return Cn;
        }

        
        /// <summary>
        /// Ouvre la connexion à la BDD
        /// </summary>
        public static void OpenConnection()
        {
            Cn.Open();
        }

        
        /// <summary>
        /// Ferme la connexion à la BD
        /// </summary>
        public static void CloseConnection()
        {
            Cn.Close();
        }
}
}



