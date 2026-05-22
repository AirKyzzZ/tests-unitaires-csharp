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
}
