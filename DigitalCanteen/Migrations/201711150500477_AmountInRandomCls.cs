namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AmountInRandomCls : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RandomNoes", "Amount", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RandomNoes", "Amount");
        }
    }
}
