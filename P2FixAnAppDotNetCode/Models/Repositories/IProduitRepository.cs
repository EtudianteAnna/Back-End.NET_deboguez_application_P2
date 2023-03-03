namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProduitRepository
    {

        Produit[] GetTousLesProduits();

        void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer);
        
    }
}
