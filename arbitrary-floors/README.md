# Arbitrary Building Floors (Floors -2 to 5)

Pure-data test mod, save, and portable launcher for testing building floors below 0 and above 3 in MeitouClient.

## Contents

- `mod/House Cellars/House Cellars.mod` and `mod/House Cellars/buildings/`: an original eight-storey concrete building (Floors -2, -1, 0, 1, 2, 3, 4, and 5, plus an unwalkable roof on Floor 6) with exterior walls, windows, a front sliding door and entry ramp, an inward-facing subterranean pit liner on Floor -2, a two-tier interior trigger hull, and partitioned switchback stairs connecting all eight floors. All meshes and collision files are original test geometry with zero base-game assets.
- `save/`: a plain-game save with one character standing inside Floor 0 of the eight-storey building.
- `mods.cfg`: enables only `House Cellars.mod`.
- `Run Arbitrary Floors Test.bat`: copies the test mod into `<Kenshi>/mods/House Cellars` (refusing to overwrite an existing folder), launches `MeitouClient.exe` on `save/` with `mods.cfg`, and removes the temporary mod folder when the game closes.

## How to run

1. Drag and drop your built `MeitouClient.exe` onto `Run Arbitrary Floors Test.bat`, or run:
   ```bat
   "Run Arbitrary Floors Test.bat" "path\to\MeitouClient.exe" "path\to\Kenshi"
   ```
   (If `KENSHI_PATH` is set or Kenshi is in the default Steam folder, the second argument can be omitted.)
2. Alternatively, copy `mod/House Cellars` into your Kenshi `mods` folder manually and launch `MeitouClient.exe --load "<path>\save" --mods-cfg "<path>\mods.cfg"`.

## What to test

1. Press Page Up and Page Down to cycle smoothly across every floor from Floor -2 through Floor 5. Upper storeys (including the roof above Floor 5) should hide cleanly when viewing lower floors, and the camera should descend cleanly into Floor -1 and Floor -2 without snapping up to outside terrain.
2. Right-click outside the front door to walk out onto the entry ramp; the building should close cleanly into its full exterior without the camera jumping to the roof. Right-click back inside to re-enter Floor 0.
3. Flip to Floor 5 and right-click on the top floor: the character should path all the way up the switchback stairs from Floor 0 to Floor 5 in a single click.
4. Flip to Floor -2 and right-click on the bottom floor: the character should path all the way down from Floor 5 to Floor -2 in a single click, and the camera should follow cleanly into the subterranean room.
5. Open Build Mode on Floor -2 or Floor 5, place interior furniture (such as a Bed or Bench), save, and reload to verify floor persistence.
