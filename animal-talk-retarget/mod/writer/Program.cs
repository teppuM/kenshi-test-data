using Meitou.Content;
using Meitou.Data;
using Meitou.Data.Fcs;
// Writes "Holy Gate Animal Test.mod": two new-game starts at Blister Hill, each a naked male Greenlander with a Pack Bull.
//   "Gate Test Bull Hashish": the bull's bag holds 3 Hashish, the man carries nothing.
//   "Gate Test Man Hashish":  the man carries 3 Hashish, the bull's bag is empty (the control).
// Purpose: talk to a Holy Nation Gate Guard (its event-1 root "Forbidden/ drug check holy nation part 2") and see who the search makes the target.
var install = GameInstall.Locate()!;
var db = GameDatabase.Load(LoadOrder.BaseGame(install));
const string Mod = "Holy Gate Animal Test.mod";
const string Hashish = "1230-gamedata.base", BlisterHill = "12628-Newwworld.mod", PackBull = "47929-rebirth.mod", TraderSquad = "47928-rebirth.mod";
var file = new FcsFile();
file.Dependencies.AddRange(["gamedata.base", "Newwworld.mod", "Dialogue.mod", "rebirth.mod"]);
file.Author = "test";
file.Description = "Test starts for the Holy Nation gate search with a pack animal.";
int next = 1;

var hashList = New(FcsRecordType.VendorList, "gate test hashish");
hashList.Ints["items count"] = 3;
hashList.Ints["money item max"] = 0; hashList.Ints["money item min"] = 0; hashList.Floats["money item prob"] = 0;
Ref(hashList, "items", Hashish, 100);

FcsRecord Man(string name, bool hashish)
{
    var c = New(FcsRecordType.Character, name);
    CopyFields(db.Find("2184-gamedata.base")!, c);
    c.Bools["named"] = true;
    Ref(c, "race", "17-gamedata.quack", 100);
    if (hashish) Ref(c, "inventory", Hashish, 3);
    return c;
}
FcsRecord Bull(string name, bool hashish)
{
    var src = db.Find(PackBull)!;
    var b = New(FcsRecordType.AnimalCharacter, name);
    CopyFields(src, b);
    foreach (var list in src.ReferenceLists) foreach (var r in src.GetReferences(list)) Ref(b, list, r.TargetStringId, r.Values.Value0, r.Values.Value1, r.Values.Value2);
    if (hashish) Ref(b, "inventory", hashList.StringId);
    return b;
}
FcsRecord Squad(string name, FcsRecord man, FcsRecord bull)
{
    var sq = New(FcsRecordType.SquadTemplate, name);
    CopyFields(db.Find(TraderSquad)!, sq);
    Ref(sq, "leader", man.StringId, 1);
    Ref(sq, "animals", bull.StringId, 1, 1, 50);
    return sq;
}
FcsRecord Start(string name, FcsRecord squad)
{
    var s = New(FcsRecordType.NewGameStartoff, name);
    CopyFields(db.Find("2287-gamedata.base")!, s);
    s.Ints["money"] = 1000;
    s.Bools["force start pos"] = false;   // Rock Bottom's copied fields force its own spot; off, the squad starts inside Blister Hill
    s.Strings["description"] = name;
    Ref(s, "town", BlisterHill);
    Ref(s, "squad", squad.StringId);
    return s;
}
// The trader probe, the shape of the reported case: a talk root added to the Holy Nation shopkeepers' package (event 1, a player talks to me)
// whose only line searches the squad for Hashish and then fails on a later test (the target must be female; the test men are male). The
// line never shows; what the test watches is whether the probe alone hands the talk to the bull.
var female = New(FcsRecordType.DialogAction, "gate test target is female");
female.Ints["condition name"] = 45; female.Ints["compare by"] = 0; female.Ints["who"] = 1; female.Ints["tag"] = -1; female.Strings["stringvar"] = "";
var probeLine = New(FcsRecordType.DialogueLine, "DIALOGUE_LINE");
probeLine.Strings["text0"] = "TEST: the hashish search passed";
probeLine.Ints["speaker"] = 0; probeLine.Ints["repetition limit"] = 0; probeLine.Ints["score bonus"] = 0; probeLine.Ints["target is type"] = 0;
probeLine.Floats["chance permanent"] = 100; probeLine.Floats["chance temporary"] = 100;
Ref(probeLine, "target has item", Hashish);
// control run: no failing condition, so the line passes and shows whom the search made the target
var probeRoot = New(FcsRecordType.Dialogue, "gate test trader hashish probe");
probeRoot.Strings["tag"] = ""; probeRoot.Ints["repetition limit"] = 0; probeRoot.Ints["score bonus"] = 50; probeRoot.Ints["target is type"] = 0;
probeRoot.Floats["chance permanent"] = 100; probeRoot.Floats["chance temporary"] = 100;
probeRoot.Bools["for enemies"] = false; probeRoot.Bools["locked"] = false; probeRoot.Bools["monologue"] = false; probeRoot.Bools["one at a time"] = false;
Ref(probeRoot, "lines", probeLine.StringId);
var shopkeep = new FcsRecord { Type = (int)FcsRecordType.DialoguePackage, Id = 0, Name = "Holy Nation Shopkeep", StringId = "42968-Dialogue.mod", Flags = 0x11 };
file.Records.Add(shopkeep);
Ref(shopkeep, "dialogs", probeRoot.StringId, 1);
Start("Gate Test Bull Hashish", Squad("start- gate bull hashish", Man("Pilgrim", false), Bull("Hash Bull", true)));
Start("Gate Test Man Hashish", Squad("start- gate man hashish", Man("Smuggler", true), Bull("Plain Bull", false)));

