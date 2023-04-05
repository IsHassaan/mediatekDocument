using System;

namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Exemplaire (exemplaire d'une revue)
    /// </summary>
    public class Exemplaire
    {
        /// <summary>
        /// Récupère ou définit le numéro d'un exemplaire
        /// </summary>
        public int Numero { get; set; }

        /// <summary>
        /// Récupère ou définit la photo d'un exemplaire
        /// </summary>
        public string Photo { get; set; }

        /// <summary>
        /// Récupère ou définit la date d'achat d'un exemplaire
        /// </summary>
        public DateTime DateAchat { get; set; }

        /// <summary>
        /// Récupère ou définit l'id de l'état d'usure d'un exemplaire
        /// </summary>
        public string IdEtat { get; set; }

        /// <summary>
        /// Récupère ou définit l'id du document correspondant à l'exemplaire
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Récupère ou définit le libelle de l'état d'usure d'un exemplaire
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation d'un objet Exemplaire
        /// </summary>
        /// <param name="numero">Numero del'exemplaire</param>
        /// <param name="dateAchat">Date d'achat de l'exemplaire</param>
        /// <param name="photo">Photo de l'exemplaire</param>
        /// <param name="idEtat">Id de l'état d'usure de l'exemplaire</param>
        /// <param name="idDocument">Id du document correspondant à l'exemplaire</param>
        /// <param name="libelle">Libelle de l'état d'usure de l'exemplaire</param>
        public Exemplaire(int numero, DateTime dateAchat, string photo, string idEtat, string idDocument, string libelle)
        {
            this.Numero = numero;
            this.DateAchat = dateAchat;
            this.Photo = photo;
            this.IdEtat = idEtat;
            this.Id = idDocument;
            this.Libelle = libelle;
        }

    }
}
