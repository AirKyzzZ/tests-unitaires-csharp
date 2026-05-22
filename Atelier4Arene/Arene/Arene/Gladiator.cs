namespace Arene;

public class Gladiator(string name, int health, int strength, int armor)
{
    public string Name { get; } = name;
    public int Health { get; private set; } = health;
    public int Strength { get; private set; } = strength;
    public int Armor { get; private set; } = armor;

    public void Attack(Gladiator opponent, IDice dice)
    {
        if (ReferenceEquals(opponent, this))
        {
            throw new ArgumentException(
                "Un gladiateur ne peut pas s'attaquer lui-même.", nameof(opponent));
        }

        int score = dice.Roll();
        if (score is < 1 or > 6)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dice), score, "Le dé doit produire une valeur entre 1 et 6.");
        }

        int degats = CalculerDegats(score, opponent.Armor);
        opponent.Health = Math.Max(0, opponent.Health - degats);
    }

    private int CalculerDegats(int score, int armureAdverse)
    {
        int degatsBruts = score + Strength;
        if (score == 6)
        {
            degatsBruts *= 2;
        }

        return Math.Max(0, degatsBruts - armureAdverse);
    }
}
