namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableMembres : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Membres",
                c => new
                    {
                        MembreID = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                        Prenom = c.String(),
                        CarteMembre = c.Int(nullable: false),
                        CarteIdentite = c.String(),
                        DateDeNaissance = c.DateTime(nullable: false),
                        Age = c.Int(nullable: false),
                        Secteur = c.String(),
                    })
                .PrimaryKey(t => t.MembreID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Membres");
        }
    }
}
