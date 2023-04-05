
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Livre hérite de LivreDvd : contient des propriétés spécifiques aux livres
    /// </summary>
    public class Livre : LivreDvd
    {
        /// <summary>
        /// Récupère le code Isbn du livre
        /// </summary>
        public string Isbn { get; }

        /// <summary>
        /// Récupère l'auteur du livre
        /// </summary>
        public string Auteur { get; }

        /// <summary>
        /// Récupère la collection du livre
        /// </summary>
        public string Collection { get; }

        /// <summary>
        /// Initialisation d'un objet Livre
        /// </summary>
        /// <param name="id">Id du livre</param>
        /// <param name="titre">Titre du livre</param>
        /// <param name="image">Image du livre</param>
        /// <param name="isbn">Code Isbn du livre</param>
        /// <param name="auteur">Auteur du livre</param>
        /// <param name="collection">Collection du livre</param>
        /// <param name="idGenre">Id du genre du livre</param>
        /// <param name="genre">Genre du livre</param>
        /// <param name="idPublic">Id du public du livre</param>
        /// <param name="lePublic">Public du livre</param>
        /// <param name="idRayon">Id du rayon du livre</param>
        /// <param name="rayon">Rayon du livre</param>
        public Livre(string id, string titre, string image, string isbn, string auteur, string collection,
            string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon)
            : base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
        {
            this.Isbn = isbn;
            this.Auteur = auteur;
            this.Collection = collection;
        }
    }
}
