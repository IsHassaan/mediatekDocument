
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Genre : hérite de Categorie
    /// </summary>
    public class Genre : Categorie
    {
        /// <summary>
        /// Initialisation d'un objet Genre
        /// </summary>
        /// <param name="id">Id de la catégorie</param>
        /// <param name="libelle">Libelle de la catégorie</param>
        public Genre(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
