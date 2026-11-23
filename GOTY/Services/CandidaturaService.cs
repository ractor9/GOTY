namespace GOTY.Services;

public class CandidaturaService
{
    private GOTYContext _context;

    public CandidaturaService(GOTYContext context)
    {
        _context = context;
    }
    public List<Candidatura> GetGuanyadors(int anyMinim)
    {
        List<Candidatura> llista = _context.Candidatura
            .Where(a => a.HaGuanyat == true && a.Any >= anyMinim)
            .ToList();
        return llista;
    }
}