namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makedatetimepropertiesnullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "PickupDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "NoPickupStartDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "NoPickupEndDate", c => c.DateTime());
            AlterColumn("dbo.Customers", "SpecialPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Customers", "SpecialPickup", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "NoPickupEndDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "NoPickupStartDate", c => c.DateTime(nullable: false));
            AlterColumn("dbo.Customers", "PickupDate", c => c.DateTime(nullable: false));
        }
    }
}
