namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class removedatetimestuff : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Customers", "PickupDate");
            DropColumn("dbo.Customers", "NoPickupStartDate");
            DropColumn("dbo.Customers", "NoPickupEndDate");
            DropColumn("dbo.Customers", "SpecialPickup");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "SpecialPickup", c => c.DateTime());
            AddColumn("dbo.Customers", "NoPickupEndDate", c => c.DateTime());
            AddColumn("dbo.Customers", "NoPickupStartDate", c => c.DateTime());
            AddColumn("dbo.Customers", "PickupDate", c => c.DateTime());
        }
    }
}
