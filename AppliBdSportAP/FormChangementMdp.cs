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

namespace AppliBdSportAP
{
    public partial class FormChangementMdp : Form
    {
        public FormChangementMdp()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string ancienMdp = txtAncienMdp.Text;
            string nouveauMdp = txtNouveauMdp.Text;
            string confirmation = txtConfirmation.Text;

            // Vérifier que tous les champs sont remplis
            if (login == "" ||
                ancienMdp == "" ||
                nouveauMdp == "" ||
                confirmation == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Vérifier le login et l'ancien mot de passe
            if (!UtilisateurDAO.VerifierConnexion(login, ancienMdp))
            {
                MessageBox.Show("Login ou ancien mot de passe incorrect.");
                return;
            }

            // Vérifier la confirmation
            if (nouveauMdp != confirmation)
            {
                MessageBox.Show("Les nouveaux mots de passe ne correspondent pas.");
                return;
            }

            // Éviter de remettre exactement le même mot de passe
            if (ancienMdp == nouveauMdp)
            {
                MessageBox.Show("Le nouveau mot de passe doit être différent de l'ancien.");
                return;
            }

            // Modifier dans la BDD
            UtilisateurDAO.ModifierMotDePasse(login, nouveauMdp);

            MessageBox.Show("Votre mot de passe a été modifié avec succès.");

            this.Close();
        }
    }
}