using System.Data.Entity;

namespace ORM
{
    public partial class DB : DbContext
    {
        public DB()
            : base("name=DB")
        {
        }

        public virtual DbSet<Client> Client { get; set; }
        public virtual DbSet<Compte> Compte { get; set; }
        public virtual DbSet<Operation> Operation { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .Property(e => e.Nom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Prenom)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .Property(e => e.Adresse)
                .IsUnicode(false);

            modelBuilder.Entity<Client>()
                .HasMany(e => e.Compte)
                .WithMany(e => e.Client)
                .Map(m => m.ToTable("ClientCompte").MapLeftKey("IdClient").MapRightKey("IdCompte"));

            modelBuilder.Entity<Compte>()
                .Property(e => e.Libelle)
                .IsUnicode(false);

            modelBuilder.Entity<Compte>()
                .HasMany(e => e.Operation)
                .WithRequired(e => e.Compte)
                .WillCascadeOnDelete(false);
        }
    }
}
