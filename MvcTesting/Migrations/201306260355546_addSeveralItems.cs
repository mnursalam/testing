namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addSeveralItems : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acts", "Status", c => c.Int(nullable: false));
            AddColumn("dbo.Acts", "Pendidikan", c => c.Int(nullable: false));
            AddColumn("dbo.Acts", "Description", c => c.String());
        }
        
        public override void Down()
        {            
            DropColumn("dbo.Acts", "Description");
            DropColumn("dbo.Acts", "Pendidikan");
            DropColumn("dbo.Acts", "Status");
        }
    }
}
