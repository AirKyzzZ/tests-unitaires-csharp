using ShoppingCart;

namespace ShoppingCartTest;

[TestClass]
public class CartTest
{
    private Cart panier = null!;

    [TestInitialize]
    public void Init() => panier = new Cart();

    private static Article UnArticle(string nom, int qte, decimal prix) => new(nom, qte, prix);

    private Cart PanierAvec(params (string nom, int qte, decimal prix)[] lignes)
    {
        foreach (var (nom, qte, prix) in lignes)
        {
            panier.Add(nom, qte, prix);
        }
        return panier;
    }

    [TestMethod]
    public void Add_NouveauProduit_CreeUnArticleDansLePanier()
    {
        var article = panier.Add("Pomme", 3, 1.50m);

        Assert.AreEqual("Pomme", article.ProductName);
        Assert.AreEqual(3, article.Quantity);
        Assert.AreEqual(1.50m, article.Price);
        CollectionAssert.AreEquivalent(
            new[] { UnArticle("Pomme", 3, 1.50m) },
            panier.Articles.ToList());
    }

    [TestMethod]
    public void Add_MemeProduitDeuxFois_CumuleLesQuantitesEnUneSeuleEntree()
    {
        panier.Add("Pomme", 3, 1.50m);

        panier.Add("Pomme", 2, 9.99m);

        CollectionAssert.AreEquivalent(
            new[] { UnArticle("Pomme", 5, 1.50m) },
            panier.Articles.ToList());
    }

    [TestMethod]
    public void Add_DeuxProduitsDifferents_ProduitDeuxEntreesDistinctes()
    {
        PanierAvec(("Pomme", 3, 1.50m), ("Poire", 1, 2.00m));

        CollectionAssert.AreEquivalent(
            new[] { UnArticle("Pomme", 3, 1.50m), UnArticle("Poire", 1, 2.00m) },
            panier.Articles.ToList());
    }

    [TestMethod]
    public void Add_RetourneLArticleEffectivementStockeDansLePanier()
    {
        var retourne = panier.Add("Pomme", 3, 1.50m);

        Assert.AreSame(retourne, panier.Articles.Single());
    }

    [TestMethod]
    public void DecreaseArticleQuantity_QuantiteSuperieureA1_DecrementeDeUn()
    {
        PanierAvec(("Pomme", 3, 1.50m));

        panier.DecreaseArticleQuantity("Pomme");

        Assert.AreEqual(2, panier.Articles.Single().Quantity);
    }

    [TestMethod]
    public void DecreaseArticleQuantity_QuantiteEgaleA1_RetireLArticleDuPanier()
    {
        PanierAvec(("Pomme", 1, 1.50m), ("Poire", 2, 2.00m));

        panier.DecreaseArticleQuantity("Pomme");

        CollectionAssert.AreEquivalent(
            new[] { UnArticle("Poire", 2, 2.00m) },
            panier.Articles.ToList());
    }

    [TestMethod]
    public void TotalPrice_PlusieursArticles_SommeLesSousTotaux()
    {
        PanierAvec(("Pomme", 2, 1.50m), ("Poire", 3, 2.00m));

        Assert.AreEqual(9.00m, panier.TotalPrice);
    }

    [TestMethod]
    public void IsEmpty_PanierNeuf_EstVrai()
    {
        Assert.IsTrue(panier.IsEmpty);
    }

    [TestMethod]
    public void IsEmpty_ApresUnAjout_EstFaux()
    {
        panier.Add("Pomme", 1, 1.50m);

        Assert.IsFalse(panier.IsEmpty);
    }

    [TestMethod]
    public void TotalPrice_PanierVide_EstZero()
    {
        Assert.AreEqual(0m, panier.TotalPrice);
    }

    [TestMethod]
    public void DecreaseArticleQuantity_DernierExemplaireDuDernierArticle_PanierRedevientVide()
    {
        PanierAvec(("Pomme", 1, 1.50m));

        panier.DecreaseArticleQuantity("Pomme");

        Assert.IsTrue(panier.IsEmpty);
        Assert.AreEqual(0m, panier.TotalPrice);
    }

    [TestMethod]
    public void Add_QuantiteMinimaleDeUn_EstAcceptee()
    {
        var article = panier.Add("Pomme", 1, 1.50m);

        Assert.AreEqual(1, article.Quantity);
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-3)]
    public void Add_QuantiteNegativeOuNulle_LeveArgumentOutOfRange(int quantiteInvalide)
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => panier.Add("Pomme", quantiteInvalide, 1.50m));
    }

    [TestMethod]
    [DataRow(0.0)]
    [DataRow(-1.0)]
    public void Add_PrixNegatifOuNul_LeveArgumentOutOfRange(double prixInvalide)
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => panier.Add("Pomme", 3, (decimal)prixInvalide));
    }

    [TestMethod]
    public void Add_QuantiteInvalideSurUnArticleExistant_LeveArgumentOutOfRangeSansModifierLePanier()
    {
        panier.Add("Pomme", 3, 1.50m);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => panier.Add("Pomme", -1, 1.50m));
        Assert.AreEqual(3, panier.Articles.Single().Quantity);
    }

    [TestMethod]
    public void DecreaseArticleQuantity_ArticleInexistant_LeveArgumentException()
    {
        PanierAvec(("Pomme", 3, 1.50m));

        Assert.ThrowsExactly<ArgumentException>(
            () => panier.DecreaseArticleQuantity("Banane"));
    }

    [TestMethod]
    public void DecreaseArticleQuantity_SurUnPanierVide_LeveArgumentException()
    {
        Assert.ThrowsExactly<ArgumentException>(
            () => panier.DecreaseArticleQuantity("Pomme"));
    }

}
