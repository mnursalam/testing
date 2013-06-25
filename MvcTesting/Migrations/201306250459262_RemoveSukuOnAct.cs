namespace MvcTesting.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveSukuOnAct : DbMigration
    {
        public override void Up()
        {
            DropColumn("dbo.Acts", "Suku");
            DropColumn("dbo.Acts", "Suku2");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Acts", "Suku2", c => c.String());
            AddColumn("dbo.Acts", "Suku", c => c.String());
        }
    }
}
