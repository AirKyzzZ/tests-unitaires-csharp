namespace HorlogeParlante;

public static class Horloge
{
    private static readonly string[] NomsHeures =
        { "", "une", "deux", "trois", "quatre", "cinq", "six",
          "sept", "huit", "neuf", "dix", "onze" };

    public static string EnTexte(DateTime heure)
    {
        int h = heure.Hour;
        int h12 = h % 12;
        string motHeure = h12 == 1 ? "une heure" : $"{NomsHeures[h12]} heures";
        string periode = h < 12 ? "du matin" : "de l'après-midi";
        return $"{motHeure} {periode}";
    }
}
