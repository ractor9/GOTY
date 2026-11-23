using GOTY;
using GOTY.Services;
using Microsoft.EntityFrameworkCore;

using var db = new GOTYContext();
db.Database.EnsureDeleted();    // primer esborrar...
db.Database.EnsureCreated();    // ...i després crear, amb les taules noves de cada sessió

// ============ Nivell 1 · Seed ============
// Cada animal porta el seu xip: no cal fer db.Xip.Add, EF segueix la navegació.
// No posem DataImplantacio: surt la d'avui, del constructor.
Representant Repr1 = new Representant() {Nom = "Christopher Larkin", Carrec = "Compositor", Estudi = "Team Cherry" };
Representant Repr2 = new Representant() {Nom = "Ari Gibson", Carrec = "Director Artístic", Estudi = "Team Cherry" };
Representant Repr3 = new Representant() {Nom = "William Pellen", Carrec = "Productor Executiu", Estudi = "Team Cherry" };
Representant Repr4 = new Representant() {Nom = "Guillaume Broche", Carrec = "Director", Estudi = "SandFall Interative" };
Representant Repr5 = new Representant() { Nom = "Masayuki Yamada", Carrec = "Director", Estudi = "Sony Interactive" };

List<Representant> representants = new List<Representant>()
{
    Repr1,
    Repr2,
    Repr3,
    Repr4,
    Repr5,
};
db.Representant.AddRange(representants);
db.SaveChanges();
Candidatura Candidatura3 = new Candidatura()
{
    NomJoc = "Hollow Knight: Silksong", Categoria = CategoriaGOTY.MillorJoc, Any = 2025, HaGuanyat = false,
    VotsPublic = 25600, Representant = Repr3
};
List<Candidatura> candidaturas = new List<Candidatura>()
{
    Candidatura3,
    new Candidatura() {NomJoc = "Hollow Knight: Silksong", Categoria = CategoriaGOTY.MillorBandaSonora, Any = 2025, HaGuanyat = true, VotsPublic = 15420, Representant = Repr1, CandidaturaPrincipal = Candidatura3},
    new Candidatura() {NomJoc = "Hollow Knight: Silksong", Categoria = CategoriaGOTY.MillorDireccioArt, Any = 2025, HaGuanyat = false, VotsPublic = 18930, Representant = Repr2, CandidaturaPrincipal = Candidatura3},
    new Candidatura() {NomJoc = "Expedition 33", Categoria = CategoriaGOTY.MillorJoc, Any = 2025, HaGuanyat = true, VotsPublic = 32100, Representant = Repr4},
    new Candidatura() {NomJoc = "Astrobot", Categoria = CategoriaGOTY.MillorJoc, Any = 2024, HaGuanyat = true, VotsPublic = 8200, Representant = Repr5}
};
db.Candidatura.AddRange(candidaturas);
db.SaveChanges();

CandidaturaService candidaturaService = new CandidaturaService(db);

Console.WriteLine("--- GetGuanyadors ---");
List<Candidatura> candidatures = candidaturaService.GetGuanyadors(2025);
foreach (var c in candidatures)
{
    Console.WriteLine(c);
}