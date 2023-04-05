using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Commande (réunit les informations communes à toutes les commandes : Livre, Revue, Dvd)
    /// </summary>
    public class Commande 
    {
        /// <summary>
        /// Récupère ou définit l'id de la commande
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Récupère ou définit la date de la commande
        /// </summary>
        public DateTime DateCommande { get; set; }

        /// <summary>
        /// Récupère ou définit le montant de la commande
        /// </summary>
        public double Montant { get; set; }

        /// <summary>
        /// Initialisation d'un nouvel objet Commande
        /// </summary>
        /// <param name="id">Id de la commande</param>
        /// <param name="dateCommande">Date de la commande</param>
        /// <param name="montant">Montant de la commande</param>
        public Commande(string id, DateTime dateCommande, double montant)
        {
            this.Id = id;
            this.DateCommande = dateCommande;
            this.Montant = montant;
        }
    }
}
