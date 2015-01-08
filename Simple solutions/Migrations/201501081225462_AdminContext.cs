namespace Simple_solutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AdminContext : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.selleds",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        productName = c.String(),
                        url = c.String(),
                        prijs = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.selleds");
        }
    }
}
