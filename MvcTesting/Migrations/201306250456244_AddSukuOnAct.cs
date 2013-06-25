namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddSukuOnAct : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Acts", "Suku", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Acts", "Suku");
        }
    }
}
