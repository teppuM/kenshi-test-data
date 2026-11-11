# Stolen goods name their owner

Goods stolen from a town building are marked as stolen from a person, the owner who lives there, not just from a faction. The item keeps that owner when it is dropped.

Checked in The Hub's bar, which the Trade Ninjas run. The barman is the first member of the squad that lives there.

- Before any theft, the bar's loose shelf items (bowls, jugs, cups) already list the barman as their owner in the save.
- A Dried Meat in one of the bar's barrels has no owner. After it is stolen with Alt held, its tooltip says "Stolen from: Barman" and the save lists the barman as its owner.
- Dropped on the bar's floor, the stolen Dried Meat still lists the barman as its owner. Its label shows red when Alt is held, like the bar's own goods.

## Files

| File | What it is |
|---|---|
| `BarTheftStart.zip` | Save of a fresh Nameless start, with the one character standing behind the counter in The Hub's bar. |
| `BarTheftStolen.zip` | The same game after the Dried Meat was taken from the big barrel behind the counter. It is in the character's inventory. |
| `BarTheftDropped.zip` | The same game after that Dried Meat was dropped on the bar's floor. |

The owner is the save's `ownedby` field of each item: the shelf items and the stolen Dried Meat all name the same character of the `Trade Ninjas_0` squad, whose home building is the bar.

## Steps

1. Load `BarTheftStart` and pause.
2. Hold Alt and right-click the big barrel behind the counter. The barrel's window opens.
3. Hover the Dried Meat: it shows a stealing chance. Right-click it to take it. With no thievery skill the barman catches you about two times in three; reload and try again until it works.
4. Hover the Dried Meat in your inventory: "Stolen from: Barman".
5. Drag it out of the inventory onto the floor and hold Alt: its label is red, like the bar's own goods.
