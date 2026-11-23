using System.ComponentModel.DataAnnotations;

namespace GOTY;

public class Representant
{
    [Required]
    public int RepresentantID { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Nom { get; set; }
    
    [Required]
    [MaxLength(60)]
    public string Carrec { get; set; }
    
    [Required]
    [MaxLength(80)]
    public string Estudi { get; set; }
    
    public virtual Candidatura Candidatura { get; set; }
    
    public override string ToString()
    {
        return $"Representant {{RepresentantID = {RepresentantID}, Nom = {Nom}, Carrec = {Carrec}, Estudi = {Estudi}";
    }
    
    public Representant()
    {
        
    }
}