using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioSportifDAO
{
    public class ConnexionManager
    {
        // centralise la création des connexions à la base de données
        // penser à ajouter 2 usings
        // using MySql.Data.MySqlClient;
        // using system.Configuration;
        public static MySqlConnection GetConnection()
        {
            string chaineConnection = ConfigurationManager.ConnectionStrings["cnxBdSportif"].ConnectionString;
            return new MySqlConnection(chaineConnection);
        }
    }
}
