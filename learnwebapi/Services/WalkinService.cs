using learnwebapi.Models;

namespace learnwebapi.Services;

public static class WalkinService
{
    static List<Walkin> Walkins { get; }
    static int nextId = 3;
    static WalkinService()
    {
        Walkins = new List<Walkin>
        {
            new Walkin { Id = 1, Title = "Walkin for multiple roles", Duration = "1-Jul-2022 to 14-Jul-2022",Roles="['DEV','QA','DESIGNER']",Location="Mumbai",General_instruc="blah blah blah g ..",System_req="blah blah blahs ..",ExpiresIn="blah blah blah e..",InternshipDetails="blah blah blah i .." },
             new Walkin { Id = 2, Title = "Walkin for DESIGNER roles", Duration = "5-Jul-2022 to 15-Jul-2022",Roles="['DESIGNER']",Location="Mumbai",General_instruc="blah blah blah g ..",System_req="blah blah blahs ..",ExpiresIn="blah blah blah e..",InternshipDetails="blah blah blah i .." },
        };
    }

    public static List<Walkin> GetAll() => Walkins;

    public static Walkin? Get(int id) => Walkins.FirstOrDefault(p => p.Id == id);

    public static void Add(Walkin walkin)
    {
        walkin.Id = nextId++;
        Walkins.Add(walkin);
    }

    public static void Delete(int id)
    {
        var walkin = Get(id);
        if(walkin is null)
            return;

        Walkins.Remove(walkin);
    }

    public static void Update(Walkin walkin)
    {
        var index = Walkins.FindIndex(p => p.Id == walkin.Id);
        if(index == -1)
            return;

        Walkins[index] = walkin;
    }
}