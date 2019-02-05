namespace DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class WordDB : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.tblConjugation",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FirstPersonSingular = c.String(nullable: false),
                        SecondPersonSingular = c.String(nullable: false),
                        ThirdPersonSingular = c.String(nullable: false),
                        FirstPersonPlural = c.String(nullable: false),
                        SecondPersonPlural = c.String(nullable: false),
                        ThirdPersonPlural = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.tblWord",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        HungarianWord = c.String(nullable: false),
                        SpanishWord = c.String(nullable: false),
                        Conjugation_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.tblConjugation", t => t.Conjugation_Id)
                .Index(t => t.Conjugation_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.tblWord", "Conjugation_Id", "dbo.tblConjugation");
            DropIndex("dbo.tblWord", new[] { "Conjugation_Id" });
            DropTable("dbo.tblWord");
            DropTable("dbo.tblConjugation");
        }
    }
}
