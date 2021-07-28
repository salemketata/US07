namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableCaisseSecteur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.CaisseSecteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        CarteMembre = c.Int(nullable: false),
                        Secteur = c.String(),
                        Collecte = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Credit = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Mois = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.CaisseSecteurs");
        }
    }
}
