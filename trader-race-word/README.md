# A trader's race word does not change who you are talking to

Traders fill in the customer's race with a word swap, `/RACENAME/` ("Let us trade, Shek"). Each of its lines names a race through a Target Race condition, except one fallback "Human" line that names none. A race line passes when the customer, or a nearby member of the customer's squad, is that race. Passing on a squad member never hands the conversation to that member: the character who started the talk keeps it. So when a nearby squad member's race also has a line, the word can be either race.

Checked at the shop of the Hive village beside the test start, with a squad of a Greenlander leader and a Shek, talking with only the Shek selected.

- Her talk order opened the conversation with her both when the Greenlander stood outside the shop and when he stood right beside her.
- With the Greenlander beside her, 8 tries gave "Shek" 4 times and "Human" 4 times. The conversation was hers every time.
- With the Greenlander sent kilometers away, 8 tries gave "Shek" every time, each in her own conversation and trade window. So the "Human" above came from the Greenlander's line passing on him, not from the fallback line.

## Files

| File | What it is |
|---|---|
| `Hive Trade Test.zip` | Mod. Start "Hive Trade Test": a Greenlander leader (Trade Lead) and a Shek (Trade Shek), every skill at 100, beside a Hive village. |
| `HiveTradeShekIn.zip` | Save made from that start with both characters inside the village shop, after the Hive Trader greeted the Shek ("Shek! Welcome Shek!") and before anyone talked to him. |

The save needs the test mod in the load order.

## Steps

1. Load `HiveTradeShekIn` and pause.
2. Select only Trade Shek and right-click the Hive Trader behind the counter to talk.
3. The conversation opens with Trade Shek: her portrait, and a line such as "Trade with me Shek", with "Shek" or "Human" as the race word. Choosing the trade option ("Show me your goods" or similar) opens her trade window.
4. Close the trade window and talk again a few times with Trade Lead standing next to her. Both words turn up, and the conversation is always hers.
5. Select only Trade Lead, open the map and right-click a spot a few kilometers away, then let time run until he gets there.
6. Talk to the trader again with Trade Shek, a few times. The word is always "Shek", and the conversation is still hers.

The trader may move about the shop while time runs, so pause between tries and look for him again if a talk order misses.
