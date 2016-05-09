namespace ProjektHermods.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.ChoosenTypes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Typ = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Ingrediens",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Recepts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Info = c.String(),
                        Picture = c.String(),
                        ChoosenTypes_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ChoosenTypes", t => t.ChoosenTypes_Id)
                .Index(t => t.ChoosenTypes_Id);
            
            CreateTable(
                "dbo.UserModels",
                c => new
                    {
                        userId = c.Int(nullable: false, identity: true),
                        Name = c.String(),
                        Password = c.String(),
                    })
                .PrimaryKey(t => t.userId);
            
            CreateTable(
                "dbo.ReceptIngrediens",
                c => new
                    {
                        Recept_Id = c.Int(nullable: false),
                        Ingrediens_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Recept_Id, t.Ingrediens_Id })
                .ForeignKey("dbo.Recepts", t => t.Recept_Id, cascadeDelete: true)
                .ForeignKey("dbo.Ingrediens", t => t.Ingrediens_Id, cascadeDelete: true)
                .Index(t => t.Recept_Id)
                .Index(t => t.Ingrediens_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ReceptIngrediens", "Ingrediens_Id", "dbo.Ingrediens");
            DropForeignKey("dbo.ReceptIngrediens", "Recept_Id", "dbo.Recepts");
            DropForeignKey("dbo.Recepts", "ChoosenTypes_Id", "dbo.ChoosenTypes");
            DropIndex("dbo.ReceptIngrediens", new[] { "Ingrediens_Id" });
            DropIndex("dbo.ReceptIngrediens", new[] { "Recept_Id" });
            DropIndex("dbo.Recepts", new[] { "ChoosenTypes_Id" });
            DropTable("dbo.ReceptIngrediens");
            DropTable("dbo.UserModels");
            DropTable("dbo.Recepts");
            DropTable("dbo.Ingrediens");
            DropTable("dbo.ChoosenTypes");
        }
    }
}
