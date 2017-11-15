namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class CheckAddedInRandom : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.RandomNoes", "IsCheck", c => c.Boolean(nullable: false));
        }
        
        public override void Down()
        {
            DropColumn("dbo.RandomNoes", "IsCheck");
        }
    }
}
