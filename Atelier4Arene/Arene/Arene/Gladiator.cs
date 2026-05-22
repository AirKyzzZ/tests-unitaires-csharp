namespace Arene;

public class Gladiator(string name, int health, int strength, int armor)
{
    public string Name { get; } = name;
    public int Health { get; private set; } = health;
    public int Strength { get; private set; } = strength;
    public int Armor { get; private set; } = armor;

    public void Attack(Gladiator opponent, IDice dice)
    {
        int score = dice.Roll();
        if (score is < 1 or > 6)
        {
            throw new ArgumentOutOfRangeException(
                nameof(dice), score, "Le dé doit produire une valeur entre 1 et 6.");
        }

        throw new NotImplementedException("To be done");
    }
}
