namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Customer : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Customers", "Address", c => c.String());
            AddColumn("dbo.Customers", "City", c => c.String());
            AddColumn("dbo.Customers", "State", c => c.String());
            AddColumn("dbo.Customers", "Zip", c => c.String());
            AddColumn("dbo.Customers", "PickupDay", c => c.String());
            AddColumn("dbo.Customers", "PickupDate", c => c.String());
            AddColumn("dbo.Customers", "Username", c => c.String());
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "NoPickupStartDate", c => c.String());
            AddColumn("dbo.Customers", "NoPickupEndDate", c => c.String());
            AddColumn("dbo.Customers", "SpecialPickup", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Customers", "SpecialPickup");
            DropColumn("dbo.Customers", "NoPickupEndDate");
            DropColumn("dbo.Customers", "NoPickupStartDate");
            DropColumn("dbo.Customers", "Password");
            DropColumn("dbo.Customers", "Username");
            DropColumn("dbo.Customers", "PickupDate");
            DropColumn("dbo.Customers", "PickupDay");
            DropColumn("dbo.Customers", "Zip");
            DropColumn("dbo.Customers", "State");
            DropColumn("dbo.Customers", "City");
            DropColumn("dbo.Customers", "Address");
        }
    }
}
