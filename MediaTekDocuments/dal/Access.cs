using System;
using System.Collections.Generic;
using MediaTekDocuments.model;
using MediaTekDocuments.manager;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Linq;
using System.Configuration;
using Serilog;
using Serilog.Formatting.Json;

namespace MediaTekDocuments.dal
{
    /// <summary>
    /// Classe d'accès aux données
    /// </summary>
    public class Access
    {
        /// <summary>
        /// adresse de l'API
        /// </summary>
        private static readonly string uriApi = "hokoapp.online";
        /// <summary>
        /// nom de connexion à la bdd
        /// </summary>
        private static readonly string connectionName = "MediaTekDocuments.Properties.Settings.mediatek86ConnectionString";
        /// <summary>
        /// instance unique de la classe
        /// </summary>
        private static Access instance = null;
        /// <summary>
        /// instance de ApiRest pour envoyer des demandes vers l'api et recevoir la réponse
        /// </summary>
        private readonly ApiRest api = null;
        /// <summary>
        /// méthode HTTP pour select
        /// </summary>
        private const string GET = "GET";
        /// <summary>
        /// méthode HTTP pour insert
        /// </summary>
        private const string POST = "POST";
        /// <summary>
        /// méthode HTTP pour update
        /// </summary>
        private const string PUT = "PUT";
        /// <summary>
        /// méthode HTTP pour delete
        /// </summary>
        private const string DELETE = "DELETE";

        /// <summary>
        /// Récupération de la chaîne de connexion
        /// </summary>
        /// <param name="name">nom de la chaîne de connexion</param>
        /// <returns></returns>
        static string GetConnectionStringByName(string name)
        {
            string value = null;
            ConnectionStringSettings settings = ConfigurationManager.ConnectionStrings[name];
            if (settings != null)
                value = settings.ConnectionString;
            return value;
        }

        /// <summary>
        /// Méthode privée pour créer un singleton
        /// initialise l'accès à l'API
        /// </summary>
        private Access()
        {
            String authenticationString;
            try
            {
                authenticationString = GetConnectionStringByName(connectionName);

                Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Information()
                .WriteTo.Console()
                .WriteTo.File(new JsonFormatter(), "logs/log.txt",
                rollingInterval: RollingInterval.Day)
                .CreateLogger();

                api = ApiRest.GetInstance(uriApi, authenticationString);
            }
            catch (Exception e)
            {
                Log.Fatal("Access.Access catch connectionString={0} erreur={1}", connectionName, e.Message);
                Environment.Exit(0);
            }

        }

        /// <summary>
        /// Création et retour de l'instance unique de la classe
        /// </summary>
        /// <returns>instance unique de la classe</returns>
        public static Access GetInstance()
        {
            if (instance == null)
            {
                instance = new Access();
            }
            return instance;
        }

        /// <summary>
        /// Retourne tous les genres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Genre</returns>
        public List<Categorie> GetAllGenres()
        {
            IEnumerable<Genre> lesGenres = TraitementRecup<Genre>(GET, "genre");
            return new List<Categorie>(lesGenres);
        }

        /// <summary>
        /// Retourne tous les rayons à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Rayon</returns>
        public List<Categorie> GetAllRayons()
        {
            IEnumerable<Rayon> lesRayons = TraitementRecup<Rayon>(GET, "rayon");
            return new List<Categorie>(lesRayons);
        }

        /// <summary>
        /// Retourne toutes les catégories de public à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Public</returns>
        public List<Categorie> GetAllPublics()
        {
            IEnumerable<Public> lesPublics = TraitementRecup<Public>(GET, "public");
            return new List<Categorie>(lesPublics);
        }

        /// <summary>
        /// Retourne toutes les livres à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Livre</returns>
        public List<Livre> GetAllLivres()
        {
            List<Livre> lesLivres = TraitementRecup<Livre>(GET, "livre");
            return lesLivres;
        }

        /// <summary>
        /// Retourne toutes les dvd à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Dvd</returns>
        public List<Dvd> GetAllDvd()
        {
            List<Dvd> lesDvd = TraitementRecup<Dvd>(GET, "dvd");
            return lesDvd;
        }

