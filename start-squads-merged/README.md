# A start with two squad templates

Result: in Kenshi 1.0.68, a new-game start whose `squad` list names two squad templates (5 and 25 characters) begins with two squads, Nameless_0 (5) and Nameless_1 (25). MeitouClient 0.20.1 puts all 30 into Nameless_0 and leaves Nameless_1 empty.

Steps (original):
1. Use a data-only test start whose `squad` list names two SQUAD_TEMPLATE records, of 5 and 25 characters. Its mod is the only entry in `mods.cfg`.
2. New Game, pick the start, confirm the characters.
3. Pause, open SQD, then the SQUADS tab.

Character names are blurred in the screenshots.

- `original-start-squads.png`: the original, two squads of 5 and 25.
- `meitou-start-squads.png`: MeitouClient 0.20.1, one squad of 30 and an empty second squad.
