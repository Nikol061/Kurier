namespace Kurier.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Parcels",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Description = c.String(),
                        Price = c.Double(nullable: false),
                        Kg = c.Double(nullable: false),
                        TypesId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ParcelTypes", t => t.TypesId, cascadeDelete: true)
                .Index(t => t.TypesId);
            
            CreateTable(
                "dbo.ParcelTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Parcels", "TypesId", "dbo.ParcelTypes");
            DropIndex("dbo.Parcels", new[] { "TypesId" });
            DropTable("dbo.ParcelTypes");
            DropTable("dbo.Parcels");
        }
    }
}
