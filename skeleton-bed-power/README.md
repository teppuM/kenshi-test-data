# Skeleton Repair Beds and town power

The Skeleton Repair Bed draws 10 power (its building's `power output` is -10 in the game data). A town's bed works only when the town has a generator; the owner faction does not matter. Lying down in one:

| Town | Owner | Power in the town | Result |
|---|---|---|---|
| Black Desert City | Skeletons | Small Generators | Lets you in and heals you |
| Burn's Tower | Skeletons | A Small Wind Generator | Lets you in and heals you |
| Skinhouse HQ | Skin Bandits | Small Generators and Generator IIs | Lets you in and heals you (checked in a normal game; no save here) |
| Island Lab | Fishmen | Two Battery Banks, no generator | Refuses: "This bed needs power to operate." |
| Reprogramming Workshop | Ancient Ruins | None | Refuses: "This bed needs power to operate." |

Changing the game data shows what decides it:

| Test mod | Where | Result |
|---|---|---|
| `No Generators Test` (every generator's power output 0) | Black Desert City, `SkeletonBedTest` | Refuses |
| `Skeletons Not Real Test` (the Skeletons faction's "not real" flag on) | Black Desert City, `SkeletonBedTest` | Still works |
| `Fishmen Real Test` (the Fishmen faction's "not real" flag off) | Island Lab, `FishmanTest` and a new game | Still refuses |
| `Fishmen Relation Test` (the Fishmen faction's default relation 0) | Island Lab, `FishmanTest` and a new game | Still refuses |

A save keeps each faction's relations, so a default relation change only takes effect in a new game. The "not real" flag does reach a loaded save.

## Files

| File | What it is |
|---|---|
| `Skeleton Bed Test.zip` | Mod. Start "Skeleton Bed Test": one damaged skeleton in Black Desert City with 10,000 cats. |
| `Ruin Bed Test.zip` | Mod. Two starts: one skeleton with 10,000 cats at Burn's Tower or at the Reprogramming Workshop, its owners friendly. |
| `Island Lab Bed Test.zip` | Mod. Start: a skeleton and a human in the Island Lab with 10,000 cats, the Fishmen friendly. |
| `No Generators Test.zip` | Mod. Sets the power output of every generator to 0. |
| `Skeletons Not Real Test.zip` | Mod. Turns on the Skeletons faction's "not real" flag. |
| `Fishmen Real Test.zip` | Mod. Turns off the Fishmen faction's "not real" flag. |
| `Fishmen Relation Test.zip` | Mod. Sets the Fishmen faction's default relation to 0. |
| `SkeletonBedTest.zip` | Save from the Black Desert City start. |
| `BurnsTest.zip` | Save from the Burn's Tower start. |
| `ReprogrammingTest.zip` | Save from the Reprogramming Workshop start. |
| `FishmanTest.zip` | Save from the Island Lab start. |

## Steps

1. Tick the matching start mod (each save needs the mod its start came from), plus one of the four test mods if you want that change. Load a save, or start a new game with the start.
2. Select the skeleton and right-click a Skeleton Repair Bed to use it (pay the rent where asked).
3. Black Desert City and Burn's Tower: the skeleton lies down and its limbs heal. Island Lab and Reprogramming Workshop: the message "This bed needs power to operate." appears and it does not lie down.

The starts make the owners friendly to your character so the test stays peaceful.
