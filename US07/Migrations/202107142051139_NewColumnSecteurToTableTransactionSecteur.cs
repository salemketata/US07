namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnSecteurToTableTransactionSecteur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionSecteurs", "Setceur", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionSecteurs", "Setceur");
        }
    }
}