// Made last so the earlier records keep their ids (a save made with an earlier build names them).
// the player's reply (speaker 1, the target): the dialogue window shows whose reply it is
var reply = New(FcsRecordType.DialogueLine, "DIALOGUE_LINE");
reply.Strings["text0"] = "TEST reply: who answers?";
reply.Ints["speaker"] = 1; reply.Ints["repetition limit"] = 0; reply.Ints["score bonus"] = 0; reply.Ints["target is type"] = 0;
reply.Floats["chance permanent"] = 100; reply.Floats["chance temporary"] = 100;
Ref(probeLine, "lines", reply.StringId);

// Round 2 (2026-11-20, added after every earlier record so saves made with earlier builds still load). Each probe line names the one
// trader that says it (`is character`, tested before any squad search), so each Holy trader carries one variant:
//   Holy Weapon Trader: the item probe above, passing, with a player reply;
//   Holy Hat Trader: the item probe failing on "target is female";
//   Holy Armour Trader: a race probe (Bull) failing the same way;
//   Holy Construction Trader: the race probe passing, with a player reply.
Ref(probeLine, "is character", "2236-gamedata.base");
FcsRecord Probe(string name, string trader, string list, string target, bool failing, string text)
{
    var line = New(FcsRecordType.DialogueLine, "DIALOGUE_LINE");
    line.Strings["text0"] = text;
    line.Ints["speaker"] = 0; line.Ints["repetition limit"] = 0; line.Ints["score bonus"] = 0; line.Ints["target is type"] = 0;
    line.Floats["chance permanent"] = 100; line.Floats["chance temporary"] = 100;
    Ref(line, "is character", trader);
    Ref(line, list, target);
    if (failing) Ref(line, "conditions", female.StringId, 1);
    else
    {
        var answer = New(FcsRecordType.DialogueLine, "DIALOGUE_LINE");
        answer.Strings["text0"] = "TEST reply: who answers?";
        answer.Ints["speaker"] = 1; answer.Ints["repetition limit"] = 0; answer.Ints["score bonus"] = 0; answer.Ints["target is type"] = 0;
        answer.Floats["chance permanent"] = 100; answer.Floats["chance temporary"] = 100;
        Ref(line, "lines", answer.StringId);
    }
    var root = New(FcsRecordType.Dialogue, name);
    root.Strings["tag"] = ""; root.Ints["repetition limit"] = 0; root.Ints["score bonus"] = 50; root.Ints["target is type"] = 0;
    root.Floats["chance permanent"] = 100; root.Floats["chance temporary"] = 100;
    root.Bools["for enemies"] = false; root.Bools["locked"] = false; root.Bools["monologue"] = failing; root.Bools["one at a time"] = false;
    Ref(root, "lines", line.StringId);
    Ref(shopkeep, "dialogs", root.StringId, 1);
    return root;
}
Probe("gate test hat trader item failing", "2256-gamedata.base", "target has item", Hashish, true, "(test line: never shown)");
Probe("gate test armour trader race failing", "2249-gamedata.base", "target race", "3985-gamedata.base", true, "(test line: never shown)");
Probe("gate test construction trader race passing", "2243-gamedata.base", "target race", "3985-gamedata.base", false, "TEST: the bull race search passed");
// A squad of two people and a bull: the talker carries nothing, the second person carries the Hashish.
var talker = Man("Talker", false);
var carrier = Man("Carrier", true);
var pairBull = Bull("Pair Bull", false);
var pair = Squad("start- gate pair hashish", talker, pairBull);
Ref(pair, "squad", carrier.StringId, 1);
Start("Gate Test Pair Hashish", pair);

file.NextId = next;
Directory.CreateDirectory(args[0]);
var path = Path.Combine(args[0], Mod);
FcsWriter.WriteFile(file, path);
var check = GameDatabase.Load(LoadOrder.BaseGame(install));
check.Apply(FcsReader.ReadFile(path), Mod);
Console.WriteLine("issues: " + string.Join(" | ", check.Issues.Where(i => i.File.Contains("Gate"))));
foreach (var r in check.Records.Values.Where(r => r.DefinedBy == Mod || r.ModifiedBy.Contains(Mod)))
    Console.WriteLine($"{r.Type} {r.Name}: " + string.Join(", ", r.ReferenceLists.Where(l => l != "animations" && (r.DefinedBy == Mod || l == "dialogs")).SelectMany(l => r.GetReferences(l).Select(x => $"{l}->{check.Find(x.TargetStringId)?.Name ?? x.TargetStringId}"))));
return;
FcsRecord New(FcsRecordType type, string name)
{
    var r = new FcsRecord { Type = (int)type, Id = next, Name = name, StringId = $"{next}-{Mod}", Flags = 0x10 };
    next++;
    file.Records.Add(r);
    return r;
}
void CopyFields(GameRecord from, FcsRecord to)
{
    foreach (var (k, v) in from.Ints) to.Ints[k] = v;
    foreach (var (k, v) in from.Floats) to.Floats[k] = v;
    foreach (var (k, v) in from.Bools) to.Bools[k] = v;
    foreach (var (k, v) in from.Strings) to.Strings[k] = v;
    foreach (var (k, v) in from.Filenames) to.Filenames[k] = v;
}
void Ref(FcsRecord r, string list, string target, int v0 = 0, int v1 = 0, int v2 = 0)
{
    if (!r.References.TryGetValue(list, out var l)) r.References[list] = l = [];
    l.Add(new FcsReference(target, v0, v1, v2));
}
