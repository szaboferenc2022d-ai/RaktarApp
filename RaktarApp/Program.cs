using RaktarApp;

List<Termek> termekek = new List<Termek>();
int hibasSorokSzama = 0;

foreach (string sor in File.ReadAllLines("termekek.txt").Skip(1))
{
    if (string.IsNullOrWhiteSpace(sor))
    {
        hibasSorokSzama++;
        continue;
    }
    string[] mezok = sor.Split("|");
    if(mezok.Length != 4)
    {
        hibasSorokSzama++;
        continue;
    }
    if (mezok[0] != "S"  && mezok[0] != "G")
    {
        hibasSorokSzama++;
        continue;
    }
    if (!int.TryParse(mezok[2], out int alapar) || !int.TryParse(mezok[3], out int garancia))
    {
        hibasSorokSzama++;
        continue;
    }
    if (mezok[0] == "S")
    {
        Termek aktualistarmek = new Termek(mezok[0], alapar);
        termekek.Add(aktualistarmek);
    }
    else
    {
        TartosTermek aktualistermek = new TartosTermek(garancia, mezok[0], alapar);
        {
            termekek.Add(aktualistermek);
        }
    }
}

Console.WriteLine($"Sikeresen beolvasot Termrekek: {termekek.Count}");
Console.WriteLine($"Hibás sorok Termekek: {hibasSorokSzama}\n");

foreach (var termek in termekek)
{
    Console.WriteLine(termek);
}
Console.WriteLine();

int teljeseretek = termekek.Sum(t => t.ErtekSzamitas(10));
Console.WriteLine($"Teljes raktárkészlet értéke: {teljeseretek:N0} Ft");

Console.WriteLine($"\nÖsszes termék száma: {Termek.OsszesTermekSzama} db");
