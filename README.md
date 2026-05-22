# Tests unitaires, C#

Ateliers de la matière *Tests unitaires* (EPSI, 2e année, 2025/2026).

**Auteur :** Maxime Mansiet, réalisé en solo.
**Cible :** .NET 10 / MSTest.

## Contenu

| Atelier | Sujet | Dossier | Approche |
|--------:|-------|---------|----------|
| 1 | Test d'une classe `Produit` (stock) | [`Atelier1Stock/`](Atelier1Stock/) | Tests *a posteriori* + correction des membres erronés |
| 2 | Test du module `ShoppingCart` | [`Atelier2ShoppingCart/`](Atelier2ShoppingCart/) | Tests factorisés (usuels / extrêmes / erreur) |
| 3 | Heure pour assistant vocal | [`Atelier3HeureVocale/`](Atelier3HeureVocale/) | **TDD strict** (Red / Green / Refactor) |
| 4 | Arène, combat de gladiateurs | [`Atelier4Arene/`](Atelier4Arene/) | **TDD strict** + inversion de contrôle |

Les énoncés des ateliers 1 et 2 sont dans le `readme.md` de leur dossier ; ceux des
ateliers 3 et 4 sont les PDF à la racine.

## Lancer les tests

Chaque atelier est une solution autonome :

```bash
dotnet test Atelier1Stock/AtelierStock/AtelierStock.sln
dotnet test Atelier2ShoppingCart/AtelierShoppingCart/ShoppingCart.sln
dotnet test Atelier3HeureVocale/HorlogeParlante/HorlogeParlante.sln
dotnet test Atelier4Arene/Arene/Arene.sln
```

## Note sur les ateliers TDD (3 & 4)

Le cycle TDD est tracé dans l'historique git : chaque itération comporte un commit
`red` (test qui échoue), `green` (implémentation minimale) et, le cas échéant,
`refactor`. L'historique se lit donc comme le déroulé du raisonnement.
