using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace US07.Models
{
    // Vous pouvez ajouter des données de profil pour l'utilisateur en ajoutant d'autres propriétés à votre classe ApplicationUser. Pour en savoir plus, consultez https://go.microsoft.com/fwlink/?LinkID=317594.
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Notez qu'authenticationType doit correspondre à l'élément défini dans CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Ajouter les revendications personnalisées de l’utilisateur ici
            return userIdentity;
        }
    }

    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<Membre> Membres { get; set; }
        public DbSet<CaisseSecteur> CaisseSecteurs { get; set; }
        public DbSet<TransactionSecteur> TransactionSecteurs { get; set; }
        public DbSet<ProduitSecteur> ProduitSecteurs { get; set; }
        public DbSet<DepalcementSecteur> DepalcementSecteurs { get; set; }
        public DbSet<Compte> Comptes { get; set; }
        public DbSet<Parametrage> Parametrages { get; set; }
        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CaisseSecteur>().Property(x => x.Collecte).HasPrecision(18, 3);
            modelBuilder.Entity<CaisseSecteur>().Property(x => x.Credit).HasPrecision(18, 3);
            modelBuilder.Entity<TransactionSecteur>().Property(x => x.Montant).HasPrecision(18, 3);
            modelBuilder.Entity<ProduitSecteur>().Property(x => x.MntDonnee).HasPrecision(18, 3);
            modelBuilder.Entity<ProduitSecteur>().Property(x => x.MntReste).HasPrecision(18, 3);
            modelBuilder.Entity<DepalcementSecteur>().Property(x => x.MntReste).HasPrecision(18, 3);
            modelBuilder.Entity<DepalcementSecteur>().Property(x => x.MntDonnee).HasPrecision(18, 3);
            modelBuilder.Entity<Parametrage>().Property(x => x.Montant).HasPrecision(18, 3);
            base.OnModelCreating(modelBuilder);
        }
        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}