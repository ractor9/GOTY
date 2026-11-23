using Microsoft.EntityFrameworkCore;

namespace GOTY;

public class GOTYContext:DbContext
{
    public GOTYContext(){}
    //Mapegem els DBsets com mapejaven les taules a hibernate
    public DbSet<Candidatura> Candidatura { get; set; }
    public DbSet<Representant> Representant { get; set; }
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if(!optionsBuilder.IsConfigured) optionsBuilder.UseSqlite("Data Source=goty.db").UseLazyLoadingProxies();
        
    }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Candidatura>()
            .Property(a => a.Categoria)
            .HasConversion<string>();
        
        modelBuilder.Entity<Candidatura>()
            .HasOne(c => c.CandidaturaPrincipal)
            .WithMany(c => c.CandidaturesRelacionades)
            .HasForeignKey("CandidaturaPrincipalID")
            .IsRequired(false)
            .OnDelete(DeleteBehavior.Restrict);
        
        modelBuilder.Entity<Candidatura>()
            .HasOne(c => c.Representant)
            .WithOne(r => r.Candidatura)
            .HasForeignKey<Candidatura>("RepresentantID")
            .IsRequired()
            .OnDelete(DeleteBehavior.Restrict);
        
        
    }
}