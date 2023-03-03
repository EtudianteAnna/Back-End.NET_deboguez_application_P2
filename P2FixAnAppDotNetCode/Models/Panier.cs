using P2FixAnAppDotNetCode.Models;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

namespace P2FixAnAppDotNetCode.Models
{




    /// <summary>
    /// La classe Panier
    /// </summary>
    public class Panier : IPanier


    /// <summary>
    /// Propriété en lecture seule pour affichage seulement
    /// </summary>
    {

        /// <summary>
        /// Retour la liste des lignes du panier	        /// Retour la liste des lignes du panier
        /// </summary>	        /// </summary>
        /// <returns></returns>	        /// <returns></returns>

        private List<LignePanier> GetListeDesLignesDuPanier()

        {
            return _panier;
        }

        private List<LignePanier> _panier = new();



        public IEnumerable<LignePanier> Lignes => GetListeDesLignesDuPanier();

        public IEnumerable<object> Items { get; internal set; }

        public void AjouterElement(Produit produit, int quantite)

        {

            var panier = GetListeDesLignesDuPanier();
            var ligne = panier.FirstOrDefault(p => p.Produit.Id == produit.Id);

            if (ligne != null)

            {

                ligne.Quantite += quantite;

            }

            else

            {

                panier.Add(new LignePanier { Quantite = quantite, Produit = produit });
            }
        }

        public void SupprimerLigne(Produit produit) =>
        GetListeDesLignesDuPanier().RemoveAll(l => l.Produit.Id == produit.Id);




        public double GetValeurTotale()
        {
            var lignePaniers = GetListeDesLignesDuPanier();
            double valeurTotale = 0;

            foreach (LignePanier lignePanier in lignePaniers)
            {

                valeurTotale += lignePanier.Produit.Prix * lignePanier.Quantite;

            }

            return valeurTotale;
        }

        public double GetValeurMoyenne()

        {
            double valeurMoyenne = 0;

            foreach (LignePanier ligne in GetListeDesLignesDuPanier())
            {
                valeurMoyenne += ligne.Quantite / ligne.Produit.Prix;
            }

            return valeurMoyenne;

        }

        /// <summary>
        /// Cherche un produit donné dans le panier et le retourne si trouvé
        /// </summary>
        public Produit TrouveProduitDansLesLignesDuPanier(int idProduit)

        {
            foreach (LignePanier ligne in GetListeDesLignesDuPanier())
            {
                if (ligne.Produit.Id == idProduit)
                {
                    return ligne.Produit;
                }
            }
            return null;
        }


      
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



