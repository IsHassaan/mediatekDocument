using System;
using MediaTekDocuments.controller;
using MediaTekDocuments.model;
using System.Windows.Forms;

namespace MediaTekDocuments.view
{
    /// <summary>
    /// Classe d'affichage de la fenêtre d'authentification
    /// </summary>
    public partial class FrmAuthentification : Form
    {
        private readonly FrmAuthentificationController controller;

        /// <summary>
        /// Constructeur : création du controller authentifiaction
        /// </summary>
        public FrmAuthentification()
        {
            InitializeComponent();
            this.controller = new FrmAuthentificationController();
        }

        /// <summary>
        /// Vérification des identifiants pour l'accès à l'application
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnexion_Click(object sender, EventArgs e)
        {
            string login = txbLogin.Text;
            string password = txbPassword.Text;

            if (!txbLogin.Text.Equals("") && !txbPassword.Text.Equals(""))
            {
                Service service = controller.GetAbonnementsAlerte(login, password);

                if (service == null)
                {
                    MessageBox.Show("Mauvais identifiants", "Alerte");
                    txbPassword.Text = "";
                }
                else if(service.Libelle == "culture")
                {
                    MessageBox.Show("Droits d'accès inconnues.", "Alerte");
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show("Identifiants valides");
                    FrmMediatek frmMediatek = new FrmMediatek(service);
                    frmMediatek.ShowDialog();
                }
            }
            else
            {
                MessageBox.Show("Veuillez saisir tous les champs");
            }
        }
    }
}
