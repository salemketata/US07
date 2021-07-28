namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableProduitSecteur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ProduitSecteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        CarteMembre = c.Int(nullable: false),
                        Secteur = c.String(),
                        MntDonnee = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MntReste = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Taille = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.ProduitSecteurs");
        }
    }
}