        /// <summary>
        /// Retourne toutes les revues à partir de la BDD
        /// </summary>
        /// <returns>Liste d'objets Revue</returns>
        public List<Revue> GetAllRevues()
        {
            List<Revue> lesRevues = TraitementRecup<Revue>(GET, "revue");
            return lesRevues;
        }


        /// <summary>
        /// Retourne les exemplaires d'une revue
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesRevue(string idDocument)
        {
            List<Exemplaire> lesExemplaires = TraitementRecup<Exemplaire>(GET, "exemplaire/" + idDocument);
            return lesExemplaires;
        }

        /// <summary>
        /// Retourne les exemplaires d'un document
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Exemplaire</returns>
        public List<Exemplaire> GetExemplairesDocument(string idDocument)
        {
            List<Exemplaire> lesExemplairesDocument = TraitementRecup<Exemplaire>(GET, "exemplairesdocument/" + idDocument);
            return lesExemplairesDocument;
        }

        /// <summary>
        /// Retourne les suivis d'un document
        /// </summary>
        /// <returns>Liste d'objets Suivi</returns>
        public List<Suivi> GetAllSuivis()
        {
            List<Suivi> lesSuivis = TraitementRecup<Suivi>(GET, "suivi");
            return lesSuivis;
        }

        /// <summary>
        /// Retourne les commandes
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets CommandeDocument</returns>

        public List<Commande> GetCommandes(string idDocument)
        {
            List<Commande> lesCommandes = TraitementRecup<Commande>(GET, "commande/" + idDocument);
            return lesCommandes;
        }

        /// <summary>
        /// Retourne les commandes des documents
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets CommandeDocument</returns>

        public List<CommandeDocument> GetCommandesDocument(string idDocument)
        {
            List<CommandeDocument> lesCommandesDocument = TraitementRecup<CommandeDocument>(GET, "commandedocument/" + idDocument);
            return lesCommandesDocument;
        }

        /// <summary>
        /// Retourne les documents
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Document</returns>
        public List<Document> GetAllDocuments(string idDocument)
        {
            List<Document> lesDocuments = TraitementRecup<Document>(GET, "document/" + idDocument);
            return lesDocuments;
        }

        /// <summary>
        /// Retourne les abonnements d'une revue
        /// </summary>
        /// <param name="idDocument">id du document concerné</param>
        /// <returns>Liste d'objets Abonnement</returns>
        public List<Abonnement> GetAbonnementRevue(string idDocument)
        {
            List<Abonnement> lesAbonnementsRevue = TraitementRecup<Abonnement>(GET, "abonnement/" + idDocument);
            return lesAbonnementsRevue;
        }

        /// <summary>
        /// Retourne les abonnements qui arrivent à écheance
        /// </summary>
        /// <returns></returns>
        public List<Abonnement> GetAbonnementsAlerte()
        {
            List<Abonnement> lesAbonnementsAEcheance = TraitementRecup<Abonnement>(GET, "abonnementsecheance");
            return lesAbonnementsAEcheance;
        }

        /// <summary>
        /// Retourne les états d'un document
        /// </summary>
        /// <returns>Liste d'objets Etat</returns>
        public List<Etat> GetAllEtatsDocument()
        {
            List<Etat> lesEtats = TraitementRecup<Etat>(GET, "etat");
            return lesEtats;
        }

        /// <summary>
        /// ecriture d'un exemplaire en base de données
        /// </summary>
        /// <param name="exemplaire">exemplaire à insérer</param>
        /// <returns>true si l'insertion a pu se faire (retour != null)</returns>
        public bool CreerExemplaire(Exemplaire exemplaire)
        {
            String jsonExemplaire = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(POST, "exemplaire/" + jsonExemplaire);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerExemplaire catch jsonExemplaire={0} erreur={1} ", jsonExemplaire, ex.Message);
            }
            return false;
        }


