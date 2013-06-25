namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSukuLagiOnAct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acts", "Suku2", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Acts", "Suku2");
        }
    }
}
