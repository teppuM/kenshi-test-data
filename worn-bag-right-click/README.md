# A right click on a worn backpack

In the original game (1.0.68), a right click on the backpack a character wears tries to move it into that character's main inventory. If there is no room for it there, the backpack stays on the character's back and no message shows. This was checked with the backpack's own window open, the case that lost the backpack in MeitouClient. A spare backpack in the main inventory goes the other way: a right click on it says "Can't wear that item." (when the character can't wear it) and puts it into the open worn backpack.

In MeitouClient before the fix for issue 703, the worn backpack went into its own open window when the main inventory had no room, so it vanished along with everything inside it.

Checked with the plain game (no mods), on Skinner from this save. He wears a Trader's Wooden Backpack holding goods. It takes 5 x 4 cells in the main inventory, and his main inventory has no 5 x 4 space.

- With his inventory and the backpack's window open, a right click on the worn backpack: it stays on, and no message shows.
- After the three top-left hacksaws are moved into the backpack (a right click on each), there is room, and the same right click moves the backpack into his main inventory.
- With the backpack worn again and its window open, the Pack Bull's empty Bull Backpack in Skinner's main inventory, right clicked: "Can't wear that item.", and it goes into the open Trader's Wooden Backpack.

## Files

| File | What it is |
|---|---|
| `WornBagTestSave.zip` | The test save: ten characters at Black Desert City, made by the original from a start built only from base-game records. |

## Steps

1. Unzip `WornBagTestSave.zip` into the save folder and load `WornBagTest` with no mods.
2. Pause, select Skinner and open his inventory (INV). If the backpack's window is not open beside it, click OPEN BAG.
3. Right-click the backpack in his BACKPACK slot. It stays on.
4. Right-click the first three hacksaws in the top row of his main inventory, so they go into the backpack, then right-click the backpack again. It moves into the main inventory.

## Load order

1. `gamedata.base`
1. `Newwworld.mod`
1. `Dialogue.mod`
1. `rebirth.mod`
