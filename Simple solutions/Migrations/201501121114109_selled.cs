namespace Simple_solutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class selled : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.selleds", "prijs", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.selleds", "prijs", c => c.Double(nullable: false));
        }
    }
}
