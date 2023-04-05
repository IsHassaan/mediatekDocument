<?php
include_once("ConnexionPDO.php");

/**
 * Classe de construction des requêtes SQL à envoyer à la BDD
 */
class AccessBDD {
	
    public $login="root";
    public $mdp="";
    public $bd="mediatek86";
    public $serveur="localhost";
    public $port="3306";	
    public $conn = null;

    /**
     * constructeur : demande de connexion à la BDD
     */
    public function __construct(){
        try{
            $this->conn = new ConnexionPDO($this->login, $this->mdp, $this->bd, $this->serveur, $this->port);
        }catch(Exception $e){
            throw $e;
        }
    }

    /**
     * récupération de toutes les lignes d'une table
     * @param string $table nom de la table
     * @return lignes de la requete
     */
    public function selectAll($table){
        if($this->conn != null){
            switch ($table) {
                case "livre" :
                    return $this->selectAllLivres();
                case "dvd" :
                    return $this->selectAllDvd();
                case "revue" :
                    return $this->selectAllRevues();
                case "exemplaire" :
                    return $this->selectExemplairesRevue();
                case "commandedocument" :
                    return $this->selectCommandesDocument();
                case "abonnementsecheance" :
                    return $this->selectAllAbonnementsAlerte();
                default:
                    // cas d'un select portant sur une table simple, avec tri sur le libellé
                    return $this->selectAllTableSimple($table);
            }			
        }else{
            return null;
        }
    }

    /**
     * récupération d'une ligne d'une table
     * @param string $table nom de la table
     * @param string $id id de la ligne à récupérer
     * @return ligne de la requete correspondant à l'id
     */	
    public function selectOne($table, $id){
        if($this->conn != null){
            switch($table){
                case "exemplaire" :
                    return $this->selectExemplairesRevue($id);
                case "dvd" :
                    return $this->selectAllDvd($id);
                case "revue" :
                    return $this->selectAllRevues($id);
                case "commandedocument" :
                    return $this->selectCommandesDocument($id);
                case "abonnement" :
                    return $this->selectAllAbonnementsRevues($id);
                case "exemplairesdocument":
                    return $this->selectAllExemplairesDocument($id);
                case "utilisateur":
                    return $this->selectUtilisateur($id);
                default:
                    // cas d'un select portant sur une table simple			
                    $param = array(
                        "id" => $id
                    );
                    return $this->conn->query("select * from $table where id=:id;", $param);					
            }				
        }else{
                return null;
        }
    }
   
    /**
     * Selection d'une table sans formalités
     * @param type $table
     * @return lignes de la requete
     */
    public function selectAllTableSimple($table){
        $req = "select * from $table order by libelle;";		
        return $this->conn->queryAll($req);		
    }
	

    /**
     * Selection de l'ensemble des éléments des DVD
     * @return lignes de la requete
     */
    public function selectAllDvd(){
        $req = "select l.id, l.duree, l.realisateur, d.titre, d.image, l.synopsis, ";
        $req .= "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as lePublic, r.libelle as rayon ";
        $req .= "from dvd l join document d on l.id=d.id ";
        $req .= "join genre g on g.id=d.idGenre ";
        $req .= "join public p on p.id=d.idPublic ";
        $req .= "join rayon r on r.id=d.idRayon ";
        $req .= "order by titre ";	
        return $this->conn->queryAll($req);
    }	



        /**
     * Selections de l'eneemble des livres
     * @return lignes de la requete
     */
    public function selectAllLivres(){
        $req = "select l.id, l.ISBN, l.auteur, d.titre, d.image, l.collection, ";
        $req .= "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as lePublic, r.libelle as rayon ";
        $req .= "from livre l join document d on l.id=d.id ";
        $req .= "join genre g on g.id=d.idGenre ";
        $req .= "join public p on p.id=d.idPublic ";
        $req .= "join rayon r on r.id=d.idRayon ";
        $req .= "order by titre ";		
        return $this->conn->queryAll($req);
    }

    /**
     * Selection de l'enemble des revues
     * @return lignes de la requete
     */
    public function selectAllRevues(){
        $req = "select l.id, l.periodicite, d.titre, d.image, l.delaiMiseADispo, ";
        $req .= "d.idrayon, d.idpublic, d.idgenre, g.libelle as genre, p.libelle as lePublic, r.libelle as rayon ";
        $req .= "from revue l join document d on l.id=d.id ";
        $req .= "join genre g on g.id=d.idGenre ";
        $req .= "join public p on p.id=d.idPublic ";
        $req .= "join rayon r on r.id=d.idRayon ";
        $req .= "order by titre ";
        return $this->conn->queryAll($req);
    }	

    
    /**
     * Select des commandes de documents
     * @param string $id id du document
     * @return lignes de la requete
     */
    public function selectCommandesDocument($id) {
        $param = array (
        "id" => $id
                );
        $req = "select c.nbExemplaire, c.idLivreDvd, c.idSuivi, s.libelle, c.id, max(cd.dateCommande)
        as dateCommande, sum(cd.montant) as montant from commandedocument c join suivi s on s.id=c.idSuivi
        left join commande cd on c.id=c.id where c.idLivreDvd =:id group by c.id order by dateCommande DESC;";
        return $this->conn->query($req, $param);
    }
    
