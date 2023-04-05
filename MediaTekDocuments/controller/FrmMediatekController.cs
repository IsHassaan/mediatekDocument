using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.dal;
using System;

namespace MediaTekDocuments.controller
{
    /// <summary>
    /// Controleur pour la fenêtre FrmMediatek
    /// Gère les interactions entre la vue et le modèle
    /// </summary>
    public class FrmMediatekController
    {
        /// <summary>
        /// Objet d'accès aux données
        /// </summary>
        private readonly Access access;

        /// <summary>
        /// Récupération de l'instance unique d'accès aux données
        /// </summary>
        public FrmMediatekController()
        {
            access = Access.GetInstance();
        }

        /// <summary>
        /// getter genres
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            return access.GetAllGenres();
        }

        /// <summary>
        /// getter livres
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            return access.GetAllLivres();
        }

        /// <summary>
        /// getter sur la liste des Dvd
        /// </summary>
        /// <returns>Liste d'objets dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            return access.GetAllDvd();
        }

        /// <summary>
        /// getter revues
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            return access.GetAllRevues();
        }

        /// <summary>
        /// getter rayons
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            return access.GetAllRayons();
        }

        /// <summary>
        /// commandes de document
        /// </summary>
        /// <param name="idDocument"></param>
        /// <returns></returns>

        public List<Commande> GetCommandes(string idDocument)
        {
            return access.GetCommandes(idDocument);
        }

        /// <summary>
        /// getter publics
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            return access.GetAllPublics();
        }

        /// <summary>
        /// exemplaires revue
        /// </summary>
        /// <param name="idDocument">id revue</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            return access.GetExemplairesRevue(idDocument);
        }

        /// <summary>
        /// getter suivis
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            return access.GetAllSuivis();
        }


        /// <summary>
        /// commandes de document
        /// </summary>
        /// <param name="idDocument">id documen</param>
        /// <returns>Liste d'objets CommandeDocument</returns>
        public List<CommandeDocument> GetCommandesDocument(string idDocument)
        {
            return access.GetCommandesDocument(idDocument);
        }

        /// <summary>
        /// récupère les abonnements qui prennent fin dans 30 jours
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsAlerte()
        {
            return access.GetAbonnementsAlerte();
        }

        /// <summary>
        /// récupère les exemplaires d'un document
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesDocument(string idDocument)
        {
            return access.GetExemplairesDocument(idDocument);
        }


        /// <summary>
        /// récupère les abonnements d'une revue
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementRevue(string idDocument)
        {
            return access.GetAbonnementRevue(idDocument);
        }

        /// <summary>
        /// récupère les documents
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Document</returns>
        public List<Document> GetAllDocuments(string idDocument)
        {
            return access.GetAllDocuments(idDocument);
        }

        /// <summary>
        /// Crée un exemplaire d'une revue dans la bdd
        /// </summary>
        /// <param name="id">Id du document correspondant à l'exemplaire d'une revue à insérer</param>
        /// <param name="numero">Numéro de l'exemplaire d'une revue à insérer</param>
        /// <param name="dateAchat">Date d'achat de l'exemplaire d'une revue</param>
        /// <param name="photo">Photo de l'exemplaire de la revue</param>
        /// <param name="idEtat">Id de l'état d'usure de l'exemplaire d'une revue</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerExemplaireRevue(string id, int numero, DateTime dateAchat, string photo, string idEtat)
        {
            return access.CreerExemplaireRevue(id, numero, dateAchat, photo, idEtat);
        }


        /// <summary>
        /// Select états
        /// </summary>
        /// <returns>Liste d'objets Etat</returns>
        public List<Etat> GetAllEtatsDocument()
        {
            return access.GetAllEtatsDocument();
        }

        /// <summary>
        /// Création d'un document 
        /// </summary>
        /// <param name="Id">Id document</param>
        /// <param name="Titre">Titre</param>
        /// <param name="Image">Image</param>
        /// <param name="IdGenre">Id document</param>
        /// <param name="IdPublic">Id public document</param>
        /// <param name="IdRayon">Id rayon document</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerDocument(string Id, string Titre, string Image, string IdRayon, string IdPublic, string IdGenre)
        {
            return access.CreerDocument(Id, Titre, Image, IdRayon, IdPublic, IdGenre);
        }

        /// <summary>
        /// Modification d'un document
        /// </summary>
        /// <param name="Id">Id document</param>
        /// <param name="Titre">Titre document</param>
        /// <param name="Image">Image document</param>
        /// <param name="IdGenre">Id genre document</param>
        /// <param name="IdPublic">Id public document</param>
        /// <param name="IdRayon">Id rayon document</param>
        /// <returns>Retourne vrai si la modification est effectuée</returns>
        public bool ModifierDocument(string Id, string Titre, string Image, string IdGenre, string IdPublic, string IdRayon)
        {
            return access.ModifierDocument(Id, Titre, Image, IdGenre, IdPublic, IdRayon);
        }

        /// <summary>
        /// Création d'un livre
        /// </summary>
        /// <param name="Id">Id livre </param>
        /// <param name="Isbn">Code Isbn livre</param>
        /// <param name="Auteur">Auteur livre</param>
        /// <param name="Collection">Collection livre</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerLivre(string Id, string Isbn, string Auteur, string Collection)
        {
            return access.CreerLivre(Id, Isbn, Auteur, Collection);
        }

        /// <summary>
        /// Modification d'un livre
        /// </summary>
        /// <param name="Id">Id du livre à modifier</param>
        /// <param name="Isbn">Code Isbn livre</param>
        /// <param name="Auteur">Auteur livre</param>
        /// <param name="Collection">Collection livre</param>
        /// <returns>Retourne vrai si la modification est effectuée</returns>
        public bool ModifierLivre(string Id, string Isbn, string Auteur, string Collection)
        {
            return access.ModifierLivre(Id, Isbn, Auteur, Collection);
        }

        /// <summary>
        /// Suppression d'un livre
        /// </summary>
        /// <param name="Id">Id livre</param>
        /// <returns>Retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerLivre(string Id)
        {
            return access.SupprimerLivre(Id);
        }

        /// <summary>
        /// Création d'un Dvd 
        /// </summary>
        /// <param name="Id">Id dvd </param>
        /// <param name="Synopsis">Synopsis dvd</param>
        /// <param name="Realisateur">Réalisateur dvd</param>
        /// <param name="Duree">Durée dvd</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerDvd(string Id, string Synopsis, string Realisateur, int Duree)
        {
            return access.CreerDvd(Id, Synopsis, Realisateur, Duree);
        }

        /// <summary>
        /// Modification dvd
        /// </summary>
        /// <param name="Id">Id dvd</param>
        /// <param name="Synopsis">Synopsis dvd</param>
        /// <param name="Realisateur">Réalisateur dvd</param>
        /// <param name="Duree">Durée dvd</param>
        /// <returns>Retourne vraie si la modification est effectuée</returns>
        public bool ModifierDvd(string Id, string Synopsis, string Realisateur, int Duree)
        {
            return access.ModifierDvd(Id, Synopsis, Realisateur, Duree);
        }

        /// <summary>
        /// Suppression d'un dvd
        /// </summary>
        /// <param name="Id">Id du dvd à supprimer</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerDvd(string Id)
        {
            return access.SupprimerDvd(Id);
        }

        /// <summary>
        /// Création revue
        /// </summary>
        /// <param name="Id">Id revue</param>
        /// <param name="Periodicite">Périodicité</param>
        /// <param name="DelaiMiseADispo">Délaide mise à disposition</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerRevue(string Id, string Periodicite, int DelaiMiseADispo)
        {
            return access.CreerRevue(Id, Periodicite, DelaiMiseADispo);
        }


        /// <summary>
        /// Suppression document
        /// </summary>
        /// <param name="Id">Id document à supprimer</param>
        /// <returns>Retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerDocument(string Id)
        {
            return access.SupprimerDocument(Id);
        }



        /// <summary>
        /// Suppression d'une revue 
        /// </summary>
        /// <param name="Id">Id revue</param>
        /// <returns>Retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerRevue(string Id)
        {
            return access.SupprimerRevue(Id);
        }

        /// <summary>
        /// Création d'une commande
        /// </summary>
        /// <param name="commande">Commande</param>
        /// <returns>Retourne vrai si l'ajout est effectué</returns>
        public bool CreerCommande(Commande commande)
        {
            return access.CreerCommande(commande);
        }

        /// <summary>
        /// Création d'une commande de document
        /// </summary>
        /// <param name="id">Id commande de document</param>
        /// <param name="nbExemplaire">Nombre d'exemplaires de la commande de document</param>
        /// <param name="idLivreDvd">Id livreDvd commande de document</param>
        /// <param name="idSuivi">Id étape de suivi de la commande de document</param>
        /// <returns>retourne vrai si la création est effectuée</returns>
        public bool CreerCommandeDocument(string id, int nbExemplaire, string idLivreDvd, string idSuivi)
        {
            return access.CreerCommandeDocument(id, nbExemplaire, idLivreDvd, idSuivi);
        }

        /// <summary>
        /// Modification de l'étape de suivi d'une commande
        /// </summary>
        /// <param name="id">Id commande de document</param>
        /// <param name="idSuivi">Id étape de suivi</param>
        /// <returns>retourne vrai si la modification est effectuée</returns>
        internal bool ModifierSuiviCommandeDocument(string id, string idSuivi)
        {
            return access.ModifierSuiviCommandeDocument(id, idSuivi);
        }


        /// <summary>
        /// Modification d'une revue
        /// </summary>
        /// <param name="Id">Id revue</param>
        /// <param name="Periodicite">Périodicité revue</param>
        /// <param name="DelaiMiseADispo">Délai de mise à disposition de la revue</param>
        /// <returns>retourne vrai si la modification est effectuée</returns>
        public bool ModifierRevue(string Id, string Periodicite, int DelaiMiseADispo)
        {
            return access.ModifierRevue(Id, Periodicite, DelaiMiseADispo);
        }


        /// <summary>
        /// Suppression de la commande de document
        /// </summary>
        /// <param name="commandesDocument"> CommandeDocument</param>
        /// <returns>retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commandesDocument)
        {
            return access.SupprimerCommandeDocument(commandesDocument);
        }

        /// <summary>
        /// Création d'un abonnement de revue
        /// </summary>
        /// <param name="id">Id abonnement</param>
        /// <param name="dateFinAbonnement">Date fin abonnement</param>
        /// <param name="idRevue">Id revue</param>
        /// <returns>retourne vraie si la création est effectuée</returns>
        public bool CreerAbonnementRevue(string id, DateTime dateFinAbonnement, string idRevue)
        {
            return access.CreerAbonnementRevue(id, dateFinAbonnement, idRevue);
        }

        /// <summary>
        /// Modification de l'état d'un exemplaire d'un document
        /// </summary>
        /// <param name="exemplaire">Exemplaire</param>
        /// <returns>retourne vrai si la modification est effectuée</returns>
        public bool ModifierEtatExemplaireDocument(Exemplaire exemplaire)
        {
            return access.ModifierEtatExemplaireDocument(exemplaire);
        }

        /// <summary>
        /// Suppression d'un exemplaire d'un document 
        /// </summary>
        /// <param name="exemplaire">Exemplaire</param>
        /// <returns>retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerExemplaireDocument(Exemplaire exemplaire)
        {
            return access.SupprimerExemplaireDocument(exemplaire);
        }

        /// <summary>
        /// Suppression revue
        /// </summary>
        /// <param name="abonnement">abonnement</param>
        /// <returns>retourne vrai si la suppression est effectuée</returns>
        public bool SupprimerAbonnementRevue(Abonnement abonnement)
        {
            return access.SupprimerAbonnementRevue(abonnement);
        }
    }
}
