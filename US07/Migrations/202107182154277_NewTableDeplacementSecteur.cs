namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableDeplacementSecteur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.DepalcementSecteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        CarteMembre = c.Int(nullable: false),
                        Secteur = c.String(),
                        MntDonnee = c.Decimal(nullable: false, precision: 18, scale: 3),
                        MntReste = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.DepalcementSecteurs");
        }
    }
}
