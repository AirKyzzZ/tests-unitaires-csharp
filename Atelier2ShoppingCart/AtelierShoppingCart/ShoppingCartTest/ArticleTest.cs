using ShoppingCart;

namespace ShoppingCartTest;

[TestClass]
public class ArticleTest
{

    [TestMethod]
    public void Constructeur_ValeursValides_InitialiseLesProprietes()
    {
        var article = new Article("Pomme", 3, 1.50m);

        Assert.AreEqual("Pomme", article.ProductName);
        Assert.AreEqual(3, article.Quantity);
        Assert.AreEqual(1.50m, article.Price);
    }

    [TestMethod]
    public void TotalPrice_EstLeProduitDeLaQuantiteParLePrix()
    {
        var article = new Article("Pomme", 4, 2.50m);

        Assert.AreEqual(10.00m, article.TotalPrice);
    }

    [TestMethod]
    public void Quantity_NouvelleValeurValide_MetAJourLaQuantite()
    {
        var article = new Article("Pomme", 3, 1.50m);

        article.Quantity = 7;

        Assert.AreEqual(7, article.Quantity);
    }

    [TestMethod]
    public void Equals_ArticlesAuContenuIdentique_SontEgaux()
    {
        var a = new Article("Pomme", 3, 1.50m);
        var b = new Article("Pomme", 3, 1.50m);

        Assert.AreEqual(a, b);
        Assert.AreEqual(a.GetHashCode(), b.GetHashCode());
    }

    [TestMethod]
    public void Equals_ArticlesAuContenuDifferent_SontDifferents()
    {
        var reference = new Article("Pomme", 3, 1.50m);

        Assert.AreNotEqual(reference, new Article("Poire", 3, 1.50m));
        Assert.AreNotEqual(reference, new Article("Pomme", 4, 1.50m));
        Assert.AreNotEqual(reference, new Article("Pomme", 3, 2.00m));
    }

    [TestMethod]
    [DataRow(0.0)]
    [DataRow(-1.0)]
    public void Constructeur_PrixNegatifOuNul_LeveArgumentOutOfRange(double prixInvalide)
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => new Article("Pomme", 3, (decimal)prixInvalide));
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-2)]
    public void Constructeur_QuantiteNegativeOuNulle_LeveArgumentOutOfRange(int quantiteInvalide)
    {
        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => new Article("Pomme", quantiteInvalide, 1.50m));
    }

    [TestMethod]
    [DataRow(0)]
    [DataRow(-2)]
    public void Quantity_AffectationNegativeOuNulle_LeveArgumentOutOfRange(int quantiteInvalide)
    {
        var article = new Article("Pomme", 3, 1.50m);

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => article.Quantity = quantiteInvalide);
    }

}
