# How a Skeleton Repair Bed heals

In a Black Desert City Skeleton Repair Bed at normal game speed:

- Each limb gains about 1.25 HP per real second.
- No repair kit is needed. Untreated damage heals too.
- Wear (lost maximum HP) is repaired first, with HP rising alongside it; then untreated damage heals at the same rate until the limb is full.

The run used three limbs on one skeleton (maximum 200 each):

| Limb | Before | Result |
|---|---|---|
| Wear only | 100 of 100 (max worn down to 100) | Reached 200 first |
| Damage only | 60 of 200 | Reached 200 about 30 s later |
| Both | 60 of 100 | Reached 200 together with the damage-only limb |

## Files

| File | What it is |
|---|---|
| `Skeleton Bed Test.zip` | Mod. Start "Skeleton Bed Test": one damaged skeleton in Black Desert City with 10,000 cats. |
| `SkeletonBedTest2.zip` | Save before the stay, with the limbs edited to the values above. |
| `DATATEST.zip` | Save taken partway through the stay, paused, to read the limbs' HP and maximum HP. |

## Steps

1. Load `SkeletonBedTest2`.
2. Put the skeleton in the Skeleton Bar's repair bed (200 cats) at normal speed.
3. Watch the limbs in the health panel, or save partway and compare the save's limb values with `SkeletonBedTest2`.
