namespace DigitalCanteen.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ItemClassChanged : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Items", "AccountDetail_AccounNumber", "dbo.AccountDetails");
            DropForeignKey("dbo.AccountDetails", "UserId", "dbo.UserDetails");
            DropIndex("dbo.Items", new[] { "AccountDetail_AccounNumber" });
            DropIndex("dbo.AccountDetails", new[] { "UserId" });
            RenameColumn(table: "dbo.Items", name: "AccountDetail_AccounNumber", newName: "AccountDetail_UserId");
            AddColumn("dbo.Items", "Details", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Items", "Price", c => c.Single(nullable: false));
            DropPrimaryKey("dbo.AccountDetails");
            AddPrimaryKey("dbo.AccountDetails", "UserId");
            CreateIndex("dbo.Items", "AccountDetail_UserId");
            CreateIndex("dbo.AccountDetails", "UserId");
            AddForeignKey("dbo.Items", "AccountDetail_UserId", "dbo.AccountDetails", "UserId");
            AddForeignKey("dbo.AccountDetails", "UserId", "dbo.UserDetails", "UserId");
            DropColumn("dbo.AccountDetails", "AccounNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.AccountDetails", "AccounNumber", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.AccountDetails", "UserId", "dbo.UserDetails");
            DropForeignKey("dbo.Items", "AccountDetail_UserId", "dbo.AccountDetails");
            DropIndex("dbo.AccountDetails", new[] { "UserId" });
            DropIndex("dbo.Items", new[] { "AccountDetail_UserId" });
            DropPrimaryKey("dbo.AccountDetails");
            AddPrimaryKey("dbo.AccountDetails", "AccounNumber");
            AlterColumn("dbo.Items", "Price", c => c.String());
            AlterColumn("dbo.Items", "Name", c => c.String());
            DropColumn("dbo.Items", "Details");
            RenameColumn(table: "dbo.Items", name: "AccountDetail_UserId", newName: "AccountDetail_AccounNumber");
            CreateIndex("dbo.AccountDetails", "UserId");
            CreateIndex("dbo.Items", "AccountDetail_AccounNumber");
            AddForeignKey("dbo.AccountDetails", "UserId", "dbo.UserDetails", "UserId", cascadeDelete: true);
            AddForeignKey("dbo.Items", "AccountDetail_AccounNumber", "dbo.AccountDetails", "AccounNumber");
        }
    }
}
