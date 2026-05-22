namespace HorlogeParlante;

public static class Horloge
{
    private static readonly string[] NomsHeures =
        { "", "une", "deux", "trois", "quatre", "cinq", "six",
          "sept", "huit", "neuf", "dix", "onze" };

    public static string EnTexte(DateTime heure)
        => Composer(heure.Hour, MinutesAvant(heure.Minute));

    private static string Composer(int heure24, string minutes)
    {
        if (heure24 == 0) return $"minuit{minutes}";
        if (heure24 == 12) return $"midi{minutes}";

        int h12 = heure24 % 12;
        string motHeure = h12 == 1 ? "une heure" : $"{NomsHeures[h12]} heures";
        string periode = heure24 < 12 ? " du matin" : " de l'après-midi";
        return $"{motHeure}{minutes}{periode}";
    }

    private static string MinutesAvant(int minute) => minute switch
    {
        0  => "",
        5  => " cinq",
        10 => " dix",
        15 => " et quart",
        20 => " vingt",
        25 => " vingt-cinq",
        30 => " et demie",
        _  => throw new NotImplementedException(),
    };
}
