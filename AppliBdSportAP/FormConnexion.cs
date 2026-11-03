using BiblioSportifDAO;
using BiblioSportif;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppliBdSportAP
{
    public partial class FormConnexion : Form
    {
        public FormConnexion()
        {
            InitializeComponent();
        }

        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txtLogin.Text;
            string mdp = txtMdp.Text;
            if (login == "" || mdp == "")
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (UtilisateurDAO.VerifierConnexion(login, mdp))
            {
                MessageBox.Show("Connexion réussie.");
                Form1 form1 = new Form1();
                form1.Show();
                this.Hide();

            }
            else
            {
                MessageBox.Show("Login ou mot de passe incorrect.");
                txtLogin.Clear();
                txtMdp.Clear();
            }
        }

        private void btnInscription_Click(object sender, EventArgs e)
        {
            FormInscription form = new FormInscription();
            form.ShowDialog();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void btnChangerMdp_Click(object sender, EventArgs e)
        {
            FormChangementMdp form = new FormChangementMdp();
            form.ShowDialog();
        }
    }
}
