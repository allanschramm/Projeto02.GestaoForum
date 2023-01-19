using Microsoft.EntityFrameworkCore;

namespace Projeto02.GestaoForum.Models
{
    public class ForumContext : DbContext
    {
        public ForumContext(DbContextOptions<ForumContext> options) : base(options)
        { }

        public DbSet<Forum> Forums { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Forum>().ToTable("FORUM");
            modelBuilder.Entity<Usuario>().ToTable("USUARIO");

            modelBuilder.Entity<Comentario>().ToTable("COMENTARIOS");
            modelBuilder.Entity<Comentario>()
                .Property(p => p.ComentarioInfo)
                .HasColumnName("COMENTARIO");

            modelBuilder.Entity<Comentario>()
                .Property(p => p.ForumId)
                .HasColumnName("IDFORUM");

            modelBuilder.Entity<Comentario>()
                .Property(p => p.UsuarioId)
                .HasColumnName("IDUSUARIO");

        }
    }
}
