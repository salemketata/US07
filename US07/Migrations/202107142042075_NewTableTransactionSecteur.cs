namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewTableTransactionSecteur : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TransactionSecteurs",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Raison = c.String(),
                        Montant = c.Decimal(nullable: false, precision: 18, scale: 3),
                        Date = c.DateTime(nullable: false),
                        Type = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TransactionSecteurs");
        }
    }
}
