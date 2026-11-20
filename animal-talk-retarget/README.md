# A dialogue line's squad search and who holds the talk

For VlcekM/MeitouClient pull request 1100 (from Meitou-Modding-Ecosystem/MeitouClient pull request 26), "Animals stay out of talks". That pull request says that with its switch off, MeitouClient behaves as the original game, where a pack animal carrying a searched item takes over the conversation. These tests compare the original game with MeitouClient on the same saves.

## Result

The original game (1.0.68) lets a line's squad search move the conversation to whoever it finds, a pack animal included, but only after the first line:

- A search in the opening line of a talk never moved the conversation or the trade off the character who started it. This held with the item on the pack animal or on a second person, with a race search, whether the line then passed or failed, and whether the animal stood closer to the trader than the talker or farther away.
- A search in a line reached by clicking a reply did move it. The player side of the dialogue window switched to the pack animal (its portrait and name), and "trade" then opened the animal's inventory against the trader. This happened when the searching line passed and also when it failed on a later condition and another line played instead.

In the original's code, the start of a player conversation puts the talker back as the conversation's target once the opening line has been said and its replies checked; a click on a reply does not. That matches both results.

MeitouClient (master `b0dc8fcd6`, headless) never puts the talker back. It made whoever the search found the conversation's player side in every case, including at the opening line, where the original keeps the talker. In the one-reply-deep save it had already handed the talk to the bull on the first line, because another test root on the same trader ran its search while lines were being picked.

## Setup

- Mod: `mod/Holy Gate Animal Test/Holy Gate Animal Test.mod`. Its source is in `mod/writer/Program.cs`, written with MeitouClient's Meitou.Data.
  - It adds test talk roots to the Holy Nation shopkeepers' dialogue package. Each probe line names the one trader who says it, so each trader runs one case:
    - Holy Weapon Trader: searches the squad for Hashish (`target has item`), passes, then gives a player reply.
    - Holy Hat Trader: the same Hashish search, then fails on "target is female" (both test men are male). This is the shape of the case in the pull request.
    - Holy Armour Trader: a race search for Bull (`target race`) that fails the same way.
    - Holy Construction Trader: the same race search, passing, with a player reply.
  - Round 3 adds a root for the Holy Weapon Trader that opens with "TEST deep: step one, pick a path" and three replies: one leads to a line that searches the squad for Hashish and passes, one to the same search failing on "target is female" with a plain fallback line, and one trades straight away. Both deeper lines offer "let's trade" and "never mind". The current build in `mod/Holy Gate Animal Test` has all rounds; `mod/round-2 build` is the build rounds 1 and 2 used after the first two runs.
  - It also adds three starts at Blister Hill:
    - Gate Test Bull Hashish: Max, with a Pack Bull carrying 3 Hashish in its bag.
    - Gate Test Man Hashish: the man carries the Hashish instead.
    - Gate Test Pair Hashish: Benjie (no items) and Claw (3 Hashish), with a bull carrying nothing.
- An earlier build of the mod, `mod/failing-line-only build`, had only the Weapon Trader probe in its failing form; the first two failing runs below used it.
- Saves:
  - `saves/HolyTraderBullHashish` and `saves/HolyTraderPairHashish` were made by the original.
  - `saves/GT_Deep` is HolyTraderBullHashish as used for round 3.
  - For each case, the squad was moved next to the trader in a copy of the save (squad placed in a row, 10 apart) and loaded in the original.
  - Load order: `gamedata.base`, `Newwworld.mod`, `Dialogue.mod`, `rebirth.mod`, `Holy Gate Animal Test.mod`.
- Original: the talker was selected, then the menu on the trader, Talk to. Where the talk opened a window, its first option was clicked to see whose trade opened.
- MeitouClient: each save was loaded headless with the navmesh and streamed zones. The person nearest the trader was given a Talk order, and the conversation's player side (`ConversationView.Player`) was printed. The outputs are in `meitou-runs/`.

## Cases

| Case | Original 1.0.68 | MeitouClient b0dc8fcd6 | Screenshots (original) |
|---|---|---|---|
| Item search failing, bull carries it, beside Max (Weapon Trader, failing-only build) | Max holds the talk; trade opens Max's inventory | the bull holds the talk | 02, 03 |
| Item search passing, bull carries it (Weapon Trader) | the line plays, so the search found the bull; the reply is offered to Max | the bull holds the talk | 01, 04, 05 |
| Item search failing, bull carries it (Hat Trader) | Max; trade with Max | the bull (`GT_Hat.txt`) | 06, 07 |
| Same, bull 9 from the trader and Max 18 | Max; trade with Max | the bull (`GT_HatBullCloser2.txt`) | 08, 09 |
| Item search passing, a second person (Claw) carries it (Weapon Trader) | the line plays; the reply is offered to Benjie | Claw (`GT_PairWeapon.txt`) | 10 |
| Item search failing, Claw carries it (Hat Trader) | Benjie; trade opens Benjie's inventory | Claw (`GT_PairHat.txt`) | 11, 12 |
| Race search failing, the bull matches (Armour Trader) | Max; trade with Max | the bull (`GT_Armour.txt`) | 13, 14 |
| Race search passing, the bull matches (Construction Trader) | the line plays; the reply is offered to Max | the bull (`GT_Construction2.txt`) | 15 |
| Only the bull selected, menu on a trader | no Talk to entry | not tested here (#1021 already removes it) | 16 |
| Round 3, opening line (no search on its path; a losing test root on the same trader searches while lines are picked) | Max | the bull (`GT_Deep_choices_0_0.txt`) | 17 |
| Round 3, one reply deep, item search passing, bull beside Max | the line plays; the player panel becomes Hash Bull; trade opens Hash Bull's inventory | the bull | 18, 19 |
| Round 3, one reply deep, item search failing, fallback line plays | the player panel is Hash Bull; trade opens Hash Bull's inventory | the bull (`GT_Deep_choices_1_0.txt`) | 21, 22 |
| Round 3, trade straight from the opening line | trade with Max | not run | none kept |
| Round 3, first try with the bull left across the room | the searching line did not play and the talk closed, so the search did not find the bull there | not run | 20 |

`GT_HatBullCloser.txt` and `GT_Construction.txt` in `meitou-runs/` come from layouts that put the squad on an upper floor or a roof in the original, so those two layouts were not used in the original.

## Not covered

- The carried-character search (`target carrying character`): an animal can't carry a person in the base game.
- Who speaks a reply aloud (only the panel a reply was offered in was seen, never a speech bubble), and tokens naming the target after a move.
- A search one reply deep with a second person carrying the item: the code has no animal test, so it should behave as with the bull, but it was not played.
- Repeats: one run of each case. The failing item search was run at two traders, and once with the bull closer.
- A trigger from the base game's data alone: I couldn't get the Holy Nation gate search, which has these lines, to fire.
