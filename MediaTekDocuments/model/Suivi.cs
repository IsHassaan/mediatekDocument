using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe  Suivi
    /// </summary>
    public class Suivi
    {
        /// <summary>
        /// Définition de l'état de la command
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Définition du libelle du suivi
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation de l'objet Suivi
        /// </summary>
        /// <param name="id">Id du Suivi d'une commande</param>
        /// <param name="libelle">Libelle du Suivi d'une commande</param>
        public Suivi(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }
    }
}
