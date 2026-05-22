# Atelier 4 - Arène TDD

Énoncé : [`../atelier4.pdf`](../atelier4.pdf)

Logique de combat d'un gladiateur, implémentée en TDD. Le hasard du dé est isolé pour
rendre les tests déterministes.

## Étape 1 : inversion de contrôle

`Gladiator.Attack` dépendait directement de la classe concrète `Dice` (aléatoire).
On introduit l'interface [`IDice`](Arene/Arene/IDice.cs) : `Dice` l'implémente, `Attack`
en dépend. Les tests injectent alors un dé déterministe
([`DeFixe`](Arene/AreneTest/DeFixe.cs)) à la place du dé aléatoire.

## Étape 2 : backlog implémenté en TDD

Une itération par ligne du backlog, avec les commits `red`, `green` et `refactor` :

1. Erreur : dé truqué hors de 1..6
2. Erreur : un gladiateur ne peut s'attaquer lui-même
3. Attaque standard : `dégâts = dé + force - armure adverse`
4. Deux attaques consécutives : les dégâts se cumulent
5. Armure très supérieure : aucun dégât (jamais négatif)
6. Coup critique : un 6 double `(dé + force)`
7. Mort de l'adversaire : les PV plafonnent à zéro

## Tests

`dotnet test Arene/Arene.slnx` lance les 8 cas.
