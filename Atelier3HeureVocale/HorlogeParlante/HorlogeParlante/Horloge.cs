namespace HorlogeParlante;

public static class Horloge
{
    private static readonly string[] NomsHeures =
        { "", "une", "deux", "trois", "quatre", "cinq", "six",
          "sept", "huit", "neuf", "dix", "onze" };

    public static string EnTexte(DateTime heure)
    {
        int h = heure.Hour;
        string motHeure = h == 1 ? "une heure" : $"{NomsHeures[h]} heures";
        return $"{motHeure} du matin";
    }
}
