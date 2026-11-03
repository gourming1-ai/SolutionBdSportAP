using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BiblioSportifDAO;
using BiblioSportif;

namespace AppliBdSportAP
{
    public partial class FormInscription : Form
    {
        public FormInscription()
        {
            InitializeComponent();
        }

        private void btnCreer_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string motDePasse = txtMdp.Text;
            string confirmation = txtConfirmation.Text;

            // Vérifier que tous les champs sont remplis
            if (login == "" || motDePasse == "" || confirmation == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Vérifier la confirmation du mot de passe
            if (motDePasse != confirmation)
            {
                MessageBox.Show("Les mots de passe ne correspondent pas.");
                return;
            }

            // Vérifier si le login existe déjà
            if (UtilisateurDAO.LoginExiste(login))
            {
                MessageBox.Show("Ce login est déjà utilisé.");
                return;
            }

            // Ajouter l'utilisateur
            UtilisateurDAO.AjouterUtilisateur(login, motDePasse);

            MessageBox.Show("Votre compte a été créé avec succès.");

            this.Close();
        }
    }
}