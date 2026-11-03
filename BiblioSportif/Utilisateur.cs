using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioSportif
{
    public class Utilisateur
    {
        private int idConnexion;
        private string login;
        private string motDePasse;

        public Utilisateur(string login, string motDePasse)
        {
            this.login = login;
            this.motDePasse = motDePasse;
        }

        public Utilisateur(int idConnexion, string login, string motDePasse)
        {
            this.idConnexion = idConnexion;
            this.login = login;
            this.motDePasse = motDePasse;
        }

        public int IdConnexion { get => idConnexion; set => idConnexion = value; }
        public string Login { get => login; set => login = value; }
        public string MotDePasse { get => motDePasse; set => motDePasse = value; }
    }
}
