namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSukuLagiLagiOnAct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acts", "Suku3", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Acts", "Suku3");
        }
    }
}
