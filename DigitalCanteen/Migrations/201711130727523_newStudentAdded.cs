namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class newStudentAdded : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.UserCredentials", "Password", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.UserCredentials", "Password", c => c.String(nullable: false, maxLength: 10));
        }
    }
}
