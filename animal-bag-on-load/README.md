# An animal wearing a bag it can't wear loses it when the save loads

When a save has one of the player's animals wearing a bag that its kind can't wear, the original game takes the bag off as the save loads. The bag goes into the animal's own inventory, the part the animal's window never shows, with everything in it.

Checked with a bonedog pup, Kal, wearing a Small Backpack. The Small Backpack names no races, and an animal may only wear a bag that names its race, so normal play can't put it on him. The save was made in MeitouClient with its debug channel (`give "576-gamedata.base" --equip`), which skips that check.

- In MeitouClient, the save loads with Kal wearing the Small Backpack. His bag holds a Dried Meat and a Raw Meat, and it can be opened and used.
- In the original (1.0.68), the same save loads with Kal's backpack slot empty. Saved again, the Small Backpack is in Kal's main inventory section, at cell 0,4, with the Dried Meat and Raw Meat still inside it.

Not checked: a bag of the wrong kind on a pack beast or bull, and a person wearing an item their race can't wear.

## Files

| File | What it is |
|---|---|
| `BagOnLoadStart.zip` | The save as MeitouClient wrote it: Kashyk and Kal in The Hub's bar, Kal wearing the Small Backpack. |
| `BagOnLoadOriginal.zip` | The same game after loading it in the original and saving again: the Small Backpack is in Kal's main inventory. |

`BagOnLoadStart` was written by MeitouClient, so it carries a few MeitouClient entries (a `meitou-mods` folder) that the original ignores.

## Steps

1. Unzip `BagOnLoadStart.zip` into the save folder and load it with the load order below.
2. Select Kal (the second portrait) and open his inventory. In the original the backpack slot is empty; in MeitouClient it shows the Small Backpack.
3. To see where the bag went in the original, save and read Kal's inventory from the save: the Small Backpack is in his `main` section.

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
