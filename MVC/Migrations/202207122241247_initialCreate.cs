namespace D4.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Departments",
                c => new
                    {
                        DeptID = c.Int(nullable: false, identity: true),
                        DeptName = c.String(),
                        Description = c.String(),
                    })
                .PrimaryKey(t => t.DeptID);
            
            CreateTable(
                "dbo.Employees",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        FName = c.String(nullable: false),
                        LName = c.String(maxLength: 20),
                        Age = c.Int(nullable: false),
                        Password = c.String(nullable: false),
                        Url = c.String(),
                        Email = c.String(nullable: false),
                        Adddress = c.String(),
                        DOB = c.DateTime(nullable: false, storeType: "date"),
                        Salary = c.Decimal(nullable: false, storeType: "money"),
                        DeptID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Departments", t => t.DeptID, cascadeDelete: true)
                .Index(t => t.DeptID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Employees", "DeptID", "dbo.Departments");
            DropIndex("dbo.Employees", new[] { "DeptID" });
            DropTable("dbo.Employees");
            DropTable("dbo.Departments");
        }
    }
}
