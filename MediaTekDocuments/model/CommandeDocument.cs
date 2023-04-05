using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier CommandeDocument hérite de Commande : contient des propriétés spécifiques aux Commandes de documents (livre, dvd)
    /// </summary>
    public class CommandeDocument : Commande
    {
        /// <summary>
        /// Récupère ou définit le nombre d'exemplaires de la commande de document
        /// </summary>
        public int NbExemplaire { get; set; }

        /// <summary>
        /// Récupère ou définit l'id du livreDvd de la commande de document
        /// </summary>
        public string IdLivreDvd { get; set; }

        /// <summary>
        /// Récupère ou définit l'id de l'étape de suivi de la commande de document
        /// </summary>
        public string IdSuivi { get; set; }

        /// <summary>
        /// Récupère ou définit le libelle de l'étape de suivi de la commande de document
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation d'un nouvel objet CommandeDocument
        /// </summary>
        /// <param name="id">Id de la commande de document</param>
        /// <param name="dateCommande">Date de la commande de document</param>
        /// <param name="montant">Montant de la commande de document</param>
        /// <param name="nbExemplaire">Nombre d'exemplaire de la commande de document</param>
        /// <param name="idLivreDvd">Id du LivreDvd correspondant à la commande de document</param>
        /// <param name="idSuivi">Id de l'étape de suivi correspondant à la commande de document</param>
        /// <param name="libelle">Id du libelle de l'étape de suivi correspondant à la commande de document</param>
        public CommandeDocument(string id, DateTime dateCommande, double montant, int nbExemplaire, string idLivreDvd, string idSuivi, string libelle)
            : base(id, dateCommande, montant)
        {
            this.NbExemplaire = nbExemplaire;
            this.IdLivreDvd = idLivreDvd;
            this.IdSuivi = idSuivi;
            this.Libelle = libelle;
        }
    }
}
