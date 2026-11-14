# An item sent back to an animal's bag goes into the bag, not the animal's hidden inventory

A living animal of the player's has a main inventory section that its window never shows. When an item lifted from the animal's bag is sent back and its old cell is taken, the original game puts it into a free cell of the bag, not into that hidden section, even though the hidden section has room.

Checked with a pack beast, Pack Beastssss, wearing a Garru Backpack that holds a Raw Meat at cell 0,0 and a Basic First Aid Kit at cell 2,0.

- Dragging the First Aid Kit onto the Raw Meat swapped them: the kit took cell 0,0 and the Raw Meat was left on the mouse.
- Esc closed the windows and sent the Raw Meat back. Its old cell held the kit, so it went into a free cell of the bag: saved again, the bag holds the kit at 0,0 and the Raw Meat at 2,0. The beast's hidden section holds only its own butchering items, as before.

Not checked: a full bag, an animal with no bag, and a bag that still has items in it being swapped off the beast's bag slot.

## Files

| File | What it is |
|---|---|
| `HeldReturnStart.zip` | The pack beast with the two items in its bag, Thumper standing beside it. |
| `HeldReturnOriginal.zip` | The same game after the steps below in the original, saved again: the Raw Meat is at cell 2,0 of the bag. |

`HeldReturnStart` was written by MeitouClient (the two items were put in the bag there), so it carries a few MeitouClient entries (a `meitou-mods` folder) that the original ignores.

## Steps

1. Unzip `HeldReturnStart.zip` into the save folder and load it with the load order below. Pause.
2. Click the second squad tab, NAMELESS_1, then the pack beast's portrait, then INV. The bag's window opens beside the beast's.
3. Drag the First Aid Kit (cell 2,0) onto the Raw Meat (cell 0,0). The kit takes the meat's place and the meat stays on the mouse.
4. Press Esc. The meat leaves the mouse.
5. Save again and read the beast's inventory from the save: its bag holds the kit at 0,0 and the Raw Meat at 2,0.

## Load order

1. `gamedata.base`
1. `Newwworld.mod`
1. `Dialogue.mod`
1. `rebirth.mod`
1. `Execution.mod`
1. `AssaultDiag.mod`
1. `Nice Map [Zones + Zone names + Roads].mod`
1. `Reactive World.mod`
1. `Universal Wasteland Expansion.mod`
1. `UWE - RW Compatibility Patch.mod`
1. `TimeLightMap.mod`