        /// <summary>
        /// Ecriture d'un livre en base de données
        /// </summary>
        /// <param name="Id">Id du livre à insérer</param>
        /// <param name="Isbn">Code Isbn du livre</param>
        /// <param name="Auteur">Auteur du livre</param>
        /// <param name="Collection">Collection du livre</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool CreerLivre(string Id, string Isbn, string Auteur, string Collection)
        {
            String jsonCreerLivre = "{ \"id\" : \"" + Id + "\", \"isbn\" : \"" + Isbn + "\", \"auteur\" : \"" + Auteur + "\", \"collection\" : \"" + Collection + "\"}";
            Console.WriteLine("jsonCreerLivre" + jsonCreerLivre);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Document> liste = TraitementRecup<Document>(POST, "livre/" + jsonCreerLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerLivre catch jsonCreerLivre={0} erreur={1} ", jsonCreerLivre, ex.Message);
            }
            return false;
        }


        /// <summary>
        /// Modification d'un livre en  base de données
        /// </summary>
        /// <param name="Id">Id du livre à modifier</param>
        /// <param name="Isbn">Code Isbn du livre</param>
        /// <param name="Auteur">Auteur du livre</param>
        /// <param name="Collection">Collection du livre</param>
        /// <returns>True si l'insertion a pu se faire</returns>
        public bool ModifierLivre(string Id, string Isbn, string Auteur, string Collection)
        {
            String jsonModifierLivre = "{ \"id\" : \"" + Id + "\", \"isbn\" : \"" + Isbn + "\", \"auteur\" : \"" + Auteur + "\", \"collection\" : \"" + Collection + "\"}";
            Console.WriteLine("jsonModifierLivre" + jsonModifierLivre);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Livre> liste = TraitementRecup<Livre>(PUT, "livre/" + Id + "/" + jsonModifierLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierLivre catch jsonModifierLivre={0} erreur={1} ", jsonModifierLivre, ex.Message);
            }
            return false;
        }


