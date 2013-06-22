namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {               
            CreateTable(
                "dbo.Stores",
                c => new
                    {
                        id = c.Int(nullable: false, identity: true),
                        name = c.String(),
                        address = c.String(),
                        countJual = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.id);            
            
        }
        
        public override void Down()
        {
            
        }
    }
}
