namespace EFDbFirstApprochExample.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RequiredValidationWithChanges : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime());
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String());
            AlterColumn("dbo.Products", "Active", c => c.Boolean());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Products", "Active", c => c.Boolean(nullable: false));
            AlterColumn("dbo.Products", "AvailabilityStatus", c => c.String(nullable: false));
            AlterColumn("dbo.Products", "DateOfPurchase", c => c.DateTime(nullable: false));
        }
    }
}
