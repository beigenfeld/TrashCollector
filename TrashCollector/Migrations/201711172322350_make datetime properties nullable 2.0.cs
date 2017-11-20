namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class makedatetimepropertiesnullable20 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "PickupDate", c => c.DateTime());
            AddColumn("dbo.Customers", "NoPickupStartDate", c => c.DateTime());
            AddColumn("dbo.Customers", "NoPickupEndDate", c => c.DateTime());
            AddColumn("dbo.Customers", "SpecialPickup", c => c.DateTime());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SpecialPickup");
            DropColumn("dbo.Customers", "NoPickupEndDate");
            DropColumn("dbo.Customers", "NoPickupStartDate");
            DropColumn("dbo.Customers", "PickupDate");
        }
    }
}
