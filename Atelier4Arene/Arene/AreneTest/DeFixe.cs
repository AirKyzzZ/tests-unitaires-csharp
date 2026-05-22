using Arene;

namespace AreneTest;

internal sealed class DeFixe(int valeur) : IDice
{
    public int Roll() => valeur;
}
