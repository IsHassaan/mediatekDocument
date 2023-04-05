
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Categorie (réunit les informations des classes Public, Genre et Rayon)
    /// </summary>
    public class Categorie
    {
        /// <summary>
        /// Récupère ou définit l'id de la catégorie
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        /// Récupère ou définit le libelle de la catégorie
        /// </summary>
        public string Libelle { get; set; }

        /// <summary>
        /// Initialisation d'un nouvel objet Categorie
        /// </summary>
        /// <param name="id">Id de la catégorie</param>
        /// <param name="libelle">Libelle de la catégorie</param>
        public Categorie(string id, string libelle)
        {
            this.Id = id;
            this.Libelle = libelle;
        }

        /// <summary>
        /// Récupération du libellé pour l'affichage dans les combos
        /// </summary>
        /// <returns>Libelle</returns>
        public override string ToString()
        {
            return this.Libelle;
        }

    }
}
