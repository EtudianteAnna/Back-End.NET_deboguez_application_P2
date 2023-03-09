namespace P2FixAnAppDotNetCode.Models.Repositories
{
    public interface IProduitRepository
    {

       List< Produit> GetTousLesProduits();

        void MetAJourLaQuantiteDunProduit(int idProduit, int quantiteASupprimer);
        
    }
}
