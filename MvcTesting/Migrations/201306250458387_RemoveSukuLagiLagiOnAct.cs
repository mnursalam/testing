namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSukuLagiLagiOnAct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Acts", "Suku3");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Acts", "Suku3", c => c.String());
        }
    }
}
