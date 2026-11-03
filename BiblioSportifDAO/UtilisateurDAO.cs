using BiblioSportif;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace BiblioSportifDAO
{
    public class UtilisateurDAO
    {
        public static bool VerifierConnexion(string login, string motDePasse)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();
                string requete = "SELECT * FROM Utilisateur WHERE login = @login AND motDePasse = @motDePasse";
                using (MySqlCommand cmd = new MySqlCommand(requete, cnx))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@motDePasse", motDePasse);
                    int nombre = Convert.ToInt32(cmd.ExecuteScalar());
                    return nombre > 0;
                }
            }
        }

        public static bool LoginExiste(string login)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "SELECT COUNT(*) FROM Utilisateur WHERE login = @login";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@login", login);

                    int nombre = Convert.ToInt32(cmd.ExecuteScalar());

                    return nombre > 0;
                }
            }
        }

        public static void AjouterUtilisateur(string login, string motDePasse)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "INSERT INTO Utilisateur (login, motDePasse) " +
                             "VALUES (@login, @motDePasse)";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@login", login);
                    cmd.Parameters.AddWithValue("@motDePasse", motDePasse);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void ModifierMotDePasse(string login, string nouveauMdp)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "UPDATE Utilisateur " +
                             "SET motDePasse = @motDePasse " +
                             "WHERE login = @login";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@motDePasse", nouveauMdp);
                    cmd.Parameters.AddWithValue("@login", login);

                    cmd.ExecuteNonQuery();
                }
            }
        }
    }
}
