using HorlogeParlante;

namespace HorlogeParlanteTest;

[TestClass]
public class HorlogeTest
{
    private static string Heure(int h, int m = 0)
        => Horloge.EnTexte(new DateTime(2026, 1, 1, h, m, 0));

    [TestMethod]
    [DataRow(1, "une heure du matin")]
    [DataRow(7, "sept heures du matin")]
    [DataRow(11, "onze heures du matin")]
    public void HeurePile_DuMatin(int h, string attendu)
        => Assert.AreEqual(attendu, Heure(h));
}
