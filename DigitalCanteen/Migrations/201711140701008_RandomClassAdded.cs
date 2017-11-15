namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RandomClassAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.RandomNoes",
                c => new
                    {
                        RandomID = c.Int(nullable: false, identity: true),
                        RandomNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RandomID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.RandomNoes");
        }
    }
}
