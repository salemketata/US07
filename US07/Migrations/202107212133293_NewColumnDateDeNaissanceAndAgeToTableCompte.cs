namespace US07.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewColumnDateDeNaissanceAndAgeToTableCompte : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Comptes", "DateDeNaissance", c => c.DateTime(nullable: false));
            AddColumn("dbo.Comptes", "Age", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.Comptes", "Age");
            DropColumn("dbo.Comptes", "DateDeNaissance");
        }
    }
}
