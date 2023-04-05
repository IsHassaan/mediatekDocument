
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Rayon (rayon de classement du document) hérite de Categorie
    /// </summary>
    public class Rayon : Categorie
    {
        /// <summary>
        /// Initialisation d'un objet Rayon
        /// </summary>
        /// <param name="id">Id du rayon</param>
        /// <param name="libelle">Libelle du rayon</param>
        public Rayon(string id, string libelle) : base(id, libelle)
        {
        }

    }
}
