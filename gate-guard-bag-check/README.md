# A gate guard's bag check ends with the search

With Universal Wasteland Expansion, a Shek gate guard can stop a player character who is outside a town's walls ("You there.") and walk up to search their bags. In the original game (1.0.68), once that search conversation ends ("Go."), the guard stays where he is and says nothing more.

In MeitouClient before the fix for issue 707, the guard's bag check went on after the conversation closed. He said "Bag check.", "I can see you, rambler...", "I will not give up...", "Tch, don't say I didn't warn you...", walking back to the player for each line with nothing to say on arrival, and the last line, "Kill her.", put a bounty on the player and the gate guards attacked.

Checked at Squin with a new game's starting character, Firebone.

- In the original (1.0.68), with this save: after the search and "Go.", the guard stayed put.
- In MeitouClient before the fix: the guard came back for each of the later lines and the guards attacked about half an hour of game time later.
- In MeitouClient with the fix: the guard stayed put for the hour of game time that followed.

## Files

| File | What it is |
|---|---|
| `BagCheckTestSave.zip` | Firebone at Squin, saved in MeitouClient. |

The save was written by MeitouClient, so it carries a few MeitouClient entries (a `meitou-mods` folder) that the original ignores.

## Steps

1. Unzip `BagCheckTestSave.zip` into the save folder and load it with the load order below.
2. Walk out of the gate guards' sight, then go in and out of Squin's gates. The bag check comes from the leader of a gate's guard squad, only while the player character is outside the walls, on a 30% roll each time he notices them, and at most once every 2 game hours for each guard, so it can take a few tries.
3. When the guard stops you and the search opens, choose "(Show them your gear)". He says "Go."
4. Watch the guard for half an hour of game time. In the original he says nothing more and does not come back.

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
