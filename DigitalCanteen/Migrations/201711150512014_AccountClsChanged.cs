namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AccountClsChanged : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.AccountDetails", "InitialBalance");
            DropColumn("dbo.AccountDetails", "Refil");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountDetails", "Refil", c => c.Int(nullable: false));
            AddColumn("dbo.AccountDetails", "InitialBalance", c => c.Int(nullable: false));
        }
    }
}
