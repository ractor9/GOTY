using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace GOTY;

public class Candidatura
{
    [Required]
    public int CandidaturaID { get; set; }
    
    [Required]
    [MaxLength(100)]
    public string NomJoc { get; set; }
    
    public CategoriaGOTY Categoria { get; set; }
    
    public int Any { get; set; }
    
    public bool HaGuanyat { get; set; }
    
    public int VotsPublic { get; set; }
    
    public virtual Candidatura CandidaturaPrincipal { get; set; }
    
    public virtual ICollection<Candidatura> CandidaturesRelacionades { get; set; }
    
    [Required]
    public virtual Representant Representant { get; set; }

    public override string ToString()
    {
        return
            $"Candidatura {{CandidaturaID = {CandidaturaID}, NomJoc = {NomJoc}, Categoria = {Categoria}, Any = {Any}, HaGuanyat = {HaGuanyat}, VotsPublic = {VotsPublic},  Representant = {Representant}}}";

    }

    public Candidatura()
    {
        CandidaturesRelacionades = new HashSet<Candidatura>();
    }
}