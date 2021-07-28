namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableCompte : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Comptes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identifiant = c.String(),
                        MotDePasse = c.String(),
                        CarteMembre = c.Int(nullable: false),
                        CarteIdentite = c.String(),
                        Role = c.String(),
                        NumTel = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Comptes");
        }
    }
}