     /**
     * Select des abonnements d'une revue
     * @param string $id id de l'abonnement à la revue
     * @return lignes de la requete
     */
    public function selectAllAbonnementsRevues($id){
        $param = array(
                "id" => $id
        );
        $req = "SELECT commande.id, commande.dateCommande, commande.montant, abonnement.dateFinAbonnement,
        abonnement.idRevue FROM commande INNER JOIN abonnement WHERE commande.id=abonnement.id AND
        abonnement.idRevue=10001 ORDER BY commande.dateCommande DESC;";
        return $this->conn->queryAll($req, $param);
    }

    /**
     * Selection des exemplaires d'une revue
     * @param string $id id de la revue
     * @return lignes de la requete
     */
    public function selectExemplairesRevue($id){
        $param = array(
                "id" => $id
        );
        $req = "SELECT exemplaire.id, exemplaire.numero, exemplaire.dateAchat,
        exemplaire.photo,exemplaire.idEtat FROM exemplaire INNER JOIN document
        WHERE exemplaire.id=document.id AND exemplaire.id=:id ORDER BY exemplaire.dateAchat DESC;";		
        return $this->conn->queryAll($req, $param);
    }

    /**
     * Selection des abonnements dont la fin est inférieur à 30 jours
     * @return lignes de la requête
     */
    public function selectAllAbonnementsAlerte(){
        $req ="SELECT abonnement.dateFinAbonnement, abonnement.idRevue, document.titre
        FROM abonnement
        INNER JOIN revue ON abonnement.idRevue = revue.id
        INNER JOIN document ON revue.id = document.id
        WHERE DATEDIFF(CURRENT_DATE(), abonnement.dateFinAbonnement) < 30
        ORDER BY abonnement.dateFinAbonnement ASC;";
        return $this->conn->queryAll($req);
    }   
    
    /**
     * Récupération des données utilisateur
     * @param string $id utilisateur
     * @return lignes de la requete
     */
    public function selectUtilisateur($id)
    {
        $param = array(
                "id" => $id
                
        );
        $req = "SELECT utilisateur.login, utilisateur.password,utilisateur.idService,service.libelle FROM
         utilisateur INNER JOIN service WHERE utilisateur.idService = service.id AND utilisateur.login=:id";     
        return $this->conn->queryAll($req, $param);
    }   
    
    /**
     * Ajout d'une ligne
     * @param string $table nom de la table
     * @param array $champs nom et valeur de chaque champs de la ligne
     * @return true si l'ajout a fonctionné
     */	
    public function insertOne($table, $champs){
        if($this->conn != null && $champs != null){
            $requete = "insert into $table (";
            foreach ($champs as $key => $value){
                $requete .= "$key,";
            }
            $requete = substr($requete, 0, strlen($requete)-1);
            $requete .= ") values (";
            foreach ($champs as $key => $value){
                $requete .= ":$key,";
            }
            $requete = substr($requete, 0, strlen($requete)-1);
            $requete .= ");";	
            return $this->conn->execute($requete, $champs);		
        }else{
            return null;
        }
    }


    /**
    * Affichage
    * @param string $id id du document concerné
    * @return lignes de la requête
    */
    public function selectAllExemplairesDocument($id){
        $param = array(
            "id" => $id
            );
            $req = "SELECT exemplaire.id, exemplaire.numero, exemplaire.dateAchat,
            exemplaire.photo, exemplaire.idEtat, etat.libelle FROM exemplaire
            INNER JOIN etat WHERE exemplaire.idEtat=etat.id AND exemplaire.id=:id
            ORDER BY exemplaire.dateAchat DESC;";      
            return $this->conn->query($req, $param);
        }

    /**
    * Modification
    * prise en compte du numéro d'exemplaire spécifique
    * @param string $table nom de la table
    * @param string $id id de la ligne à modifier
    * @param array $champs nom et valeur de chaque champ de la ligne
    * @return true si la modification a fonctionné
    */ 
    public function updateOne($table, $id, $champs){
        if($this->conn != null && $champs != null){
            switch($table){
                case "exemplairesdocument":
                    $champsExemplaire = [
                        'id' => $champs['Id'],
                        'numero' => $champs['Numero'],
                        'dateAchat' => $champs['DateAchat'],
                        'photo' => $champs['Photo'],
                        'idEtat' => $champs['IdEtat']
                    ];
                    $requete = "UPDATE exemplaire SET ";
                    foreach ($champsExemplaire as $key => $value) {
                        $requete .= "$key=:$key,";
                    }
                    $requete = substr($requete, 0, strlen($requete)-1);
                    $requete .= " WHERE id=:id AND numero=:numero;";
                    $champsExemplaire['numero'] = $id;
                    $updateExemplaire = $this->conn->execute($requete, $champsExemplaire);   
                    if(!$updateExemplaire){
                        return null;
                    }
                default:
                    $champs['id'] = $id;
                    $requete = "UPDATE $table SET ";
                    foreach ($champs as $key => $value) {
                        $requete .= "$key=:$key,";
                    }
                    $requete = substr($requete, 0, strlen($requete)-1);
                    $requete .= " WHERE id=:id;";
                    return $this->conn->execute($requete, $champs);                 
            }
        }
        else
        {
            return null;
        }
    }

    
    /**
     * suppresion
     * @param string $table nom de la table
     * @param array $champs nom et valeur de chaque champs
     * @return true si la suppression a fonctionné
     */	
    public function delete($table, $champs){
        if($this->conn != null){
            $requete = "delete from $table where ";
            foreach ($champs as $key => $value){
                $requete .= "$key=:$key and ";
            }
            $requete = substr($requete, 0, strlen($requete)-5);   
            return $this->conn->execute($requete, $champs);		
        }else{
            return null;
        }
    }

}