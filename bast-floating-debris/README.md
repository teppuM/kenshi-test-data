# Floating debris in a Bast house (MeitouClient issue 1090)

Result: with the reporter's save and no mods, MeitouClient draws a pile of scrap (poles, tarps, pipes, planks, a bucket) hanging in mid-air over the Old Storm House in Bast where the character Suns stands, while Floor 0 is viewed. The original Kenshi 1.0.68 shows none of it, on Floor 0 or Floor 1. The cause was not found. This folder holds what was seen, for whoever picks it up.

## What was compared

- The original (Kenshi 1.0.68, no mods): on Floor 0 the house opens like MeitouClient's, with barrels, a sack and the stairs, and nothing floating (02). Zoomed out, the bare dead trees round the house carry nothing (03). Floor 1, the roof deck, is clean too (04).
- MeitouClient: the reporter's view on nightly 20261119 (01), and the same on nightly 20261122, windowed (05) and headless (06). In 05 and 06 the room's floor is also much darker than in the original.

## What it is not, in MeitouClient (nightly 20261122, headless, the same save)

- Not a part of the house: hiding every building part with the debug command `interior-hide mesh` removes the house and its furniture, and the debris stays (07). A close view of it with the house hidden (08).
- Not the house's interior layout: the layout ('Trashed') holds barrels, a crate, a stool, two carpets, a wall shelf and a chimney, no scrap.
- Not a placed map feature: `data/newland/land/features.dat` has no placement within 400 units.
- Not another level building or loose item from the level: the level lists only the house there.
- Not a character: the game lists only Suns and his dog nearby.
- Probably not the town's distant mesh, which fades out near the camera.

Not checked: loose items stored in the save's own zone files, and foliage.

## Files

- `save.zip`: the reporter's save, from the issue's feedback report (MeitouClient 0.22.2-nightly.20261119.2, plain game).
- `01` to `08`: the screenshots above.

## Steps

1. Unzip the save into `%LOCALAPPDATA%\kenshi\save`.
2. Load it in MeitouClient with no mods. Suns stands inside the Old Storm House in Bast, Floor 0 viewed: the scrap hangs over the room.
3. Load it in the original with no mods: the same house, opened the same way, shows no scrap.

## Load order

`gamedata.base`, `Newwworld.mod`, `Dialogue.mod`, `rebirth.mod`.
