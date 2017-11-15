namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemClassChanged2 : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Items", "UseId");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Items", "UseId", c => c.Int(nullable: false));
        }
    }
}
