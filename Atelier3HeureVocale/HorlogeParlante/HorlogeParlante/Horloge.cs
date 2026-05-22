namespace HorlogeParlante;

public static class Horloge
{
    public static string EnTexte(DateTime heure)
    {
        string[] noms = { "", "une", "deux", "trois", "quatre", "cinq", "six",
                           "sept", "huit", "neuf", "dix", "onze" };

        int h = heure.Hour;
        string motHeure = h == 1 ? "une heure" : $"{noms[h]} heures";
        return $"{motHeure} du matin";
    }
}
