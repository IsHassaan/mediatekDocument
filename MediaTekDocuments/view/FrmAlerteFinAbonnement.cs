using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Classe d'affichage de l'alerte de fin d'abonnement
    /// </summary>
    public partial class FrmAlerteFinAbonnement : Form
    {
        private readonly BindingSource bdgAbonnementsAEcheance = new BindingSource();
        private readonly List<Abonnement> lesAbonnementsAEcheance = new List<Abonnement>();

        /// <summary>
        /// Constructeur : création du contrôleur lié à ce formulaire
        /// </summary>
        /// <param name="controller">Controller</param>
        public FrmAlerteFinAbonnement(FrmMediatekController controller)
        {
            InitializeComponent();
            lesAbonnementsAEcheance = controller.GetAbonnementsAlerte();
            RemplirAbonnementsAEcheance(lesAbonnementsAEcheance);
        }

        /// <summary>
        /// Remplissage de la grille des abonnements qui se terminent
        /// </summary>
        /// <param name="lesAbonnementsAEcheance">Liste des abonnements à échéance</param>
        private void RemplirAbonnementsAEcheance(List<Abonnement> lesAbonnementsAEcheance)
        {
            bdgAbonnementsAEcheance.DataSource = lesAbonnementsAEcheance;
            dgvAbonnementsAEcheance.DataSource = bdgAbonnementsAEcheance;
            dgvAbonnementsAEcheance.Columns["dateCommande"].Visible = false;
            dgvAbonnementsAEcheance.Columns["montant"].Visible = false;
            dgvAbonnementsAEcheance.Columns["idRevue"].Visible = false;
            dgvAbonnementsAEcheance.Columns["id"].Visible = false;
            dgvAbonnementsAEcheance.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            dgvAbonnementsAEcheance.Columns[0].HeaderCell.Value = "Date de fin d'abonnement";
            dgvAbonnementsAEcheance.Columns[1].HeaderCell.Value = "Titre";
        }

        /// <summary>
        /// Tri sur les colonnes
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void dgvAbonnementsAEcheance_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string titreColonne = dgvAbonnementsAEcheance.Columns[e.ColumnIndex].HeaderText;
            List<Abonnement> sortedList = new List<Abonnement>();
            switch (titreColonne)
            {
                case "Titre":
                    sortedList = lesAbonnementsAEcheance.OrderBy(o => o.Titre).ToList();
                    break;
                case "Date de fin d'abonnement":
                    sortedList = lesAbonnementsAEcheance.OrderBy(o => o.DateFinAbonnement).Reverse().ToList();
                    break;
            }
            RemplirAbonnementsAEcheance(sortedList);
        }

        /// <summary>
        /// Fermeture de la fenêtre d'alerte
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOk_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
