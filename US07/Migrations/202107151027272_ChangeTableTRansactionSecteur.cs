namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ChangeTableTRansactionSecteur : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.TransactionSecteurs", "RaisonSpecifique", c => c.String());
            AddColumn("dbo.TransactionSecteurs", "Mois", c => c.String());
            AddColumn("dbo.TransactionSecteurs", "Intitule", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.TransactionSecteurs", "Intitule");
            DropColumn("dbo.TransactionSecteurs", "Mois");
            DropColumn("dbo.TransactionSecteurs", "RaisonSpecifique");
        }
    }
}
