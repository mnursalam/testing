namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddTableEmployee : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Employees",
                c => new
                {
                    Id = c.Int(nullable: false, identity: true),
                    Nama = c.String(),
                    Alamat = c.String(),
                })
                .PrimaryKey(t => t.Id);
        }
        
        public override void Down()
        {
            DropTable("dbo.Employees");
        }
    }
}
