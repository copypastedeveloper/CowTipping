namespace CowTippingService.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class initialstuffs : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.TippedCows",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        DateTipped = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.TippedCows");
        }
    }
}
