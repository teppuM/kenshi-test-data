# A carried, unconscious squad member trades through their own window

An unconscious squad member who is being carried can still trade. During a trade, clicking their portrait puts their inventory beside the trader's, and items can be sold from it and bought back into it.

Checked in a town bar with a squad of three: Vale, Corin, and Beep, who is unconscious with his head below zero.

- Vale picked Beep up, carried him into the bar and opened a trade with the barman ("Show me your goods."). The trade opened with Vale's inventory beside the barman's.
- Clicking Beep's portrait during the trade put Beep's inventory in its place, beside the barman's.
- A Basic First Aid Kit dragged from Beep's inventory to the barman's sold for its listed sell value, 29 cats: the squad's money went from 15,683 to 15,712 and the barman's from 2,000 to 1,971. The kit is marked as stolen from a Fogman.
- Dragged back into Beep's inventory, it was bought back for the same 29 cats: the squad's money returned to 15,683, and the kit was in Beep's inventory again (his carried weight went from 25 to 24 and back to 25).

Not checked: an unconscious squad member lying on the ground rather than carried, and buying the trader's own goods into a carried member (this barman had nothing for sale).

## Files

| File | What it is |
|---|---|
| `CarriedTradeStart.zip` | Save with the squad outside the bar's door. Beep lies unconscious at Corin's feet. |
| `CarriedTradeBar.zip` | The same game after Vale picked Beep up and carried him inside the bar, before the trade. |

Beep was knocked out in MeitouClient before the game was first loaded in the original, so the saves carry a few extra MeitouClient entries that the original ignores. Both saves were then loaded and written by the original, and every step below was done there.

## Steps

1. Load `CarriedTradeStart` and pause.
2. Corin stands over Beep, which makes Beep hard to click: select Corin, right-click the ground a few steps away, and let time run until he moves.
3. Select Vale, hold right-click on Beep and choose Pick Up. Let time run until Vale carries him.
4. Right-click the bar's door, to the right of the squad, and let time run until Vale is inside. (Or load `CarriedTradeBar`, which starts here.)
5. Hold right-click on the barman, the woman behind the counter, choose Talk To, and pick "Show me your goods." The trade opens with Vale's inventory beside the barman's. The barman's side is empty: she has nothing for sale.
6. Click Beep's portrait. Beep's inventory takes the place of Vale's beside the barman's.
7. Drag the single Basic First Aid Kit at the lower left of Beep's inventory (not the stacks of 2 on the right) into the barman's inventory. It sells for 29 cats.
8. Drag it back into Beep's inventory. It is bought back for 29 cats and the squad's money returns to where it was.

Beep stays unconscious through all of this: his head heals slowly but stays below zero.
