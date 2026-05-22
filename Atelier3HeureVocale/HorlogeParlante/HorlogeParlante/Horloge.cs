namespace HorlogeParlante;

public static class Horloge
{
    private static readonly string[] NomsHeures =
        { "", "une", "deux", "trois", "quatre", "cinq", "six",
          "sept", "huit", "neuf", "dix", "onze" };

    public static string EnTexte(DateTime heure)
        => Composer(heure.Hour);

    private static string Composer(int heure24)
    {
        if (heure24 == 0) return "minuit";
        if (heure24 == 12) return "midi";

        int h12 = heure24 % 12;
        string motHeure = h12 == 1 ? "une heure" : $"{NomsHeures[h12]} heures";
        string periode = heure24 < 12 ? "du matin" : "de l'après-midi";
        return $"{motHeure} {periode}";
    }
}