        /// <summary>
        /// Suppression d'un livre
        /// </summary>
        /// <param name="Id">Id livre</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool SupprimerLivre(string Id)
        {
            String jsonIdLivre = "{ \"id\" : \"" + Id + "\"}";
            Log.Error("jsonIdLivre" + jsonIdLivre);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Livre> liste = TraitementRecup<Livre>(DELETE, "livre/" + jsonIdLivre);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerLivre catch jsonIdLivre={0} erreur={1} ", jsonIdLivre, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Ecriture d'une revue en base de données
        /// </summary>
        /// <param name="Id">Id de la revue à insérer</param>
        /// <param name="Periodicite">Périodicité de la revue</param>
        /// <param name="DelaiMiseADispo">Délai de mise à disposition de la revue</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerRevue(string Id, string Periodicite, int DelaiMiseADispo)
        {
            String jsonCreerRevue = "{ \"id\" : \"" + Id + "\", \"periodicite\" : \"" + Periodicite + "\", \"delaiMiseADispo\" : \"" + DelaiMiseADispo + "\"}";
            Console.WriteLine("jsonCreerRevue" + jsonCreerRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Revue> liste = TraitementRecup<Revue>(POST, "revue/" + jsonCreerRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerRevue catch jsonCreerRevue={0} erreur={1} ", jsonCreerRevue, ex.Message);
            }
            return false;
        }


        /// <summary>
        /// Ecriture d'un document en base de données
        /// </summary>
        /// <param name="Id">Id du document à insérer</param>
        /// <param name="Titre">Titre du document</param>
        /// <param name="Image">Image du document</param>
        /// <param name="IdGenre">Id du genre du document</param>
        /// <param name="IdPublic">Id du public du document</param>
        /// <param name="IdRayon">Id du rayon du document</param>
        /// <returns>Retourne vraie si la création est effectuée)</returns>
        public bool CreerDocument(string Id, string Titre, string Image, string IdRayon, string IdPublic, string IdGenre)
        {
            String jsonCreerDocument = "{ \"id\" : \"" + Id + "\", \"titre\" : \"" + Titre + "\", \"image\" : \"" + Image + "\", \"idRayon\" : \"" + IdRayon + "\", \"idPublic\" : \"" + IdPublic + "\", \"idGenre\" : \"" + IdGenre + "\"}";
            Console.WriteLine("jsonCreerDocument" + jsonCreerDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Document> liste = TraitementRecup<Document>(POST, "document/" + jsonCreerDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerDocument catch jsonCreerDocument={0} erreur={1} ", jsonCreerDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification d'un document
        /// </summary>
        /// <param name="Id">Id du document à modifier</param>
        /// <param name="Titre">Titre du document</param>
        /// <param name="Image">Image du document</param>
        /// <param name="IdGenre">Id du genre du document</param>
        /// <param name="IdPublic">Id du public du document</param>
        /// <param name="IdRayon">Id du rayon du document</param>
        /// <returns>Retourne vraie si la moficiaion est effectuée</returns>
        public bool ModifierDocument(string Id, string Titre, string Image, string IdGenre, string IdPublic, string IdRayon)
        {
            String jsonModifierDocument = "{ \"id\" : \"" + Id + "\", \"titre\" : \"" + Titre + "\", \"image\" : \"" + Image + "\", \"idGenre\" : \"" + IdGenre + "\", \"idPublic\" : \"" + IdPublic + "\", \"idRayon\" : \"" + IdRayon + "\"}";
            Console.WriteLine("jsonModifierDocument" + jsonModifierDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Document> liste = TraitementRecup<Document>(PUT, "document/" + Id + "/" + jsonModifierDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierDocument catch jsonModifierDocument={0} erreur={1} ", jsonModifierDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'un document
        /// </summary>
        /// <param name="Id">Id document</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerDocument(string Id)
        {
            String jsonIdDocument = "{ \"id\" : \"" + Id + "\"}";
            Console.WriteLine("jsonIdDocument" + jsonIdDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Document> liste = TraitementRecup<Document>(DELETE, "document/" + jsonIdDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerDocument catch jsonIdDocument={0} erreur={1} ", jsonIdDocument, ex.Message);
            }
            return false;
        }


        /// <summary>
        /// Création d'un dvd
        /// </summary>
        /// <param name="Id">Id dvd</param>
        /// <param name="Synopsis">Synopsis dvd</param>
        /// <param name="Realisateur">Réalisateur dvd</param>
        /// <param name="Duree">Durée dvd</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerDvd(string Id, string Synopsis, string Realisateur, int Duree)
        {
            String jsonCreerDvd = "{ \"id\" : \"" + Id + "\", \"synopsis\" : \"" + Synopsis + "\", \"realisateur\" : \"" + Realisateur + "\", \"duree\" : \"" + Duree + "\"}";
            Console.WriteLine("jsonCreerDvd" + jsonCreerDvd);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Dvd> liste = TraitementRecup<Dvd>(POST, "dvd/" + jsonCreerDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerDvd catch jsonCreerDvd={0} erreur={1} ", jsonCreerDvd, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification d'un dvd
        /// </summary>
        /// <param name="Id">Id dvd</param>
        /// <param name="Synopsis">Synopsis dvd</param>
        /// <param name="Realisateur">Réalisateur dvd</param>
        /// <param name="Duree">Durée dvd</param>
        /// <returns>Retourne vraie si la modification est effectuée</returns>
        public bool ModifierDvd(string Id, string Synopsis, string Realisateur, int Duree)
        {
            String jsonModifierDvd = "{ \"id\" : \"" + Id + "\", \"synopsis\" : \"" + Synopsis + "\", \"realisateur\" : \"" + Realisateur + "\", \"duree\" : \"" + Duree + "\"}";
            Console.WriteLine("jsonModifierDvd" + jsonModifierDvd);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Dvd> liste = TraitementRecup<Dvd>(PUT, "dvd/" + Id + "/" + jsonModifierDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierDvd catch jsonModifierDvd={0} erreur={1} ", jsonModifierDvd, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'un dvd
        /// </summary>
        /// <param name="Id">Id dvd</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerDvd(string Id)
        {
            String jsonIdDvd = "{ \"id\" : \"" + Id + "\"}";
            Console.WriteLine("jsonIdDvd" + jsonIdDvd);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Dvd> liste = TraitementRecup<Dvd>(DELETE, "dvd/" + jsonIdDvd);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerDvd catch jsonIdDvd={0} erreur={1} ", jsonIdDvd, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification d'une revue
        /// </summary>
        /// <param name="Id">Id revue</param>
        /// <param name="Periodicite">Périodicité de la revue</param>
        /// <param name="DelaiMiseADispo">Délai de mise à disposition revue</param>
        /// <returns>Retourne vraie si l'insertion est effectuée/returns>
        public bool ModifierRevue(string Id, string Periodicite, int DelaiMiseADispo)
        {
            String jsonModifierRevue = "{ \"id\" : \"" + Id + "\", \"periodicite\" : \"" + Periodicite + "\", \"delaiMiseADispo\" : \"" + DelaiMiseADispo + "\"}";
            Console.WriteLine("jsonModifierRevue" + jsonModifierRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Revue> liste = TraitementRecup<Revue>(PUT, "revue/" + Id + "/" + jsonModifierRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierRevue catch jsonModifierRevue={0} erreur={1} ", jsonModifierRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Suppression d'une revue
        /// </summary>
        /// <param name="Id">Id revue</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerRevue(string Id)
        {
            String jsonIdRevue = "{ \"id\" : \"" + Id + "\"}";
            Console.WriteLine("jsonIdRevue" + jsonIdRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Revue> liste = TraitementRecup<Revue>(DELETE, "revue/" + jsonIdRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerRevue catch jsonIdRevue={0} erreur={1} ", jsonIdRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Création d'une commande
        /// </summary>
        /// <param name="commande">Commande</param>
        /// <returns>Retourne vraie si la création est effectuéee</returns>
        public bool CreerCommande(Commande commande)
        {
            String jsonCreerCommande = JsonConvert.SerializeObject(commande, new CustomDateTimeConverter());
            Console.WriteLine("jsonCreerCommande " + jsonCreerCommande);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Commande> liste = TraitementRecup<Commande>(POST, "commande/" + jsonCreerCommande);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerCommande catch jsonCreerCommande={0} erreur={1} ", jsonCreerCommande, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Création d'une commande de document
        /// </summary>
        /// <param name="id">Id commande de document</param>
        /// <param name="nbExemplaire">Nombre d'exemplaires commande de document</param>
        /// <param name="idLivreDvd">Id livreDvd  commande de document</param>
        /// <param name="idSuivi">Id étape de suivi de la commande de document</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerCommandeDocument(string id, int nbExemplaire, string idLivreDvd, string idSuivi)
        {
            String jsonCreerCommandeDocument = "{ \"id\" : \"" + id + "\", \"nbExemplaire\" : \"" + nbExemplaire + "\", \"idLivreDvd\" : \"" + idLivreDvd + "\", \"idSuivi\" : \"" + idSuivi + "\"}";
            Console.WriteLine("jsonCreerCommandeDocument" + jsonCreerCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(POST, "commandedocument/" + jsonCreerCommandeDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerCommandeDocument catch jsonCreerCommandeDocument={0} erreur={1} ", jsonCreerCommandeDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification de l'étape de suivi d'une commande de document
        /// </summary>
        /// <param name="id">Id commande de document</param>
        /// <param name="idSuivi">Id étape de suivi</param>
        /// <returns>Retourne vraie si la modifiaction est effectuée</returns>
        public bool ModifierSuiviCommandeDocument(string id, string idSuivi)
        {
            String jsonModifierSuiviCommandeDocument = "{ \"id\" : \"" + id + "\", \"idSuivi\" : \"" + idSuivi + "\"}";
            Console.WriteLine("jsonModifierSuiviCommandeDocument" + jsonModifierSuiviCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(PUT, "commandedocument/" + id + "/" + jsonModifierSuiviCommandeDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierSuiviCommandeDocument catch jsonModifierSuiviCommandeDocument={0} erreur={1} ", jsonModifierSuiviCommandeDocument, ex.Message);

            }
            return false;
        }

        /// <summary>
        /// Suppression d'une commande de document
        /// </summary>
        /// <param name="commandesDocument"> CommandeDocument </param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerCommandeDocument(CommandeDocument commandesDocument)
        {
            String jsonSupprimerCommandeDocument = "{\"id\":\"" + commandesDocument.Id + "\"}";
            Console.WriteLine("jsonSupprimerCommandeDocument=" + jsonSupprimerCommandeDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<CommandeDocument> liste = TraitementRecup<CommandeDocument>(DELETE, "commandedocument/" + jsonSupprimerCommandeDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerCommandeDocument catch jsonSupprimerCommandeDocument={0} erreur={1} ", jsonSupprimerCommandeDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Création d'un abonnement à une revue
        /// </summary>
        /// <param name="id">Id abonnement revue</param>
        /// <param name="dateFinAbonnement">Date fin abonnement revue</param>
        /// <param name="idRevue">Id revue abonnement</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerAbonnementRevue(string id, DateTime dateFinAbonnement, string idRevue)
        {
            String jsonDateCommande = JsonConvert.SerializeObject(dateFinAbonnement, new CustomDateTimeConverter());
            String jsonCreerAbonnementRevue = "{\"id\":\"" + id + "\", \"dateFinAbonnement\" : " + jsonDateCommande + ", \"idRevue\" :  \"" + idRevue + "\"}";
            Console.WriteLine("jsonCreerAbonnementRevue" + jsonCreerAbonnementRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(POST, "abonnement/" + jsonCreerAbonnementRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerAbonnementRevue catch jsonCreerAbonnementRevue={0} erreur={1} ", jsonCreerAbonnementRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// modification de l'état d'un exemplaire
        /// </summary>
        /// <param name="exemplaire"> Exemplaire</param>
        /// <returns>Retourne vraie si la modification est effectuée</returns>
        public bool ModifierEtatExemplaireDocument(Exemplaire exemplaire)
        {
            String jsonModifierEtatExemplaireDocument = JsonConvert.SerializeObject(exemplaire, new CustomDateTimeConverter());
            Console.WriteLine("jsonModifierEtatExemplaireDocument" + jsonModifierEtatExemplaireDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(PUT, "exemplairesdocument/" + exemplaire.Numero + "/" + jsonModifierEtatExemplaireDocument); // Modification de la requête
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.ModifierEtatExemplaireDocument catch jsonModifierEtatExemplaireDocument={0} erreur={1} ", jsonModifierEtatExemplaireDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Création d'un exemplaire de revue
        /// </summary>
        /// <param name="id">Id document exemplaire revue</param>
        /// <param name="numero">Numéro exemplaire revue</param>
        /// <param name="dateAchat">Date d'achat dexemplaire revue</param>
        /// <param name="photo">Photo exemplaire revue</param>
        /// <param name="idEtat">Id état exemplaire revue</param>
        /// <returns>Retourne vraie si la création est effectuée</returns>
        public bool CreerExemplaireRevue(string id, int numero, DateTime dateAchat, string photo, string idEtat)
        {
            String jsonDateAchat = JsonConvert.SerializeObject(dateAchat, new CustomDateTimeConverter());
            String jsonCreerExemplaireRevue = "{\"id\":\"" + id + "\", \"numero\":\"" + numero + "\", \"dateAchat\" : " + jsonDateAchat + ", \"photo\" :  \"" + photo + "\" , \"idEtat\" :  \"" + idEtat + "\"}";
            Console.WriteLine("jsonCreerExemplaireRevue" + jsonCreerExemplaireRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(POST, "exemplaire/" + jsonCreerExemplaireRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.CreerExemplaireRevue catch jsonCreerExemplaireRevue={0} erreur={1} ", jsonCreerExemplaireRevue, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Récupèration des infromations utilisateurs
        /// </summary>
        /// <param name="login">Identifiants</param>
        /// <param name="password">Mot de passe</param>
        /// <returns>Retourne vrai si l'utilisateur correspond</returns>
        public Utilisateur VerificationIdentiifants(string login, string password)
        {
            try
            {
                List<Utilisateur> liste = TraitementRecup<Utilisateur>(GET, "utilisateur/" + login);
                if (liste == null || liste.Count == 0)
                {
                    return null;
                }
                Utilisateur utilisateur = liste[0];
                if (utilisateur.Password != password)
                {
                    return null;
                }
                return utilisateur;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.GetUtilisateur catch login={0} erreur={1}", login, ex.Message);
            }
            return null;
        }

        /// <summary>
        /// Traitement de la récupération du retour de l'api, avec conversion du json en liste pour les select (GET)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="methode">verbe HTTP (GET, POST, PUT, DELETE)</param>
        /// <param name="message">information envoyée</param>
        /// <returns>liste d'objets récupérés (ou liste vide)</returns>
        private List<T> TraitementRecup<T>(String methode, String message)
        {
            List<T> liste = new List<T>();
            try
            {
                JObject retour = api.RecupDistant(methode, message);
                // extraction du code retourné
                String code = (String)retour["code"];
                if (code.Equals("200"))
                {
                    // dans le cas du GET (select), récupération de la liste d'objets
                    if (methode.Equals(GET))
                    {
                        String resultString = JsonConvert.SerializeObject(retour["result"]);
                        // construction de la liste d'objets à partir du retour de l'api
                        liste = JsonConvert.DeserializeObject<List<T>>(resultString, new CustomBooleanJsonConverter());
                    }
                }
                else
                {
                    Console.WriteLine("code erreur = " + code + ", message = " + (String)retour["message"]);
                    Log.Error("Access.TraitementRecup catch code={0} erreur={1} ", code);
                }
            }
            catch (Exception e)
            {
                Log.Error("Access.TraitementRecup catch liste={0} erreur={1}", liste, e.Message);
                Environment.Exit(0);
            }
            return liste;
        }

        /// <summary>
        /// Gestionr format date JSON
        /// </summary>
        private sealed class CustomDateTimeConverter : IsoDateTimeConverter
        {
            public CustomDateTimeConverter()
            {
                base.DateTimeFormat = "yyyy-MM-dd";
            }
        }


        /// <summary>
        /// suppression d'un exemplaire 
        /// </summary>
        /// <param name="exemplaire">Exemplaire</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerExemplaireDocument(Exemplaire exemplaire)
        {
            String jsonSupprimerExemplaireDocument = "{\"id\":\"" + exemplaire.Id + "\",\"numero\":\"" + exemplaire.Numero + "\"}";
            Console.WriteLine("jsonSupprimerExemplaireDocument" + jsonSupprimerExemplaireDocument);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Exemplaire> liste = TraitementRecup<Exemplaire>(DELETE, "exemplaire/" + jsonSupprimerExemplaireDocument);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerExemplaireDocument catch jsonSupprimerExemplaireDocument={0} erreur={1} ", jsonSupprimerExemplaireDocument, ex.Message);
            }
            return false;
        }

        /// <summary>
        /// Modification du convertisseur Json pour prendre en compte les booléens
        /// classe trouvée sur le site :
        /// https://www.thecodebuzz.com/newtonsoft-jsonreaderexception-could-not-convert-string-to-boolean/
        /// </summary>
        private sealed class CustomBooleanJsonConverter : JsonConverter<bool>
        {
            public override bool ReadJson(JsonReader reader, Type objectType, bool existingValue, bool hasExistingValue, JsonSerializer serializer)
            {
                return Convert.ToBoolean(reader.ValueType == typeof(string) ? Convert.ToByte(reader.Value) : reader.Value);
            }

            public override void WriteJson(JsonWriter writer, bool value, JsonSerializer serializer)
            {
                serializer.Serialize(writer, value);
            }
        }


        /// <summary>
        /// Suppression d'un abonnement de revues
        /// </summary>
        /// <param name="abonnement"> Abonnement</param>
        /// <returns>Retourne vraie si la suppression est effectuée</returns>
        public bool SupprimerAbonnementRevue(Abonnement abonnement)
        {
            String jsonSupprimerAbonnementRevue = "{\"id\":\"" + abonnement.Id + "\"}";
            Console.WriteLine("jsonSupprimerAbonnementRevue=" + jsonSupprimerAbonnementRevue);
            try
            {
                // récupération soit d'une liste vide (requête ok) soit de null (erreur)
                List<Abonnement> liste = TraitementRecup<Abonnement>(DELETE, "abonnement/" + jsonSupprimerAbonnementRevue);
                return (liste != null);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Log.Error("Access.SupprimerAbonnementRevue catch jsonSupprimerAbonnementRevue={0} erreur={1} ", jsonSupprimerAbonnementRevue, ex.Message);
            }
            return false;
        }
    }

}
