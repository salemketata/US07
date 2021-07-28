namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeColumnNameFromSetceurToSecteurFromTableTransactionSecteur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionSecteurs", "Secteur", c => c.String());
            DropColumn("dbo.TransactionSecteurs", "Setceur");
        }
        
        public override void Down()
        {
            AddColumn("dbo.TransactionSecteurs", "Setceur", c => c.String());
            DropColumn("dbo.TransactionSecteurs", "Secteur");
        }
    }
}
