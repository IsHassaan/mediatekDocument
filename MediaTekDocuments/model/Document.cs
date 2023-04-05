
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Document (réunit les infomations communes à tous les documents : Livre, Revue, Dvd)
    /// </summary>
    public class Document
    {
        /// <summary>
        /// Récupère l'identifiant du document
        /// </summary>
        public string Id { get; }

        /// <summary>
        /// Récupère le titre du document
        /// </summary>
        public string Titre { get; }

        /// <summary>
        /// Récupère l'image du document
        /// </summary>
        public string Image { get; }

        /// <summary>
        /// Récupère l'id du genre correspondant au document
        /// </summary>
        public string IdGenre { get; }

        /// <summary>
        /// Récupère le genre correspondant au document
        /// </summary>
        public string Genre { get; }

        /// <summary>
        /// Récupère l'id du public correspondant au document
        /// </summary>
        public string IdPublic { get; }

        /// <summary>
        /// Récupère le public correspondant au document
        /// </summary>
        public string Public { get; }

        /// <summary>
        /// Récupère l'id du rayon correspondant au document
        /// </summary>
        public string IdRayon { get; }

        /// <summary>
        /// Récupère le rayon correspondant au document
        /// </summary>
        public string Rayon { get; }

        /// <summary>
        /// Initialisation d'un nouvel objet Document
        /// </summary>
        /// <param name="id">Id du document</param>
        /// <param name="titre">Titre du document</param>
        /// <param name="image">Image du document</param>
        /// <param name="idGenre">Id du genre du document</param>
        /// <param name="genre">Genre du document</param>
        /// <param name="idPublic">Id du public du document</param>
        /// <param name="lePublic">Public du document</param>
        /// <param name="idRayon">Id du rayon du document</param>
        /// <param name="rayon">Rayon du document</param>
        public Document(string id, string titre, string image, string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon)
        {
            Id = id;
            Titre = titre;
            Image = image;
            IdGenre = idGenre;
            Genre = genre;
            IdPublic = idPublic;
            Public = lePublic;
            IdRayon = idRayon;
            Rayon = rayon;
        }
    }
}
