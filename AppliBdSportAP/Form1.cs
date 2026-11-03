using BiblioSportif;
using BiblioSportifDAO;
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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            cmboChoix.Items.Add("Ville"); 
            cmboChoix.Items.Add("Niveau d'expérience"); 
            cmboChoix.Items.Add("Nom du sport");
            cmboChoix.SelectedIndex = 0;

            List<Sportif> listeSportifs = SportifDAO.GetAll();
            lstvAffiche.View = View.Details;
            lstvAffiche.FullRowSelect = true;
            lstvAffiche.GridLines = true;
            lstvAffiche.Columns.Add("ID", 50); 
            lstvAffiche.Columns.Add("Nom", 100); 
            lstvAffiche.Columns.Add("Prénom", 100); 
            lstvAffiche.Columns.Add("Date de naissance", 120); 
            lstvAffiche.Columns.Add("Rue", 150); 
            lstvAffiche.Columns.Add("Code postal", 80); 
            lstvAffiche.Columns.Add("Ville", 100); 
            lstvAffiche.Columns.Add("Niveau", 100); 
            lstvAffiche.Columns.Add("Sport", 100);
            foreach (Sportif sportif in listeSportifs)
            {
                ListViewItem ligne = new ListViewItem(sportif.IdSportif.ToString());
                ligne.SubItems.Add(sportif.NomSportif);
                ligne.SubItems.Add(sportif.PrenomSportif);
                ligne.SubItems.Add(sportif.DateNaissanceSportif.ToString());
                ligne.SubItems.Add(sportif.RueSportif);
                ligne.SubItems.Add(sportif.CodePostalSportif);
                ligne.SubItems.Add(sportif.VilleSportif);
                ligne.SubItems.Add(sportif.NiveauSportif);
                ligne.SubItems.Add(sportif.SportSportif);
                
                lstvAffiche.Items.Add(ligne);
            }

            cmboNiveau.Items.Add("Débutant");
            cmboNiveau.Items.Add("Confirmé");
            cmboNiveau.Items.Add("Avancé");
            cmboNiveau.Items.Add("Professionnel");

            List<Sportif> listeSportif = SportifDAO.GetAll();
            lstvSportifs.View = View.Details;
            lstvSportifs.FullRowSelect = true;
            lstvSportifs.GridLines = true;
            lstvSportifs.Columns.Add("ID", 50);
            lstvSportifs.Columns.Add("Nom", 100);
            lstvSportifs.Columns.Add("Prénom", 100);
            lstvSportifs.Columns.Add("Date de naissance", 120);
            lstvSportifs.Columns.Add("Rue", 150);
            lstvSportifs.Columns.Add("Code postal", 80);
            lstvSportifs.Columns.Add("Ville", 100);
            lstvSportifs.Columns.Add("Niveau", 100);
            lstvSportifs.Columns.Add("Sport", 100);
            foreach (Sportif sportif in listeSportif)
            {
                ListViewItem ligne = new ListViewItem(sportif.IdSportif.ToString());
                ligne.SubItems.Add(sportif.NomSportif);
                ligne.SubItems.Add(sportif.PrenomSportif);
                ligne.SubItems.Add(sportif.DateNaissanceSportif.ToString("dd/MM/yyyy"));
                ligne.SubItems.Add(sportif.RueSportif);
                ligne.SubItems.Add(sportif.CodePostalSportif);
                ligne.SubItems.Add(sportif.VilleSportif);
                ligne.SubItems.Add(sportif.NiveauSportif);
                ligne.SubItems.Add(sportif.SportSportif);
                lstvSportifs.Items.Add(ligne);
            }

            lstvPratiques.View = View.Details;
            lstvPratiques.FullRowSelect = true;
            lstvPratiques.GridLines = true;

            lstvPratiques.Columns.Add("Sport", 150);
            lstvPratiques.Columns.Add("Niveau", 150);
        }

        private void btnRecherche_Click(object sender, EventArgs e)
        {
            if (cmboChoix.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un critère de recherche.");
                return;
            }

            
            string critere = cmboChoix.SelectedItem.ToString();

            
            string valeur = txtVal.Text.Trim();

            
            if (valeur == "")
            {
                MessageBox.Show("Veuillez entrer une valeur à rechercher.");
                return;
            }

            
            List<Sportif> listeSportifs = SportifDAO.Rechercher(critere, valeur);

            
            lstvAffiche.Items.Clear();

            // Afficher les résultats
            foreach (Sportif sportif in listeSportifs)
            {
                ListViewItem ligne = new ListViewItem(sportif.IdSportif.ToString());

                ligne.SubItems.Add(sportif.NomSportif);
                ligne.SubItems.Add(sportif.PrenomSportif);
                ligne.SubItems.Add(sportif.DateNaissanceSportif.ToString("dd/MM/yyyy"));
                ligne.SubItems.Add(sportif.RueSportif);
                ligne.SubItems.Add(sportif.CodePostalSportif);
                ligne.SubItems.Add(sportif.VilleSportif);
                ligne.SubItems.Add(sportif.NiveauSportif);
                ligne.SubItems.Add(sportif.SportSportif);

                lstvAffiche.Items.Add(ligne);
            }

            // Aucun résultat
            if (listeSportifs.Count == 0)
            {
                MessageBox.Show("Aucun sportif trouvé.");
            }
        }

        private void cmboChoix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lstvAffiche_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txtVal_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnForm2_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAjouter_Click(object sender, EventArgs e)
        {
            if (txtNom.Text.Trim() == ""
                || txtPrenom.Text.Trim() == ""
                || txtRue.Text.Trim() == ""
                || txtCP.Text.Trim() == ""
                || txtVille.Text.Trim() == ""
                || txtSport.Text.Trim() == ""
                || cmboNiveau.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            if (txtCP.Text.Length != 5 || !int.TryParse(txtCP.Text, out _))
            {
                MessageBox.Show("Le code postal doit contenir 5 chiffres.");
                return;
            }

            string nom = txtNom.Text.Trim();
            string prenom = txtPrenom.Text.Trim();
            DateTime dateN = dtpDateN.Value;
            string rue = txtRue.Text.Trim();
            string cp = txtCP.Text.Trim();
            string ville = txtVille.Text.Trim();
            string niveau = cmboNiveau.SelectedItem.ToString();
            string sport = txtSport.Text.Trim();

            Sportif sportif = new Sportif(nom, prenom, dateN, rue, cp, ville, niveau, sport);
            SportifDAO.Ajouter(sportif);
            MessageBox.Show("Le sportif a été ajouté avec succès.");

            txtNom.Clear();
            txtPrenom.Clear();
            txtRue.Clear();
            txtCP.Clear();
            txtVille.Clear();
            txtSport.Clear();
            cmboNiveau.SelectedIndex = -1;

            lstvSportifs.Items.Clear();
            List<Sportif> listeSportifs = SportifDAO.GetAll();
            foreach (Sportif sportifAjoute in listeSportifs)

            {
                ListViewItem ligne = new ListViewItem(sportifAjoute.IdSportif.ToString());
                ligne.SubItems.Add(sportifAjoute.NomSportif);
                ligne.SubItems.Add(sportifAjoute.PrenomSportif);
                ligne.SubItems.Add(sportifAjoute.DateNaissanceSportif.ToString("dd/MM/yyyy"));
                ligne.SubItems.Add(sportifAjoute.RueSportif);
                ligne.SubItems.Add(sportifAjoute.CodePostalSportif);
                ligne.SubItems.Add(sportifAjoute.VilleSportif);
                ligne.SubItems.Add(sportifAjoute.NiveauSportif);
                ligne.SubItems.Add(sportifAjoute.SportSportif);
                lstvSportifs.Items.Add(ligne);
            }
        }

        private void btnModifier_Click(object sender, EventArgs e)
        {
            // Vérifier qu'un sportif est sélectionné
            if (lstvSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sportif à modifier.");
                return;
            }

            // Vérifier les champs
            if (txtNom.Text.Trim() == "" ||
                txtPrenom.Text.Trim() == "" ||
                txtRue.Text.Trim() == "" ||
                txtCP.Text.Trim() == "" ||
                txtVille.Text.Trim() == "" ||
                txtSport.Text.Trim() == "" ||
                cmboNiveau.SelectedItem == null)
            {
                MessageBox.Show("Veuillez remplir tous les champs.");
                return;
            }

            // Vérifier le code postal
            if (txtCP.Text.Length != 5 || !int.TryParse(txtCP.Text, out _))
            {
                MessageBox.Show("Le code postal doit contenir 5 chiffres.");
                return;
            }

            // Récupérer l'ID du sportif sélectionné
            int id = int.Parse(lstvSportifs.SelectedItems[0].SubItems[0].Text);

            // Créer le sportif avec les nouvelles informations
            Sportif sportif = new Sportif(
                id,
                txtNom.Text.Trim(),
                txtPrenom.Text.Trim(),
                dtpDateN.Value,
                txtRue.Text.Trim(),
                txtCP.Text.Trim(),
                txtVille.Text.Trim(),
                cmboNiveau.SelectedItem.ToString(),
                txtSport.Text.Trim()
            );

            // Modifier dans la BDD
            SportifDAO.Modifier(sportif);

            MessageBox.Show("Le sportif a été modifié avec succès.");

            // Actualiser la liste
            lstvSportifs.Items.Clear();

            List<Sportif> listeSportifs = SportifDAO.GetAll();

            foreach (Sportif sportifModifie in listeSportifs)
            {
                ListViewItem ligne = new ListViewItem(
                    sportifModifie.IdSportif.ToString()
                );

                ligne.SubItems.Add(sportifModifie.NomSportif);
                ligne.SubItems.Add(sportifModifie.PrenomSportif);
                ligne.SubItems.Add(
                    sportifModifie.DateNaissanceSportif.ToString("dd/MM/yyyy")
                );
                ligne.SubItems.Add(sportifModifie.RueSportif);
                ligne.SubItems.Add(sportifModifie.CodePostalSportif);
                ligne.SubItems.Add(sportifModifie.VilleSportif);
                ligne.SubItems.Add(sportifModifie.NiveauSportif);
                ligne.SubItems.Add(sportifModifie.SportSportif);

                lstvSportifs.Items.Add(ligne);
            }
        }

        private void lstvSportifs_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstvSportifs.SelectedItems.Count > 0)
            {
                ListViewItem ligne = lstvSportifs.SelectedItems[0];

                txtNom.Text = ligne.SubItems[1].Text;
                txtPrenom.Text = ligne.SubItems[2].Text;

                dtpDateN.Value = DateTime.Parse(ligne.SubItems[3].Text);

                txtRue.Text = ligne.SubItems[4].Text;
                txtCP.Text = ligne.SubItems[5].Text;
                txtVille.Text = ligne.SubItems[6].Text;
                cmboNiveau.Text = ligne.SubItems[7].Text;
                txtSport.Text = ligne.SubItems[8].Text;

                // Vider la liste des pratiques
                lstvPratiques.Items.Clear();

                // Récupérer l'ID du sportif
                int id = int.Parse(ligne.SubItems[0].Text);

                // Récupérer ses sports et ses niveaux
                List<string[]> pratiques = SportifDAO.GetPratiques(id);

                // Afficher les pratiques
                foreach (string[] pratique in pratiques)
                {
                    ListViewItem lignePratique = new ListViewItem(pratique[0]);
                    lignePratique.SubItems.Add(pratique[1]);

                    lstvPratiques.Items.Add(lignePratique);
                }
            }

        }

        private void btnSupprimer_Click(object sender, EventArgs e)
        { 
            if (lstvSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sportif à supprimer.");
                return;
            }

            ListViewItem ligneSelectionnee = lstvSportifs.SelectedItems[0];

            int id = int.Parse(ligneSelectionnee.SubItems[0].Text);
            string nom = ligneSelectionnee.SubItems[1].Text;
            string prenom = ligneSelectionnee.SubItems[2].Text;

            // Demander confirmation avant la suppression
            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer " + prenom + " " + nom + " ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            // Si l'utilisateur clique sur Non
            if (reponse == DialogResult.No)
            {
                return;
            }

            // Suppression dans la base de données
            SportifDAO.Supprimer(id);

            MessageBox.Show("Le sportif a été supprimé avec succès.");

            // Vider les champs
            txtNom.Clear();
            txtPrenom.Clear();
            txtRue.Clear();
            txtCP.Clear();
            txtVille.Clear();
            txtSport.Clear();
            cmboNiveau.SelectedIndex = -1;

            // Actualiser la ListView
            lstvSportifs.Items.Clear();

            List<Sportif> listeSportifs = SportifDAO.GetAll();

            foreach (Sportif sportif in listeSportifs)
            {
                ListViewItem ligne = new ListViewItem(sportif.IdSportif.ToString());

                ligne.SubItems.Add(sportif.NomSportif);
                ligne.SubItems.Add(sportif.PrenomSportif);
                ligne.SubItems.Add(sportif.DateNaissanceSportif.ToString("dd/MM/yyyy"));
                ligne.SubItems.Add(sportif.RueSportif);
                ligne.SubItems.Add(sportif.CodePostalSportif);
                ligne.SubItems.Add(sportif.VilleSportif);
                ligne.SubItems.Add(sportif.NiveauSportif);
                ligne.SubItems.Add(sportif.SportSportif);

                lstvSportifs.Items.Add(ligne);
            }
        }

        private void btnReinitialiser_Click(object sender, EventArgs e)
        {
            lstvAffiche.Items.Clear();
            List<Sportif> listeSportifs = SportifDAO.GetAll();
            
            foreach (Sportif sportif in listeSportifs)
            {
                ListViewItem ligne = new ListViewItem(sportif.IdSportif.ToString());
                ligne.SubItems.Add(sportif.NomSportif);
                ligne.SubItems.Add(sportif.PrenomSportif);
                ligne.SubItems.Add(sportif.DateNaissanceSportif.ToString());
                ligne.SubItems.Add(sportif.RueSportif);
                ligne.SubItems.Add(sportif.CodePostalSportif);
                ligne.SubItems.Add(sportif.VilleSportif);
                ligne.SubItems.Add(sportif.NiveauSportif);
                ligne.SubItems.Add(sportif.SportSportif);

                lstvAffiche.Items.Add(ligne);
            }
        }

        private void btnVider_Click(object sender, EventArgs e)
        {
            txtNom.Clear();
            txtPrenom.Clear();
            txtRue.Clear();
            txtCP.Clear();
            txtVille.Clear();
            txtSport.Clear();

            cmboNiveau.SelectedIndex = -1;

            dtpDateN.Value = DateTime.Today;

            lstvSportifs.SelectedItems.Clear();

            txtNom.Focus();
        }

        private void lstvPratiques_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnAjouterSport_Click(object sender, EventArgs e)
        {
            // Vérifier qu'un sportif est sélectionné
            if (lstvSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sportif.");
                return;
            }

            // Vérifier les champs
            if (txtSport.Text.Trim() == "" || cmboNiveau.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un sport et un niveau.");
                return;
            }

            // Récupérer l'ID du sportif
            int id = int.Parse(lstvSportifs.SelectedItems[0].SubItems[0].Text);

            // Ajouter le sport dans la BDD
            string resultat = SportifDAO.AjouterPratique(
                id,
                txtSport.Text.Trim(),
                cmboNiveau.SelectedItem.ToString()
            );

            MessageBox.Show(resultat);

            // Actualiser la liste des pratiques
            if (resultat == "Le sport a été ajouté avec succès.")
            {
                lstvPratiques.Items.Clear();

                List<string[]> pratiques = SportifDAO.GetPratiques(id);

                foreach (string[] pratique in pratiques)
                {
                    ListViewItem ligne = new ListViewItem(pratique[0]);
                    ligne.SubItems.Add(pratique[1]);

                    lstvPratiques.Items.Add(ligne);
                }

                txtSport.Clear();
                cmboNiveau.SelectedIndex = -1;
            }
        }

        private void lstvPratiques_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (lstvPratiques.SelectedItems.Count > 0)
            {
                ListViewItem ligne = lstvPratiques.SelectedItems[0];

                cmboNiveau.Text = ligne.SubItems[1].Text;
            }
        }

        private void btnModifierNiveau_Click(object sender, EventArgs e)
        {
            // Vérifier qu'un sportif est sélectionné
            if (lstvSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sportif.");
                return;
            }

            // Vérifier qu'un sport est sélectionné
            if (lstvPratiques.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sport.");
                return;
            }

            // Vérifier le niveau
            if (cmboNiveau.SelectedItem == null)
            {
                MessageBox.Show("Veuillez choisir un niveau.");
                return;
            }

            // Récupérer les informations
            int id = int.Parse(lstvSportifs.SelectedItems[0].SubItems[0].Text);

            string sport = lstvPratiques.SelectedItems[0].SubItems[0].Text;

            string niveau = cmboNiveau.SelectedItem.ToString();

            // Modifier le niveau
            string resultat = SportifDAO.ModifierNiveau(id, sport, niveau);

            MessageBox.Show(resultat);

            // Actualiser la liste des pratiques
            lstvPratiques.Items.Clear();

            List<string[]> pratiques = SportifDAO.GetPratiques(id);

            foreach (string[] pratique in pratiques)
            {
                ListViewItem ligne = new ListViewItem(pratique[0]);
                ligne.SubItems.Add(pratique[1]);

                lstvPratiques.Items.Add(ligne);
            }
        }

        private void btnSupprimerPratique_Click(object sender, EventArgs e)
        {
            // Vérifier qu'un sportif est sélectionné
            if (lstvSportifs.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sportif.");
                return;
            }

            // Vérifier qu'un sport est sélectionné
            if (lstvPratiques.SelectedItems.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un sport.");
                return;
            }

            // Récupérer les informations
            int id = int.Parse(lstvSportifs.SelectedItems[0].SubItems[0].Text);

            string sport = lstvPratiques.SelectedItems[0].SubItems[0].Text;

            // Demander confirmation
            DialogResult reponse = MessageBox.Show(
                "Voulez-vous vraiment supprimer cette pratique sportive ?",
                "Confirmation de suppression",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning
            );

            if (reponse == DialogResult.No)
            {
                return;
            }

            // Supprimer la pratique
            string resultat = SportifDAO.SupprimerPratique(id, sport);

            MessageBox.Show(resultat);

            // Actualiser la liste
            if (resultat == "La pratique sportive a été supprimée avec succès.")
            {
                lstvPratiques.Items.Clear();

                List<string[]> pratiques = SportifDAO.GetPratiques(id);

                foreach (string[] pratique in pratiques)
                {
                    ListViewItem ligne = new ListViewItem(pratique[0]);
                    ligne.SubItems.Add(pratique[1]);

                    lstvPratiques.Items.Add(ligne);
                }
            }
        }
    }
}