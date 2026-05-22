# Atelier 3 - Heure pour assistant vocal

Énoncé : [`../atelier3.pdf`](../atelier3.pdf)

`Horloge.EnTexte(DateTime)` traduit une heure en formulation orale naturelle.

## Démarche TDD

Une itération par cas du backlog de l'énoncé. L'historique git porte, pour chaque
itération, les commits `red`, `green` et `refactor` :

1. Heure pile du matin : `7:00 → "sept heures du matin"`
2. Heure pile de l'après-midi : `14:00 → "deux heures de l'après-midi"`
3. Heure pile spéciale : `12:00 → "midi"`, `00:00 → "minuit"`
4. Tranches de 5 min de la première demi-heure : `12:10 → "midi dix"`, `00:15 → "minuit et quart"`
5. Tranches de 5 min après la demi-heure : `8:45 → "neuf heures moins le quart du matin"`
6. Minutes précises : `8:48 → "neuf heures moins dix du matin à deux minutes près"`

## Choix de conception

- L'arrondi des minutes précises et le passage à l'heure suivante (« neuf heures
  moins dix ») s'appuient sur l'arithmétique de `DateTime` (`AddMinutes`). Les bascules
  délicates (minuit, midi, changement de jour) sont ainsi gérées sans calcul modulaire
  manuel ni cas particulier.
- `EnTexte` se rappelle elle-même sur l'heure arrondie pour le cas « à X minutes près »,
  ce qui réutilise toute la logique d'expression sans la dupliquer.

## Tests

`dotnet test HorlogeParlante/HorlogeParlante.slnx` lance les 22 cas.
