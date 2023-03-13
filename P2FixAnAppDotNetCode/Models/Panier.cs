

namespace P2FixAnAppDotNetCode.Models
{
    /// La classe Panier
    /// </summary>
    public class Panier : IPanier
    {
        /// <summary>
        /// Propriété en lecture seule pour affichage seulement
        /// </summary>
        private List<LignePanier> lignesPanier = new List<LignePanier>();
      
       public IEnumerable<LignePanier> Lignes => lignesPanier;
              
        /// <summary>
        /// Retour la liste des lignes du panier	       
        /// </summary>	        
        /// <returns></returns>

        private List<LignePanier> GetListeDesLignesDuPanier()

        {
            return lignesPanier;
        }

        /// <summary>
        /// Ajoute un produit dans le panier ou incrémente sa quantité dans le panier si déjà présent
        /// </summary>//
        public void AjouterElement(Produit produit, int quantite)
        {

            if (lignesPanier.Exists(p => p.Produit.Id == produit.Id))
            {

                foreach (LignePanier ligne in lignesPanier)
                {
                    if (ligne.Produit.Id == produit.Id)
                    {
                        ligne.Quantite += quantite;
                    }
                }

            }
            else
            {
                lignesPanier.Add(new LignePanier

                {
                    Produit = produit,

                    Quantite = quantite
                });
            
            }
        }
             /// <summary>
        /// Supprimer un produit du panier
        /// </summary>
        public void SupprimerLigne(Produit produit) =>
               GetListeDesLignesDuPanier().RemoveAll(l => l.Produit.Id == produit.Id);

          public double GetValeurTotale()
        {

            double valeurTotale = 0.0;

            foreach (LignePanier ligne in lignesPanier)
            {

                valeurTotale += ligne.Quantite * ligne.Produit.Prix;

            }

            return valeurTotale;
        }

        /// <summary>
        /// Récupère la valeur moyenne du panier
        /// </summary>
        public double GetValeurMoyenne()

        {
            double valeurMoyenne = 0.0;
            double quantiteTotale = 0.0;

            if (lignesPanier.Count==0)
                {
                return 0.0;
                }
            foreach (var lignes in lignesPanier)
            {
                valeurMoyenne += lignes.Quantite * lignes.Produit.Prix;
                quantiteTotale += lignes.Quantite;
            }
              return valeurMoyenne/quantiteTotale;
        }

        /// <summary>
        /// Cherche un produit donné dans le panier et le retourne si trouvé
        /// </summary>
        public Produit TrouveProduitDansLesLignesDuPanier(int idProduit)

        {
            Produit trouveProduit = null;
            foreach (var ligne in lignesPanier)
            {
                if (ligne.Produit.Id == idProduit)
                    trouveProduit = ligne.Produit;
            }
               return trouveProduit;
       }

        /// <summary>
        /// Retourne une ligne de panier à partir de son indice
        /// </summary>
        public LignePanier GetLignePanierParIndice(int indice)
        {
            return Lignes.ToArray()[indice];
        }
        /// <summary>
        /// Vide un panier de tous ses produits
        /// </summary>
        public void Vider()
        {
            List<LignePanier> lignePaniers = GetListeDesLignesDuPanier();
            lignePaniers.Clear();
        }
    }

        public class LignePanier
        {
            public int CommandeLigneId { get; set; }
            public Produit Produit { get; set; }
            public int Quantite { get; set; }




        }
}




