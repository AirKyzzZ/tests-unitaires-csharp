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

    [TestMethod]
    [DataRow(13, "une heure de l'après-midi")]
    [DataRow(14, "deux heures de l'après-midi")]
    [DataRow(18, "six heures de l'après-midi")]
    public void HeurePile_DeLApresMidi(int h, string attendu)
        => Assert.AreEqual(attendu, Heure(h));

    [TestMethod]
    [DataRow(0, "minuit")]
    [DataRow(12, "midi")]
    public void HeurePile_MidiEtMinuit(int h, string attendu)
        => Assert.AreEqual(attendu, Heure(h));

    [TestMethod]
    [DataRow(9, 5, "neuf heures cinq du matin")]
    [DataRow(12, 10, "midi dix")]
    [DataRow(0, 15, "minuit et quart")]
    [DataRow(15, 25, "trois heures vingt-cinq de l'après-midi")]
    [DataRow(8, 30, "huit heures et demie du matin")]
    public void Tranches5Minutes_PremiereDemiHeure(int h, int m, string attendu)
        => Assert.AreEqual(attendu, Heure(h, m));
}
