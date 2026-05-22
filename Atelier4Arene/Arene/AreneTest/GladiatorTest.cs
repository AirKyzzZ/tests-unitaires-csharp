using Arene;

namespace AreneTest;

[TestClass]
public class GladiatorTest
{
    private static Gladiator UnGladiateur(int health = 30, int strength = 5, int armor = 2)
        => new("Gladiateur", health, strength, armor);

    [TestMethod]
    [DataRow(0)]
    [DataRow(7)]
    public void Attaque_AvecUnDeTruqueHorsDe1A6_LeveArgumentOutOfRange(int valeurTruquee)
    {
        var attaquant = UnGladiateur();
        var adversaire = UnGladiateur();

        Assert.ThrowsExactly<ArgumentOutOfRangeException>(
            () => attaquant.Attack(adversaire, new DeFixe(valeurTruquee)));
    }

    [TestMethod]
    public void Attaque_ContreSoiMeme_LeveArgumentException()
    {
        var gladiateur = UnGladiateur();

        Assert.ThrowsExactly<ArgumentException>(
            () => gladiateur.Attack(gladiateur, new DeFixe(3)));
    }

    [TestMethod]
    public void Attaque_Standard_LAdversairePerdLeDePlusLaForceMoinsSonArmure()
    {
        var attaquant = UnGladiateur(strength: 5);
        var adversaire = UnGladiateur(health: 30, armor: 2);

        attaquant.Attack(adversaire, new DeFixe(3));

        Assert.AreEqual(24, adversaire.Health);
    }

    [TestMethod]
    public void Attaque_DeuxAttaquesStandardConsecutives_LesDegatsSeCumulent()
    {
        var attaquant = UnGladiateur(strength: 5);
        var adversaire = UnGladiateur(health: 30, armor: 2);

        attaquant.Attack(adversaire, new DeFixe(3));
        attaquant.Attack(adversaire, new DeFixe(4));

        Assert.AreEqual(17, adversaire.Health);
    }

    [TestMethod]
    public void Attaque_ContreUneArmureBienPlusForte_NInfligeAucunDegat()
    {
        var attaquant = UnGladiateur(strength: 3);
        var adversaire = UnGladiateur(health: 30, armor: 50);

        attaquant.Attack(adversaire, new DeFixe(2));

        Assert.AreEqual(30, adversaire.Health);
    }

    [TestMethod]
    public void Attaque_CoupCritique_UnSixDoubleLeDePlusLaForce()
    {
        var attaquant = UnGladiateur(strength: 5);
        var adversaire = UnGladiateur(health: 40, armor: 2);

        attaquant.Attack(adversaire, new DeFixe(6));

        Assert.AreEqual(20, adversaire.Health);
    }

    [TestMethod]
    public void Attaque_DegatsSuperieursAuxPointsDeVie_LAdversaireTombeAZeroSansPVNegatifs()
    {
        var attaquant = UnGladiateur(strength: 10);
        var adversaire = UnGladiateur(health: 5, armor: 0);

        attaquant.Attack(adversaire, new DeFixe(6));

        Assert.AreEqual(0, adversaire.Health);
    }
}
