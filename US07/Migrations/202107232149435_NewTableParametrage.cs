namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableParametrage : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parametrages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Intitule = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Parametrages");
        }
    }
}
