namespace AtelierStock
{
    [TestClass]
    public class ProduitTest
    {
        private static Produit ProduitAvecStock(int stockInitial)
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);
            p.Rentrer(stockInitial);
            return p;
        }

        [TestMethod]
        public void Initialiser_ProduitQuelconque()
        {
            var prixAchat = 100.0m;
            var marge = 0.18m;

            var p = new Produit("REF", "UnNom", prixAchat, marge);

            Assert.AreEqual("REF", p.Reference);
            Assert.AreEqual("UnNom", p.Libelle);
            Assert.AreEqual(100.0m, p.PrixAchat);
            Assert.AreEqual(118.0m, p.PrixVente);
            Assert.AreEqual(0, p.Stocks);
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Initialiser_ProduitMarge0_PrixVenteEgalPrixAchat()
        {
            var p = new Produit("REF", "UnNom", 100m, 0m);

            Assert.AreEqual(100.0m, p.PrixAchat);
            Assert.AreEqual(100.0m, p.PrixVente);
        }

        [TestMethod]
        [DataRow(100, 0.0, 100.0)]
        [DataRow(100, 0.18, 118.0)]
        [DataRow(200, 0.5, 300.0)]
        [DataRow(50, 1.0, 100.0)]
        public void PrixVente_AppliqueLaMargeAuPrixDAchat(double prixAchat, double marge, double prixVenteAttendu)
        {
            var p = new Produit("REF", "UnNom", (decimal)prixAchat, (decimal)marge);

            Assert.AreEqual((decimal)prixVenteAttendu, p.PrixVente);
        }

        [TestMethod]
        public void Rentrer_AjouteLaQuantiteAuStock()
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);

            p.Rentrer(25);

            Assert.AreEqual(25, p.Stocks);
        }

        [TestMethod]
        public void Rentrer_PlusieursFois_CumuleLesQuantites()
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);

            p.Rentrer(25);
            p.Rentrer(15);

            Assert.AreEqual(40, p.Stocks);
        }

        [TestMethod]
        public void Sortir_QuantiteInferieureAuStock_RetireEtRenvoieLaQuantiteDemandee()
        {
            var p = ProduitAvecStock(30);

            int retire = p.Sortir(10);

            Assert.AreEqual(10, retire);
            Assert.AreEqual(20, p.Stocks);
        }

        [TestMethod]
        public void Sortir_ExactementToutLeStock_RameneLeStockAZero()
        {
            var p = ProduitAvecStock(12);

            int retire = p.Sortir(12);

            Assert.AreEqual(12, retire);
            Assert.AreEqual(0, p.Stocks);
        }

        [TestMethod]
        public void EstEnRupture_ProduitNeuf_EstVrai()
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);

            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void EstEnRupture_ApresReapprovisionnement_EstFaux()
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);

            p.Rentrer(5);

            Assert.IsFalse(p.EstEnRupture);
        }

        [TestMethod]
        public void EstEnRupture_ApresAvoirToutVendu_EstVrai()
        {
            var p = ProduitAvecStock(8);

            p.Sortir(8);

            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_PlusQueLeStockDisponible_PlafonneAuStockEtNeDescendPasSousZero()
        {
            var p = ProduitAvecStock(10);

            int retire = p.Sortir(15);

            Assert.AreEqual(10, retire, "la valeur retirée doit être plafonnée au stock réellement disponible");
            Assert.AreEqual(0, p.Stocks, "le stock ne doit jamais devenir négatif");
            Assert.IsTrue(p.EstEnRupture);
        }

        [TestMethod]
        public void Sortir_SurUnStockVide_NeRetireRien()
        {
            var p = new Produit("REF", "UnNom", 100m, 0.20m);

            int retire = p.Sortir(5);

            Assert.AreEqual(0, retire);
            Assert.AreEqual(0, p.Stocks);
        }

    }
}
