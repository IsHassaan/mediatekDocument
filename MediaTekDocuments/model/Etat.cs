
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Etat (état d'usure d'un document)
    /// </summary>
    public class Etat
    {
        /// <summary>
        /// Récupère l'id de l'état d'usure d'un document
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Récupère le libelle de l'état d'usure d'un document
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation d'un objet Etat
        /// </summary>
        /// <param name="id">Id de l'état d'usure d'un document</param>
        /// <param name="libelle">Libelle de l'état d'usure d'un document</param>
        public Etat(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

    }
}
