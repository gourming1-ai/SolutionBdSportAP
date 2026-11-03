using BiblioSportif;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioSportifDAO
{
    public class SportifDAO
    {
        public static List<Sportif> GetAll()
        {
            List<Sportif> listeSportifs = new List<Sportif>();

            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "SELECT id, nom, prenom, dateN, rue, cp, ville FROM Sportif";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            string nom = rdr.GetString(1);
                            string prenom = rdr.GetString(2);
                            DateTime dateN = rdr.GetDateTime(3);
                            string rue = rdr.GetString(4);
                            string cp = rdr.GetString(5);
                            string ville = rdr.GetString(6);

                            Sportif sportif = new Sportif(
                                id, nom, prenom, dateN, rue, cp, ville, "", ""
                            );

                            listeSportifs.Add(sportif);
                        }
                    }
                }
            }

            return listeSportifs;
        }

        public static List<string[]> GetPratiques(int idSportif)
        {
            List<string[]> listePratiques = new List<string[]>();

            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "SELECT Sport.nomSport, Niveau.libelle " +
                             "FROM Pratiquer " +
                             "INNER JOIN Sport ON Pratiquer.idSport = Sport.idSport " +
                             "INNER JOIN Niveau ON Pratiquer.idNiveau = Niveau.idNiveau " +
                             "WHERE Pratiquer.idSportif = @id";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", idSportif);

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            string sport = rdr.GetString(0);
                            string niveau = rdr.GetString(1);

                            listePratiques.Add(new string[] { sport, niveau });
                        }
                    }
                }
            }

            return listePratiques;
        }

        public static List<Sportif> Rechercher(string critere, string valeur)
        {
            List<Sportif> listeSportifs = new List<Sportif>();

            string champ = "";

            if (critere == "Ville")
            {
                champ = "ville";
            }
            else if (critere == "Niveau d'expérience")
            {
                champ = "nivExp";
            }
            else if (critere == "Nom du sport")
            {
                champ = "nomSport";
            }

            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "SELECT id, nom, prenom, dateN, rue, cp, ville, nivExp, nomSport FROM Sportif WHERE " + champ + " LIKE @valeur";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@valeur", "%" + valeur + "%");

                    using (MySqlDataReader rdr = cmd.ExecuteReader())
                    {
                        while (rdr.Read())
                        {
                            int id = rdr.GetInt32(0);
                            string nom = rdr.GetString(1);
                            string prenom = rdr.GetString(2);
                            DateTime dateN = rdr.GetDateTime(3);
                            string rue = rdr.GetString(4);
                            string codePostal = rdr.GetString(5);
                            string ville = rdr.GetString(6);
                            string niveau = rdr.GetString(7);
                            string sport = rdr.GetString(8);

                            Sportif sportif = new Sportif(id, nom, prenom, dateN, rue,codePostal, ville, niveau, sport);
                            listeSportifs.Add(sportif);
                        }
                    }
                }
            }

            return listeSportifs;
        }

        public static void Ajouter(Sportif sportif)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "INSERT INTO Sportif (nom, prenom, dateN, rue, cp, ville, nivExp, nomSport) " +
                             "VALUES (@nom, @prenom, @dateN, @rue, @cp, @ville, @nivExp, @nomSport)";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@nom", sportif.NomSportif);
                    cmd.Parameters.AddWithValue("@prenom", sportif.PrenomSportif);
                    cmd.Parameters.AddWithValue("@dateN", sportif.DateNaissanceSportif);
                    cmd.Parameters.AddWithValue("@rue", sportif.RueSportif);
                    cmd.Parameters.AddWithValue("@cp", sportif.CodePostalSportif);
                    cmd.Parameters.AddWithValue("@ville", sportif.VilleSportif);
                    cmd.Parameters.AddWithValue("@nivExp", sportif.NiveauSportif);
                    cmd.Parameters.AddWithValue("@nomSport", sportif.SportSportif);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Modifier(Sportif sportif)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "UPDATE Sportif SET nom = @nom, prenom = @prenom, dateN = @dateN, " +
                             "rue = @rue, cp = @cp, ville = @ville, nivExp = @nivExp, nomSport = @nomSport " +
                             "WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", sportif.IdSportif);
                    cmd.Parameters.AddWithValue("@nom", sportif.NomSportif);
                    cmd.Parameters.AddWithValue("@prenom", sportif.PrenomSportif);
                    cmd.Parameters.AddWithValue("@dateN", sportif.DateNaissanceSportif);
                    cmd.Parameters.AddWithValue("@rue", sportif.RueSportif);
                    cmd.Parameters.AddWithValue("@cp", sportif.CodePostalSportif);
                    cmd.Parameters.AddWithValue("@ville", sportif.VilleSportif);
                    cmd.Parameters.AddWithValue("@nivExp", sportif.NiveauSportif);
                    cmd.Parameters.AddWithValue("@nomSport", sportif.SportSportif);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static void Supprimer(int id)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                string req = "DELETE FROM Sportif WHERE id = @id";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@id", id);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public static string AjouterPratique(int idSportif, string nomSport, string niveau)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                // Récupérer l'identifiant du sport
                string req = "SELECT idSport FROM Sport WHERE nomSport = @nomSport";

                int idSport;

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@nomSport", nomSport);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        return "Ce sport n'existe pas.";
                    }

                    idSport = Convert.ToInt32(resultat);
                }

                // Récupérer l'identifiant du niveau
                req = "SELECT idNiveau FROM Niveau WHERE libelle = @niveau";

                int idNiveau;

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@niveau", niveau);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        return "Ce niveau n'existe pas.";
                    }

                    idNiveau = Convert.ToInt32(resultat);
                }

                // Vérifier si le sportif pratique déjà ce sport
                req = "SELECT COUNT(*) FROM Pratiquer WHERE idSportif = @idSportif AND idSport = @idSport";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cmd.Parameters.AddWithValue("@idSport", idSport);

                    int nombre = Convert.ToInt32(cmd.ExecuteScalar());

                    if (nombre > 0)
                    {
                        return "Ce sportif pratique déjà ce sport.";
                    }
                }

                // Ajouter le sport au sportif
                req = "INSERT INTO Pratiquer (idSportif, idSport, idNiveau) VALUES (@idSportif, @idSport, @idNiveau)";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cmd.Parameters.AddWithValue("@idSport", idSport);
                    cmd.Parameters.AddWithValue("@idNiveau", idNiveau);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Le sport a été ajouté avec succès.";
        }

        public static string ModifierNiveau(int idSportif, string nomSport, string niveau)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                // Récupérer l'identifiant du sport
                string req = "SELECT idSport FROM Sport WHERE nomSport = @nomSport";

                int idSport;

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@nomSport", nomSport);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        return "Ce sport n'existe pas.";
                    }

                    idSport = Convert.ToInt32(resultat);
                }

                // Récupérer l'identifiant du niveau
                req = "SELECT idNiveau FROM Niveau WHERE libelle = @niveau";

                int idNiveau;

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@niveau", niveau);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        return "Ce niveau n'existe pas.";
                    }

                    idNiveau = Convert.ToInt32(resultat);
                }

                // Modifier le niveau dans Pratiquer
                req = "UPDATE Pratiquer SET idNiveau = @idNiveau WHERE idSportif = @idSportif AND idSport = @idSport";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cmd.Parameters.AddWithValue("@idSport", idSport);
                    cmd.Parameters.AddWithValue("@idNiveau", idNiveau);

                    cmd.ExecuteNonQuery();
                }
            }

            return "Le niveau a été modifié avec succès.";
        }

        public static string SupprimerPratique(int idSportif, string nomSport)
        {
            using (MySqlConnection cnx = ConnexionManager.GetConnection())
            {
                cnx.Open();

                // Récupérer l'identifiant du sport
                string req = "SELECT idSport FROM Sport WHERE nomSport = @nomSport";

                int idSport;

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@nomSport", nomSport);

                    object resultat = cmd.ExecuteScalar();

                    if (resultat == null)
                    {
                        return "Ce sport n'existe pas.";
                    }

                    idSport = Convert.ToInt32(resultat);
                }

                // Supprimer uniquement la pratique sportive
                req = "DELETE FROM Pratiquer WHERE idSportif = @idSportif AND idSport = @idSport";

                using (MySqlCommand cmd = new MySqlCommand(req, cnx))
                {
                    cmd.Parameters.AddWithValue("@idSportif", idSportif);
                    cmd.Parameters.AddWithValue("@idSport", idSport);

                    int resultat = cmd.ExecuteNonQuery();

                    if (resultat > 0)
                    {
                        return "La pratique sportive a été supprimée avec succès.";
                    }
                    else
                    {
                        return "Cette pratique sportive n'existe pas.";
                    }
                }
            }
        }

    }
}