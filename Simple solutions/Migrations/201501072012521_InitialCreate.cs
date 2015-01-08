namespace Simple_solutions.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SearchPropertiesModels",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        processorType = c.String(),
                        processorClockSpeed = c.String(),
                        processorcores = c.String(),
                        memorySlots = c.String(),
                        memorySpeed = c.String(),
                        graphicCardSpeed = c.String(),
                        graphicCardType = c.String(),
                        hardDrivetype = c.String(),
                        hardDriveCapacity = c.String(),
                        opticalDriveCategory = c.String(),
                        systemUnitFormfactor = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.SearchPropertiesModels");
        }
    }
}
