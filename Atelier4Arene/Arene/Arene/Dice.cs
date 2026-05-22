namespace Arene;

public class Dice(int faces)
{
    private readonly Random rnd = new();

    public int Roll() => rnd.Next(1, faces + 1);
}
