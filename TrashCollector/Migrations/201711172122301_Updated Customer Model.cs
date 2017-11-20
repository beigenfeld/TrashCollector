namespace TrashCollector.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdatedCustomerModel : DbMigration
    {
        public override void Up()
        {
            DropPrimaryKey("dbo.Customers");
            AddColumn("dbo.Customers", "User_Id", c => c.String(maxLength: 128));
            AlterColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            AddPrimaryKey("dbo.Customers", "CustomerId");
            CreateIndex("dbo.Customers", "User_Id");
            AddForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers", "Id");
            DropColumn("dbo.Customers", "FirstName");
            DropColumn("dbo.Customers", "LastName");
            DropColumn("dbo.Customers", "Username");
            DropColumn("dbo.Customers", "Password");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Customers", "Password", c => c.String());
            AddColumn("dbo.Customers", "Username", c => c.String());
            AddColumn("dbo.Customers", "LastName", c => c.String());
            AddColumn("dbo.Customers", "FirstName", c => c.String());
            DropForeignKey("dbo.Customers", "User_Id", "dbo.AspNetUsers");
            DropIndex("dbo.Customers", new[] { "User_Id" });
            DropPrimaryKey("dbo.Customers");
            AlterColumn("dbo.Customers", "CustomerId", c => c.String(nullable: false, maxLength: 128));
            DropColumn("dbo.Customers", "User_Id");
            AddPrimaryKey("dbo.Customers", "CustomerId");
        }
    }
}
