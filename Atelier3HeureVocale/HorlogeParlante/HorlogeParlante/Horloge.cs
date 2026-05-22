namespace HorlogeParlante;

public static class Horloge
{
    private static readonly string[] NomsHeures =
        { "", "une", "deux", "trois", "quatre", "cinq", "six",
          "sept", "huit", "neuf", "dix", "onze" };

    public static string EnTexte(DateTime heure)
    {
        int minute = heure.Minute;
        int reste = minute % 5;

        if (reste != 0)
        {
            int ecart = reste <= 2 ? reste : reste - 5;
            DateTime arrondie = heure.AddMinutes(-ecart);
            return $"{EnTexte(arrondie)} à {Precision(Math.Abs(ecart))}";
        }

        return minute <= 30
            ? Composer(heure.Hour, MinutesAvant(minute))
            : Composer((heure.Hour + 1) % 24, MinutesApres(minute));
    }

    private static string Precision(int ecartMinutes)
        => ecartMinutes == 1 ? "une minute près" : "deux minutes près";

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
        _  => throw new ArgumentOutOfRangeException(
            nameof(minute), minute, "Minute attendue : un multiple de 5."),
    };

    private static string MinutesApres(int minute) => minute switch
    {
        35 => " moins vingt-cinq",
        40 => " moins vingt",
        45 => " moins le quart",
        50 => " moins dix",
        55 => " moins cinq",
        _  => throw new ArgumentOutOfRangeException(
            nameof(minute), minute, "Minute attendue : un multiple de 5."),
    };
}
