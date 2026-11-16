# Squads screen with a squad over 20

Result: in Kenshi 1.0.68, the Squads tab shows each squad's portraits at full size, 9 to a row, wrapping into more rows with a scroll bar inside the squad's box. A squad of 25 shows rows of 9, 9 and 7. MeitouClient 0.20.1 puts every member of a squad in one row and shrinks the portraits to fit, so a squad of 30 gets tiny portraits.

Also seen in the original: a new-game start can hold a squad of 25 against the limit of 20. The count then shows 25/20 in dark red, and the faction count 30/30 is dark red too. A squad under the limit (5/20) shows its count in the normal dark text.

Steps (original):
1. Use a data-only test start with two squad templates of 5 and 25 characters (30 in all). Its mod is the only entry in `mods.cfg`.
2. New Game, pick the start, confirm the characters.
3. Pause, open SQD, then the SQUADS tab.
4. Scroll the big squad's box with the arrow on its scroll bar.

Character names are blurred in the screenshots.

- `original-squads.png`: the original, top of the Squads tab.
- `original-squads-scrolled.png`: the original, the 25 squad scrolled down.
- `meitou-squads.png`: MeitouClient 0.20.1, a squad of 30.
