# A start with two squad templates

Result: in Kenshi 1.0.68, a new-game start whose `squad` list names two squad templates (5 and 25 characters) begins with two squads, Nameless_0 (5) and Nameless_1 (25). MeitouClient 0.20.1 puts all 30 into Nameless_0 and leaves Nameless_1 empty.

Steps (original):
1. Use a data-only test start whose `squad` list names two SQUAD_TEMPLATE records, of 5 and 25 characters. Its mod is the only entry in `mods.cfg`.
2. New Game, pick the start, confirm the characters.
3. Pause, open SQD, then the SQUADS tab.

Character names are blurred in the screenshots.

- `original-start-squads.png`: the original, two squads of 5 and 25.
- `meitou-start-squads.png`: MeitouClient 0.20.1, one squad of 30 and an empty second squad.

## Templates mixed with characters

Result: in Kenshi 1.0.68 the first squad template's squad is Nameless_0, and every CHARACTER entry's characters join it after the template's members, whatever the list order. Each further template is a squad of its own. The character editor lists every start character.

- `Mix Test 1` lists two Loner characters, then a template of three (Alpha). It gave one squad: Alpha 1, Alpha 2, Alpha 3, Loner, Loner (`original-mix-test-1.png`).
- `Mix Test 2` lists templates of three (Alpha) and five (Bravo), then two Loners. It gave Nameless_0 with Alpha 1 to 3 and both Loners, and Nameless_1 with Bravo 1 to 5 (`original-mix-test-2.png`).

Steps: put `Start Mix Test.mod` in `Kenshi\mods\Start Mix Test\` and list it alone in `mods.cfg`. New Game, pick the start, confirm the characters, pause, open SQD, then the SQUADS tab.
