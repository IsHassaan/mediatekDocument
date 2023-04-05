
namespace MediaTekDocuments.model
{
    /// <summary>
    /// Classe métier Dvd hérite de LivreDvd : contient des propriétés spécifiques aux dvd
    /// </summary>
    public class Dvd : LivreDvd
    {
        /// <summary>
        /// Récupère la durée d'un Dvd
        /// </summary>
        public int Duree { get; }

        /// <summary>
        /// Récupère le réalisateur d'un Dvd
        /// </summary>
        public string Realisateur { get; }

        /// <summary>
        /// Récupère le synopsis d'un Dvd
        /// </summary>
        public string Synopsis { get; }

        /// <summary>
        /// Initialisation d'un objet Dvd
        /// </summary>
        /// <param name="id">Id du Dvd</param>
        /// <param name="titre">Titre du Dvd</param>
        /// <param name="image">Image du Dvd</param>
        /// <param name="duree">Durée du Dvd</param>
        /// <param name="realisateur">Réalisateur du Dvd</param>
        /// <param name="synopsis">Synopsis du Dvd</param>
        /// <param name="idGenre">Id du genre du Dvd</param>
        /// <param name="genre">Genre du Dvd</param>
        /// <param name="idPublic">Id du public du Dvd</param>
        /// <param name="lePublic">Public du Dvd</param>
        /// <param name="idRayon">Id du rayon du Dvd</param>
        /// <param name="rayon">Rayon du Dvd</param>
        public Dvd(string id, string titre, string image, int duree, string realisateur, string synopsis,
            string idGenre, string genre, string idPublic, string lePublic, string idRayon, string rayon)
            : base(id, titre, image, idGenre, genre, idPublic, lePublic, idRayon, rayon)
        {
            this.Duree = duree;
            this.Realisateur = realisateur;
            this.Synopsis = synopsis;
        }

    }
}
