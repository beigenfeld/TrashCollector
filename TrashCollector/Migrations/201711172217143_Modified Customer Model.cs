namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ModifiedCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "CustomerId", c => c.Int(nullable: false, identity: true));
            AlterColumn("dbo.Customers", "PickupDay", c => c.String());
            AddPrimaryKey("dbo.Customers", "CustomerId");
        }
        
        public override void Down()
        {
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "PickupDay", c => c.Int(nullable: false));
            AlterColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "CustomerId");
        }
    }
}
