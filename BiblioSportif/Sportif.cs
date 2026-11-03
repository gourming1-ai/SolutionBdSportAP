using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BiblioSportif
{
    public class Sportif
    {
        private int idSportif;
        private string nomSportif;
        private string prenomSportif;
        private DateTime dateNaissanceSportif;
        private string rueSportif;
        private string codePostalSportif;
        private string villeSportif;
        private string niveauSportif;
        private string sportSportif;

        public Sportif(int idSportif, string nomSportif, string prenomSportif, DateTime dateNaissanceSportif, string rueSportif, string codePostalSportif, string villeSportif, string niveauSportif, string sportSportif)
        {

            this.idSportif = idSportif;
            this.nomSportif = nomSportif;
            this.prenomSportif = prenomSportif;
            this.dateNaissanceSportif = dateNaissanceSportif;
            this.rueSportif = rueSportif;
            this.codePostalSportif = codePostalSportif;
            this.villeSportif = villeSportif;
            this.niveauSportif = niveauSportif;
            this.sportSportif = sportSportif;
        }
        public Sportif( string nomSportif, string prenomSportif, DateTime dateNaissanceSportif, string rueSportif, string codePostalSportif, string villeSportif, string niveauSportif, string sportSportif)
        {
            
            this.nomSportif = nomSportif;
            this.prenomSportif = prenomSportif;
            this.dateNaissanceSportif = dateNaissanceSportif;
            this.rueSportif = rueSportif;
            this.codePostalSportif = codePostalSportif;
            this.villeSportif = villeSportif;
            this.niveauSportif = niveauSportif;
            this.sportSportif = sportSportif;
        }


        public int IdSportif { get => idSportif; set => idSportif = value; }
        public string NomSportif { get => nomSportif; set => nomSportif = value; }
        public string PrenomSportif { get => prenomSportif; set => prenomSportif = value; }
        public DateTime DateNaissanceSportif { get => dateNaissanceSportif; set => dateNaissanceSportif = value; }
        public string RueSportif { get => rueSportif; set => rueSportif = value; }
        public string CodePostalSportif { get => codePostalSportif; set => codePostalSportif = value; }
        public string VilleSportif { get => villeSportif; set => villeSportif = value; }
        public string NiveauSportif { get => niveauSportif; set => niveauSportif = value; }
        public string SportSportif { get => sportSportif; set => sportSportif = value; }
    }
}