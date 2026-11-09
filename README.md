# Kenshi test data

Saves and small test mods from checks run in the original Kenshi while fixing bugs in [MeitouClient](https://github.com/VlcekM/MeitouClient), so anyone can repeat them. Each folder is one finding, with its own steps.

| Kenshi version | Platform | Load order |
|---|---|---|
| 1.0.68 (Newland) | Windows, Steam | `gamedata.base`, `Newwworld.mod`, `Dialogue.mod`, `rebirth.mod`, then the folder's test mod if one is listed |

No other mods were active.

## Using the files

- A save: unzip it into `%LOCALAPPDATA%\kenshi\save`, so the save's folder sits beside your own saves, then load it from the game's Load Game menu.
- A test mod: unzip it into the game's `mods` folder (`<Kenshi>\mods`), tick it in the launcher's Mods tab, then pick its start from New Game. A start puts the character where the test happens, with money for the bed.
- Untick the test mod and delete the test saves afterwards.

## Folders

- [skeleton-bed-power](skeleton-bed-power): a town's Skeleton Repair Bed works only when the town has a generator.
- [skeleton-bed-healing](skeleton-bed-healing): how fast a Skeleton Repair Bed heals, and in what order.
- [medic-job-robotics](medic-job-robotics): a skeleton with the Medic job but not Robotics does not repair itself.

The test mods copy a few records from the game's own data, as any mod does. Kenshi and its data belong to Lo-Fi Games.
